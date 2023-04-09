using Microsoft.EntityFrameworkCore;
using Models.Dto;
using Models.Dto.Attachment;
using Services.Core;

namespace Services.Attachments;

public class Attachment : IAttachmentService
{
  private readonly NawiaDbContext _context;
  private readonly DbSet<Models.Dbo.Dictionaries.Attachment> _dbSet;

  public Attachment(NawiaDbContext context)
  {
    _context = context;
    _dbSet = context.Attachments;
  }

  public async Task<BasicRes> Attach(CreateAttachmentReq request)
  {
    var res = new BasicRes();

    try
    {
      // check if attachment with the same parameters already exists
      var existingAttachment = await _dbSet.FirstOrDefaultAsync(a => a.From == request.IdFrom &&
                                                                     a.To == request.IdTo &&
                                                                     a.ModelTypeOfFrom == request.ModelTypeOfFrom &&
                                                                     a.ModelTypeOfTo == request.ModelTypeOfTo);

      if (existingAttachment != null)
      {
        res.ErrorsDictionary["Attachment"] = "Attachment already exists";
        return res;
      }

      // create new attachment
      var attachment = new Models.Dbo.Dictionaries.Attachment
      {
        From = request.IdFrom,
        To = request.IdTo,
        ModelTypeOfFrom = request.ModelTypeOfFrom,
        ModelTypeOfTo = request.ModelTypeOfTo
      };
      await _dbSet.AddAsync(attachment);
      await _context.SaveChangesAsync();

      res.Entities = new List<object> { attachment };
      res.ServicesDictionary["Attachment"] = true;
    }
    catch (Exception ex)
    {
      res.ErrorsDictionary["Attachment"] = ex.Message;
    }

    return res;
  }

  public async Task<BasicRes> Detach(DeleteAttachmentReq request)
  {
    var res = new BasicRes();

    try
    {
      var attachment = await _dbSet.FirstOrDefaultAsync(a => a.From == request.IdFrom &&
                                                             a.To == request.IdTo &&
                                                             a.ModelTypeOfFrom == request.ModelTypeOfFrom &&
                                                             a.ModelTypeOfTo == request.ModelTypeOfTo);

      if (attachment == null)
      {
        res.ErrorsDictionary["Attachment"] = "Attachment not found";
        return res;
      }

      _dbSet.Remove(attachment);
      await _context.SaveChangesAsync();

      res.Entities = new List<object> { attachment };
      res.ServicesDictionary["Attachment"] = true;
    }
    catch (Exception ex)
    {
      res.ErrorsDictionary["Attachment"] = ex.Message;
    }

    return res;
  }

  public async Task<BasicRes> Detach(List<DeleteAttachmentReq> requests)
  {
    var res = new BasicRes();

    try
    {
      foreach (var request in requests)
      {
        var attachment = await _dbSet.FirstOrDefaultAsync(a => a.From == request.IdFrom &&
                                                               a.To == request.IdTo &&
                                                               a.ModelTypeOfFrom == request.ModelTypeOfFrom &&
                                                               a.ModelTypeOfTo == request.ModelTypeOfTo);

        if (attachment != null)
        {
          _dbSet.Remove(attachment);
          await _context.SaveChangesAsync();
        }
      }

      res.ServicesDictionary["Attachment"] = true;
    }
    catch (Exception ex)
    {
      res.ErrorsDictionary["Attachment"] = ex.Message;
    }

    return res;
  }

  public async Task<BasicRes> Get(GetAttachmentReq request)
  {
    var res = new BasicRes();

    try
    {
      var attachments = await _dbSet.Where(a => a.From == request.IdFrom &&
                                                a.To == request.IdTo &&
                                                a.ModelTypeOfFrom == request.ModelTypeOfFrom &&
                                                a.ModelTypeOfTo == request.ModelTypeOfTo)
        .ToListAsync();

      res.Entities = new List<object>(attachments);
      res.ServicesDictionary["Attachment"] = true;
    }
    catch (Exception ex)
    {
      res.ErrorsDictionary["Attachment"] = ex.Message;
    }

    return res;
  }

  public async Task<BasicRes> Get(List<GetAttachmentReq> requests)
  {
    var res = new BasicRes();

    try
    {
      var attachments = new List<Models.Dbo.Dictionaries.Attachment>();
      foreach (var request in requests)
      {
        var attachmentQuery = _dbSet.AsQueryable();

        attachmentQuery = attachmentQuery.Where(a =>
          a.ModelTypeOfFrom == request.ModelTypeOfFrom && a.ModelTypeOfTo == request.ModelTypeOfTo);

        if (request.IdFrom > 0) attachmentQuery = attachmentQuery.Where(a => a.From == request.IdFrom);

        if (request.IdTo > 0) attachmentQuery = attachmentQuery.Where(a => a.To == request.IdTo);

        var attachmentsForRequest = await attachmentQuery.ToListAsync();

        attachments.AddRange(attachmentsForRequest);
      }

      res.Entities = new List<object>(attachments);
      res.ServicesDictionary["Attachment"] = true;
    }
    catch (Exception ex)
    {
      res.ErrorsDictionary["Attachment"] = ex.Message;
    }

    return res;
  }

  public async Task<BasicRes> Get()
  {
    var res = new BasicRes();

    try
    {
      var attachments = await _dbSet.ToListAsync();

      res.Entities = new List<object>(attachments);
      res.ServicesDictionary["Attachment"] = true;
    }
    catch (Exception ex)
    {
      res.ErrorsDictionary["Attachment"] = ex.Message;
    }

    return res;
  }
}
