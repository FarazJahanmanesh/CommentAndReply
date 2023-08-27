using CommentAndReply.Core.Domain.Contracts;
using CommentAndReply.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CommentAndReply.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommentAndReplayServices _commentAndReplayServices;
        public HomeController(ICommentAndReplayServices commentAndReplayServices)
        {
            _commentAndReplayServices = commentAndReplayServices;
        }
        [HttpGet] 
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Comment comment)
        {
            //if(ModelState.IsValid==false)
                //return View(comment);
            await _commentAndReplayServices.MakeComment(new Core.Domain.Entities.Comment 
            {
                Name=comment.Name,
                PhoneNumber=comment.PhoneNumber,
                CommentText=comment.CommentText
            });
            return View();
        }
        public async Task<IActionResult> CommentReply(int Id)
        {
            var comment =await _commentAndReplayServices.ShowComment(Id);
            return View(comment);
        }
        public async Task<IActionResult> AddReply(int CId, ReplyComment replyComment)
        {
            await _commentAndReplayServices.MakeReplyComment(new Core.Domain.Entities.ReplyComment
            {
                CommentDate = replyComment.CommentDate,
                CommentId = CId,
                CommentText = replyComment.CommentText,
                Name = replyComment.Name,
                PhoneNumber = replyComment.PhoneNumber
            });
            return RedirectToAction("Index");
        }
    }
}