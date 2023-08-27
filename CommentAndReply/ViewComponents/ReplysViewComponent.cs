using CommentAndReply.Core.Domain.Contracts;
using CommentAndReply.Core.Domain.Entities;
using CommentAndReply.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommentAndReply.ViewComponents
{
    public class ReplysViewComponent : ViewComponent
    {
        private readonly ICommentAndReplayServices _commentAndReplayServices;
        public ReplysViewComponent(ICommentAndReplayServices commentAndReplayServices)
        {
            _commentAndReplayServices = commentAndReplayServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            List<ReplyComment> ReplyComments = await _commentAndReplayServices.ShowAllReply(Id);
            return View("Replys", ReplyComments);
        }
    }
}
