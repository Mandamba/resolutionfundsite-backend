namespace ResolutionFundSite.Domain.Entities;
public class Announcement : BaseEntity
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}