using Models.Dto.Model;

namespace Services.GameObjects;

public interface IGameObjectService
{
  public Task<CreateGameObjectRes> Create(CreateGameObjectReq request);
  public Task<UpdateGameObjectRes> Update(UpdateGameObjectReq request);
  public Task<UpdateGameObjectRes> Update(List<UpdateGameObjectReq> requests);
  public Task<DeleteGameObjectRes> Delete(DeleteGameObjectReq request);
  public Task<DeleteGameObjectRes> Delete(List<DeleteGameObjectReq> requests);
  public Task<DeleteGameObjectRes> Delete();
  public Task<GetGameObjectRes> Get(GetGameObjectReq request);
  public Task<GetGameObjectRes> Get(List<GetGameObjectReq> requests);
  public Task<GetGameObjectRes> Get();
}
