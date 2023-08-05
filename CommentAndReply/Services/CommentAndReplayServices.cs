using CommentAndReply.Contracts;
using CommentAndReply.Dto;
using CommentAndReply.Models;
using CommentAndReply.Repository;

namespace CommentAndReply.Services
{
    public class CommentAndReplayServices : ICommentAndReplayServices
    {
        private readonly ICommentAndReplyRepository _commentAndReplyRepository;
        public CommentAndReplayServices(ICommentAndReplyRepository icommentAndReplyRepository)
        {
            _commentAndReplyRepository = icommentAndReplyRepository;
        }
        public void MakeComment(Comment comment)
        {
            _commentAndReplyRepository.MakeComment(comment);
        }

        public void MakeReplyComment(ReplyComment replyComment)
        {
            _commentAndReplyRepository.MakeReplyComment(replyComment);
        }

        public List<CommentDetailDto> ShowAllComment()
        {
            return _commentAndReplyRepository.ShowAllComment();
        }
        public Comment ShowComment(int id)
        {
            return _commentAndReplyRepository.ShowComment(id);
        }
        public List<ReplyComment> ShowAllReply(int id)
        {
            return _commentAndReplyRepository.ShowAllReply(id);
        }
    }
}
