using Microsoft.Extensions.Options;
using ResolutionFundSite.Application;
using ResolutionFundSite.Domain.Entities;
using ResolutionFundSite.Domain.Iinterfaces;

namespace ResolutionFundSite.Infrastructure.Repositories;
public class CommentRepository : SharePointRepositoryBase<Comment>, IComentRepository
{
    public CommentRepository(IOptions<SharePointSettings> options) : base(options)
    {}
}