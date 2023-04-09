using Microsoft.AspNetCore.Mvc;
using Services.Attachments;
using Services.Core;

namespace WebApi.Controllers
{
  public class BaseAccountController : BaseController
  {

    private readonly IAttachmentService _attachmentService;

    public BaseAccountController(NawiaDbContext dbContext) : base(dbContext)
    {
      _attachmentService = new Attachment(dbContext);
    }
  }
}
