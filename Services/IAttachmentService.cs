using Models.Dto;
using Models.Dto.Attachment;

namespace Services;

public interface IAttachmentService
{
  public Task<BasicRes> Attach(CreateAttachmentReq request);
  public Task<BasicRes> Detach(DeleteAttachmentReq request);
  public Task<BasicRes> Detach(List<DeleteAttachmentReq> requests);
  public Task<BasicRes> Get(GetAttachmentReq request);
  public Task<BasicRes> Get(List<GetAttachmentReq> requests);
  public Task<BasicRes> Get();
}
