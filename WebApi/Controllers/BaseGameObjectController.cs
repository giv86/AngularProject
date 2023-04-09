using Microsoft.AspNetCore.Mvc;
using Models.Dbo.Game;
using Models.Dto.Attachment;
using Models.Dto.Model;
using Services.Attachments;
using Services.Core;
using Services.GameObjects;

namespace WebApi.Controllers;

public class BaseGameObjectController<T> : BaseController, IGameObjectController where T : BaseGameFields, new()
{
  private readonly IAttachmentService _attachmentService;
  private readonly IGameObjectService _gameObjectService;

  public BaseGameObjectController(NawiaDbContext dbContext) : base(dbContext)
  {
    _gameObjectService = new GameObjectService<T>(dbContext);
    _attachmentService = new Attachment(dbContext);
  }

  public async Task<IActionResult> CreateGameObject(CreateGameObjectReq request)
  {
    var res = await _gameObjectService.Create(request);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> UpdateGameObject(UpdateGameObjectReq request)
  {
    var res = await _gameObjectService.Update(request);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> UpdateMultipleGameObjects(List<UpdateGameObjectReq> requests)
  {
    var res = await _gameObjectService.Update(requests);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> DeleteGameObject(DeleteGameObjectReq request)
  {
    var res = await _gameObjectService.Delete(request);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> DeleteMultipleGameObjects(List<DeleteGameObjectReq> requests)
  {
    var res = await _gameObjectService.Delete(requests);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> DeleteAllGameObjects()
  {
    var res = await _gameObjectService.Delete();

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> GetGameObject(GetGameObjectReq request)
  {
    var res = await _gameObjectService.Get(request);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> GetMultipleGameObjects(List<GetGameObjectReq> requests)
  {
    var res = await _gameObjectService.Get(requests);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> GetAllGameObjects()
  {
    var res = await _gameObjectService.Get();

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> Attach(CreateAttachmentReq request)
  {
    var res = await _attachmentService.Attach(request);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> Detach(DeleteAttachmentReq request)
  {
    var res = await _attachmentService.Detach(request);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> DetachMultiple(List<DeleteAttachmentReq> requests)
  {
    var res = await _attachmentService.Detach(requests);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> GetAttachment(GetAttachmentReq request)
  {
    var res = await _attachmentService.Get(request);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> GetMultipleAttachments(List<GetAttachmentReq> requests)
  {
    var res = await _attachmentService.Get(requests);

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }

  public async Task<IActionResult> GetAllAttachments()
  {
    var res = await _attachmentService.Get();

    return res?.IsSuccess == true
      ? Ok(res)
      : BadRequest(res);
  }
}
