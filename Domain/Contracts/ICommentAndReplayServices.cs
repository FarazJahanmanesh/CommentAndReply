﻿using CommentAndReply.Core.Domain.Dto;
using CommentAndReply.Core.Domain.Entities;

namespace CommentAndReply.Core.Domain.Contracts
{
    public interface ICommentAndReplayServices
    {
        public Task CreateComment(CreateCommentDetailDto detailDto); 
        public Task<List<ShowAllCommentDetailDto>> ShowAllComment();
        public Task CreateReplyComment(ReplyComment replyComment);
        public Task<Comment> ShowComment(int id);
        public Task<List<ReplyComment>> ShowAllReply(int id);
    }
}
