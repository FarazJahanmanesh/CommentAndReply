using CommentAndReply.Core.Domain.Entities;

namespace CommentAndReply.Models.ViewModel
{
    public class FirstViewModel
    {
        public List<Comment> Comments { get; set; }
        public List<ReplyComment> ReplyComments { get; set; }
    }
}
