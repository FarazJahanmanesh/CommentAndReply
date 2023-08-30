using CommentAndReply.Core.Domain.Contracts;
using CommentAndReply.Core.Domain.Dto;
using CommentAndReply.Core.Domain.Entities;

namespace CommentAndReply.Core.Application.Services
{
    public class CommentAndReplayServices : ICommentAndReplayServices
    {
        private readonly ICommentAndReplyRepository _commentAndReplyRepository;
        public CommentAndReplayServices(ICommentAndReplyRepository icommentAndReplyRepository)
        {
            _commentAndReplyRepository = icommentAndReplyRepository;
        }
        public async Task CreateComment(CreateCommentDetailDto detailDto)
        {
            await _commentAndReplyRepository.CreateComment(detailDto);
        }

        public async Task CreateReplyComment(CreateCommentReplyDetailDto detailDto)
        {
            await _commentAndReplyRepository.CreateReplyComment(detailDto);
        }

        public async Task<List<ShowAllCommentDetailDto>> ShowAllComment()
        {
            return await _commentAndReplyRepository.ShowAllComment();
        }
        public async  Task<ShowCommentDetailDto> ShowComment(int id)
        {
            return await _commentAndReplyRepository.ShowComment(id);
        }
        public async Task<List<ShowAllCommentReplyDetailDto>> ShowAllReply(int id)
        {
            return await _commentAndReplyRepository.ShowAllReply(id);
        }
    }
}
