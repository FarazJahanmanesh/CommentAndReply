namespace CommentAndReply.Core.Domain.Dto
{
    public class CreateCommentReplyDetailDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
