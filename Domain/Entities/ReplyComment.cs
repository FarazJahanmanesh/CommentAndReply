namespace CommentAndReply.Core.Domain.Entities
{
    public class ReplyComment:BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsDeleted { get; set; }
        public int CommentId { get; set; }
    }
}
