using CommentAndReply.Dto;
using CommentAndReply.Models;

namespace CommentAndReply.Contracts
{
    public interface ICommentAndReplayServices
    {
        public void MakeComment(Comment comment); 
        public List<CommentDetailDto> ShowAllComment();
        public void MakeReplyComment(ReplyComment replyComment);
        public Comment ShowComment(int id);
        public List<ReplyComment> ShowAllReply(int id);
    }
}
