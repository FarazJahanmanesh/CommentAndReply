namespace CommentAndReply.Core.Domain.Dto
{
    public class ShowAllCommentDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public int CountReply { get; set; }
    }
}
