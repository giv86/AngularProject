using Microsoft.AspNetCore.Mvc;
using Models.Dto.Attachment;
using Models.Dto.Model;

namespace WebApi.Controllers;

public interface IGameObjectController
{
  [HttpPost("game-object/create")]
  public Task<IActionResult> CreateGameObject(CreateGameObjectReq request);

  [HttpPost("game-object/update")]
  public Task<IActionResult> UpdateGameObject(UpdateGameObjectReq request);

  [HttpPost("game-object/update-multiple")]
  public Task<IActionResult> UpdateMultipleGameObjects(List<UpdateGameObjectReq> requests);

  [HttpPost("game-object/delete")]
  public Task<IActionResult> DeleteGameObject(DeleteGameObjectReq request);

  [HttpPost("game-object/delete-multiple")]
  public Task<IActionResult> DeleteMultipleGameObjects(List<DeleteGameObjectReq> requests);

  [HttpPost("game-object/delete-all")]
  public Task<IActionResult> DeleteAllGameObjects();

  [HttpPost("game-object/get")]
  public Task<IActionResult> GetGameObject(GetGameObjectReq request);

  [HttpPost("game-object/get-multiple")]
  public Task<IActionResult> GetMultipleGameObjects(List<GetGameObjectReq> requests);

  [HttpPost("game-object/get-all")]
  public Task<IActionResult> GetAllGameObjects();

  [HttpPost("game-object/attach")]
  public Task<IActionResult> Attach(CreateAttachmentReq request);

  [HttpPost("game-object/detach")]
  public Task<IActionResult> Detach(DeleteAttachmentReq request);

  [HttpPost("game-object/detach-multiple")]
  public Task<IActionResult> DetachMultiple(List<DeleteAttachmentReq> requests);

  [HttpPost("game-object/get-attachment")]
  public Task<IActionResult> GetAttachment(GetAttachmentReq request);

  [HttpPost("game-object/get-multiple-attachments")]
  public Task<IActionResult> GetMultipleAttachments(List<GetAttachmentReq> requests);

  [HttpPost("game-object/get-all-attachments")]
  public Task<IActionResult> GetAllAttachments();
}
