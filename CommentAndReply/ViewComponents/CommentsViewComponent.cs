using CommentAndReply.Core.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CommentAndReply.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly ICommentAndReplayServices _commentAndReplayServices;
        public CommentsViewComponent(ICommentAndReplayServices commentAndReplayServices)
        {
            _commentAndReplayServices=commentAndReplayServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var AllComment = await _commentAndReplayServices.ShowAllComment();
            return View("Comments", AllComment);
        }
    }
}
