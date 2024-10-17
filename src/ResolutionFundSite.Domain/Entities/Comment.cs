namespace ResolutionFundSite.Domain.Entities;
public class Comment : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int AnnouncementId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual Announcement Announcement { get; set; }
}