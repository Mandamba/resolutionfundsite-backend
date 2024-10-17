namespace ResolutionFundSite.Application.DTOs.Response;
public class CommentResponse
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int AnnouncementId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}