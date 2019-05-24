using System.Web.Mvc;
using Topic.Data.Repositories;
using Topic.Models;
using Topic.ViewModels;
using Topic.ViewModels.Requests;

namespace Topic.Controllers
{
    public class TopicController : ControllerBase
    {
        // GET
        public ActionResult Index()
        {
            //test
            UserSignIn("turtle", "12345");

            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var model = new TopicViewModel();

            //set user information
            model.Id = Me.Id;
            model.Email = Me.Email;
            model.DisplayName = Me.DisplayName;

            //set posts
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

            //set user information
            model.Email = Me.Email;
            model.DisplayName = Me.DisplayName;

            //set post
            using (var postRepo = new PostRepository())
            {
                model.Post = postRepo.FindById(id);
            }

            //set comments
            using (var commentRepo = new CommentRepository())
            {
                model.Comments = commentRepo.GetFindByPostId(model.Post.Id);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(CreateCommentRequest command)
        {
            if (!ModelState.IsValid)
            {
                var model = new ContentViewModel();

                //set user information
                model.Email = Me.Email;
                model.DisplayName = Me.DisplayName;

                //set post
                using (var postRepo = new PostRepository())
                {
                    model.Post = postRepo.FindById(command.PostId);
                }

                //set comments
                using (var commentRepo = new CommentRepository())
                {
                    model.Comments = commentRepo.GetFindByPostId(model.Post.Id);
                }

                return View(model);
            }

            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            //add comment
            using (var commentRepo = new CommentRepository())
            {
                commentRepo.Add(new Comment
                {
                    Content = command.Content,
                    AuthorId = Me.Id,
                    StatusId = Status.Author,
                    PostId = command.PostId,
                    Url = " ",
                });
            }

            return RedirectToAction("Detail", command.PostId);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var model = new CreatePostRequest {Email = Me.Email, DisplayName = Me.DisplayName};

            //set user information

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreatePostRequest command)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (IsExpire)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            //add post
            using (var postRepo = new PostRepository())
            {
                postRepo.Add(new Post
                {
                    Title = command.Title,
                    Content = command.Content,
                    AuthorId = Me.Id,
                    StatusId = Status.Author
                });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UnpublishedPost(int id)
        {
            //unpublished post
            using (var postRepo = new PostRepository())
            {
                postRepo.Unpublished(id, false);
            }

            return RedirectToAction("Index");
        }
    }
}