using CommentAndReply.Core.Domain.Contracts;
using CommentAndReply.Core.Domain.Dto;
using CommentAndReply.Core.Domain.Entities;
using CommentAndReply.EndPoint.Models.ViewModel;
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
        public async Task<IActionResult> Index(CreateCommentViewModel model)
        {
            //if(ModelState.IsValid==false)
                //return View(comment);
            await _commentAndReplayServices.CreateComment(new CreateCommentDetailDto
            {
                Name= model.Name,
                PhoneNumber= model.PhoneNumber,
                CommentText= model.CommentText
            });
            return View();
        }
        public async Task<IActionResult> CommentReply(int Id)
        {
            var comment =await _commentAndReplayServices.ShowComment(Id);
            return View(new ShowCommentViewModel
            {
                PhoneNumber=comment.PhoneNumber,
                Name=comment.Name,
                CommentText=comment.CommentText
            });
        }
        public async Task<IActionResult> AddReply(int CId, CreateReplyCommentViewModel model)
        {
            await _commentAndReplayServices.CreateReplyComment(new CreateCommentReplyDetailDto
            {
                //CommentId = CId,
                CommentText = model.CommentText,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber
            });
            return RedirectToAction("Index");
        }
    }
}