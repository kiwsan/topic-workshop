using System.Web.Mvc;
using Topic.Data.Repositories;
using Topic.Models;
using Topic.ViewModels;

namespace Topic.Controllers
{
    public class TopicController : ControllerBase
    {
        // GET
        public ActionResult Index()
        {
            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var model = new TopicViewModel();

            //get user information
            model.Email = Me.Email;
            model.DisplayName = Me.DisplayName;

            //get posts
            using (var postRepo = new PostRepository())
            {
                model.Posts = postRepo.GetAll();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var model = new ContentViewModel();

            //get user information
            model.Email = Me.Email;
            model.DisplayName = Me.DisplayName;

            //get post
            using (var postRepo = new PostRepository())
            {
                model.Post = postRepo.FindById(id);
            }

            //get comments
            using (var commentRepo = new CommentRepository())
            {
                model.Comments = commentRepo.GetFindByPostId(model.Post.Id);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var model = new TopicViewModel();

            //get user information
            model.Email = Me.Email;
            model.DisplayName = Me.DisplayName;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Post command)
        {
            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            //custom value
            command.AuthorId = Me.Id;
            command.StatusId = Status.Author;

            //add post
            using (var postRepo = new PostRepository())
            {
                postRepo.Add(command);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Comment()
        {
            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var model = new TopicViewModel();

            //get user information
            model.Email = Me.Email;
            model.DisplayName = Me.DisplayName;

            return View(model);
        }

        [HttpPost]
        public ActionResult Comment(Comment command)
        {
            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            //custom value
            command.AuthorId = Me.Id;
            command.StatusId = Status.Author;

            //add comment
            using (var commentRepo = new CommentRepository())
            {
                commentRepo.Add(command);
            }

            return RedirectToAction("Detail", command.PostId);
        }
    }
}