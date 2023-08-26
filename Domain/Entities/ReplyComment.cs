namespace CommentAndReply.Core.Domain.Entities
{
    public class ReplyComment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int CommentId { get; set; }
    }
}
