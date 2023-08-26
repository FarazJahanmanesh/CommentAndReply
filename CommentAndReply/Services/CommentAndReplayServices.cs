﻿using CommentAndReply.Contracts;
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
        public async Task MakeComment(Comment comment)
        {
            await _commentAndReplyRepository.MakeComment(comment);
        }

        public async Task MakeReplyComment(ReplyComment replyComment)
        {
            await _commentAndReplyRepository.MakeReplyComment(replyComment);
        }

        public async Task<List<ShowAllCommentDetailDto>> ShowAllComment()
        {
            return await _commentAndReplyRepository.ShowAllComment();
        }
        public async  Task<Comment> ShowComment(int id)
        {
            return await _commentAndReplyRepository.ShowComment(id);
        }
        public async Task<List<ReplyComment>> ShowAllReply(int id)
        {
            return await _commentAndReplyRepository.ShowAllReply(id);
        }
    }
}
