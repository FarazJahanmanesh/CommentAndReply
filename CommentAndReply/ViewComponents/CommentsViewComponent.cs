using CommentAndReply.Contracts;
using CommentAndReply.Services;
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
        public  IViewComponentResult Invoke()
        {
            var AllComment = _commentAndReplayServices.ShowAllComment();
            return View("Comments", AllComment);
        }
    }
}
