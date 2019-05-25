using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Application.Models.Requests;
using Application.Models.Responses;
using Data.Entities;
using Data.Enums;
using Data.Repositories;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class TopicController : BaseController
    {
        // GET
        [HttpGet]
        public ActionResult Index()
        {
            var model = new TopicViewModels();

            //set posts
            using (var postRepo = new PostRepository())
            {
                var items = postRepo.GetAll().Select(item => new PostResponse
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    UpdatedDate = item.UpdatedDate
                }).ToList();

                model.Posts = items;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Content(int id)
        {
            var model = new ContentViewModels();

            //set post
            using (var postRepo = new PostRepository())
            {
                var item = postRepo.FindById(id);
                model.Post = new PostResponse
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    UpdatedDate = item.UpdatedDate
                };
            }

            //set comments
            using (var commentRepo = new CommentRepository())
            {
                model.Comments = commentRepo.GetFindByPostId(model.Post.Id).Select(item => new CommentResponse
                {
                    Id = item.Id,
                    Content = item.Content,
                    UpdatedDate = item.UpdatedDate
                }).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Content(CreateCommentRequest command)
        {
            if (!ModelState.IsValid)
            {
                var model = new ContentViewModels();

                //set post
                using (var postRepo = new PostRepository())
                {
                    var item = postRepo.FindById(command.PostId);
                    model.Post = new PostResponse
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Content = item.Content,
                        UpdatedDate = item.UpdatedDate
                    };
                }

                //set comments
                using (var commentRepo = new CommentRepository())
                {
                    model.Comments = commentRepo.GetFindByPostId(model.Post.Id).Select(item => new CommentResponse
                    {
                        Id = item.Id,
                        Content = item.Content,
                        UpdatedDate = item.UpdatedDate
                    }).ToList();
                }

                return View(model);
            }

            //add comment
            using (var commentRepo = new CommentRepository())
            {
                commentRepo.Add(new Comment
                {
                    Content = command.Content,
                    PostId = command.PostId,
                    Url = " ",
                    AuthorId = Auth.Id,
                    StatusId = EStatusType.Author
                });
            }

            return RedirectToAction("Content", command.PostId);
        }

        [HttpGet]
        public ActionResult CreatePost()
        {
            var model = new CreatePostRequest {Title = "", Content = ""};

            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePost(CreatePostRequest command)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //add post
            using (var postRepo = new PostRepository())
            {
                postRepo.Add(new Post
                {
                    Title = command.Title,
                    Content = command.Content,
                    AuthorId = Auth.Id,
                    StatusId = EStatusType.Author
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