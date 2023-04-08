using Microsoft.AspNetCore.Mvc;
using Models.Dbo.Game;
using Models.Dto.Attachment;
using Models.Dto.Model;
using Services;
using Services.Core;

namespace WebApi.Controllers
{
  public class BaseGameObjectController<T> : BaseController, IGameObjectController where T : BaseGameFields, new()
  {
    private readonly IGameObjectService _gameObjectService;
    private readonly IAttachmentService _attachmentService;

    public BaseGameObjectController(NawiaDbContext dbContext) : base(dbContext)
    {
      _gameObjectService = new Services.GameObjectService<T>(dbContext);
      _attachmentService = new Attachment(dbContext);
    }

    public async Task<IActionResult> CreateGameObject(CreateGameObjectReq request)
    {
      var result = await _gameObjectService.Create(request);

      return result?.IsSuccess == true
        ? Ok(result.Entities)
        : BadRequest(result?.ErrorsDictionary);
    }

    public async Task<IActionResult> UpdateGameObject(UpdateGameObjectReq request)
    {
      var result = await _gameObjectService.Update(request);
      return result.EntitiesHasAnyElement ? Ok(result.Entities)
        : BadRequest(result.ErrorsDictionary);
    }
    public async Task<IActionResult> UpdateMultipleGameObjects(List<UpdateGameObjectReq> requests)
    {
      var result = await _gameObjectService.Update(requests);

      return result.EntitiesHasAnyElement ? Ok(result.Entities) : BadRequest(result.ErrorsDictionary);
    }

    public async Task<IActionResult> DeleteGameObject(DeleteGameObjectReq request)
    {
      var result = await _gameObjectService.Delete(request);
      return Ok(result);
    }
    public async Task<IActionResult> DeleteMultipleGameObjects(List<DeleteGameObjectReq> requests)
    {
      var res = await _gameObjectService.Delete(requests);

      return res.HasErrors
        ? BadRequest(res)
        : Ok(res);
    }
    public async Task<IActionResult> DeleteAllGameObjects()
    {
      var res = await _gameObjectService.Delete();
      return res.HasErrors ? BadRequest(res.ErrorsDictionary) : Ok(res.Entities);
    }

    public async Task<IActionResult> GetGameObject(GetGameObjectReq request)
    {
      var response = await _gameObjectService.Get(request);

      return response.IsSuccess ?
        Ok(response) :
        BadRequest(response);
    }
    public async Task<IActionResult> GetMultipleGameObjects(List<GetGameObjectReq> requests)
    {
      var response = await _gameObjectService.Get(requests);

      return response.EntitiesHasAnyElement
        ? Ok(response)
        : NotFound(response);
    }
    public async Task<IActionResult> GetAllGameObjects()
    {
      var response = await _gameObjectService.Get();

      return response?.HasErrors == false
        ? Ok(response)
        : BadRequest(response);
    }

    public async Task<IActionResult> Attach(CreateAttachmentReq request)
    {
      var res = await _attachmentService.Attach(request);
      return res?.HasErrors == true ? BadRequest(res) : Ok(res);
    }

    public async Task<IActionResult> Detach(DeleteAttachmentReq request)
    {
      var res = await _attachmentService.Detach(request);
      return res?.HasErrors == true ? BadRequest(res) : Ok(res);
    }
    public async Task<IActionResult> DetachMultiple(List<DeleteAttachmentReq> requests)
    {
      var res = await _attachmentService.Detach(requests);
      return res.HasErrors ? BadRequest(res) : Ok(res);
    }

    public async Task<IActionResult> GetAttachment(GetAttachmentReq request)
    {
      var res = await _attachmentService.Get(request);
      return res.HasErrors ? BadRequest(res) : Ok(res);
    }
    public async Task<IActionResult> GetMultipleAttachments(List<GetAttachmentReq> requests)
    {
      var res = await _attachmentService.Get(requests);

      return res.HasErrors ? BadRequest(res) : Ok(res);
    }
    public async Task<IActionResult> GetAllAttachments()
    {
      var res = await _attachmentService.Get();
      return res.HasErrors ? BadRequest(res) : Ok(res);
    }
  }
}
