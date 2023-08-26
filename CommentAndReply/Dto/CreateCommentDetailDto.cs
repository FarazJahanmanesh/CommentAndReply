using System.ComponentModel.DataAnnotations;

namespace CommentAndReply.Dto
{
    public class CreateCommentDetailDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CommentText { get; set; }
    }
}
