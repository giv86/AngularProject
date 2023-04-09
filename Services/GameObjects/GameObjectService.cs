using Microsoft.EntityFrameworkCore;
using Models.Dbo.Game;
using Models.Dto.Model;
using Services.Core;

namespace Services.GameObjects;

public class GameObjectService<T> : IGameObjectService where T : BaseGameFields, new()
{
  private readonly NawiaDbContext _dbContext;
  private readonly DbSet<T> _dbSet;

  public GameObjectService(NawiaDbContext dbContext)
  {
    _dbContext = dbContext;
    _dbSet = dbContext.Set<T>();
  }

  public async Task<CreateGameObjectRes> Create(CreateGameObjectReq request)
  {
    var entity = new T
    {
      Name = request.Name,
      Description = request.Description,
      DisplayText = request.DisplayText,
      Created = DateTime.UtcNow,
      Updated = DateTime.UtcNow
    };

    _dbSet.Add(entity);

    var result = await _dbContext.SaveChangesAsync();

    var res = new CreateGameObjectRes
    {
      ServicesDictionary = new Dictionary<string, bool>
      {
        { "Create", result == 1 }
      }
    };

    if (!res.IsSuccess) res.ErrorsDictionary.Add("Create", "Failed to create entity");

    return res;
  }

  public async Task<UpdateGameObjectRes> Update(UpdateGameObjectReq request)
  {
    var res = new UpdateGameObjectRes();
    try
    {
      var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == request.Id && x.ModelType == request.ModelType);
      if (entity == null)
      {
        res.ErrorsDictionary.Add(nameof(request.Id), "Entity not found");
        return res;
      }

      entity.Name = request.Name;
      entity.Description = request.Description;
      entity.DisplayText = request.DisplayText;
      await _dbContext.SaveChangesAsync();

      res.Entities = new List<object> { entity };
      res.ServicesDictionary.Add(nameof(UpdateGameObjectRes), true);
    }
    catch (Exception e)
    {
      res.ErrorsDictionary.Add(nameof(UpdateGameObjectRes), e.Message);
    }

    return res;
  }

  public async Task<UpdateGameObjectRes> Update(List<UpdateGameObjectReq> requests)
  {
    var result = new UpdateGameObjectRes();
    var errors = new Dictionary<string, string>();

    foreach (var request in requests)
      try
      {
        var entity = await _dbSet.FindAsync(request.Id);

        if (entity == null)
        {
          errors.Add(request.Id.ToString(), $"Could not find {typeof(T).Name} with id {request.Id}");
          continue;
        }

        // Update entity properties
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.DisplayText = request.DisplayText;

        _dbSet.Update(entity);
      }
      catch (Exception ex)
      {
        errors.Add(request.Id.ToString(), ex.Message);
      }

    if (errors.Any())
      result.ErrorsDictionary = errors;
    else
      try
      {
        await _dbContext.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        errors.Add("Update", ex.Message);
        result.ErrorsDictionary = errors;
      }

    return result;
  }


  public async Task<DeleteGameObjectRes> Delete(DeleteGameObjectReq request)
  {
    var response = new DeleteGameObjectRes();
    try
    {
      var entity = await _dbSet.FindAsync(request.Id);
      if (entity == null)
      {
        response.ErrorsDictionary.Add("EntityNotFound",
          $"Entity with id {request.Id} and model type {request.ModelType} was not found.");
        return response;
      }

      if (entity.ModelType != request.ModelType)
      {
        response.ErrorsDictionary.Add("InvalidModelType",
          $"The model type of entity with id {request.Id} does not match the provided model type.");
        return response;
      }

      _dbSet.Remove(entity);
      await _dbContext.SaveChangesAsync();
    }
    catch (Exception ex)
    {
      response.ErrorsDictionary.Add("UnexpectedError",
        $"An unexpected error occurred while deleting entity with id {request.Id} and model type {request.ModelType}. {ex.Message}");
      return response;
    }

    response.ServicesDictionary.Add("DeleteEntity", true);
    return response;
  }

  public async Task<DeleteGameObjectRes> Delete(List<DeleteGameObjectReq> requests)
  {
    var result = new DeleteGameObjectRes();

    foreach (var request in requests)
    {
      var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == request.Id && x.ModelType == request.ModelType);
      if (entity != null)
        _dbContext.Remove(entity);
      else
        result.ErrorsDictionary[$"Object with id {request.Id} and model type {request.ModelType} not found"] =
          "Object not found";
    }

    try
    {
      await _dbContext.SaveChangesAsync();
      result.ServicesDictionary[typeof(T).Name] = true;
    }
    catch (Exception ex)
    {
      result.ErrorsDictionary[typeof(T).Name] = ex.Message;
    }

    return result;
  }

  public Task<DeleteGameObjectRes> Delete()
  {
    throw new NotImplementedException();
  }

  public async Task<GetGameObjectRes> Get(GetGameObjectReq request)
  {
    var res = new GetGameObjectRes();
    try
    {
      var entity = await _dbSet.FindAsync(request.Id);
      if (entity != null && entity.ModelType == request.ModelType)
        res.Entities = new List<object> { entity };
      else
        res.ErrorsDictionary.Add("NotFound", "Entity not found.");
    }
    catch (Exception e)
    {
      res.ErrorsDictionary.Add("Error", $"An error occurred while getting entity: {e.Message}");
    }

    return res;
  }


  public async Task<GetGameObjectRes> Get(List<GetGameObjectReq> requests)
  {
    var res = new GetGameObjectRes();

    try
    {
      var entities = new List<object>();
      foreach (var request in requests)
      {
        var entity = await _dbSet.FindAsync(request.Id);
        if (entity != null && entity.ModelType == request.ModelType) entities.Add(entity);
      }

      if (entities.Count > 0)
        res.Entities = entities;
      else
        res.ErrorsDictionary.Add("GetGameObject", "No matching entities found.");
    }
    catch (Exception ex)
    {
      res.ErrorsDictionary.Add("GetGameObject", ex.Message);
    }

    return res;
  }


  public async Task<GetGameObjectRes> Get()
  {
    var response = new GetGameObjectRes();

    try
    {
      var entities = await _dbSet.ToListAsync();
      response.Entities = entities.Cast<object>().ToList();
      response.ServicesDictionary.Add(nameof(Get), true);
    }
    catch (Exception ex)
    {
      response.ErrorsDictionary.Add(nameof(Get), ex.Message);
      response.ServicesDictionary.Add(nameof(Get), false);
    }

    return response;
  }
}
