using Datalayer.Entities;
using Datalayer.Repositories;
using HillbillyMatch.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HillbillyMatch.Controllers
{
    public class AjaxApiController : ApiController
    {
        PostRepository postRepository;
        UserRepository userRepository;
        VisitorRepository visitorRepository;
        RequestRepository requestRepository;

        public AjaxApiController()
        {
            DataContext context = new DataContext();
            postRepository = new PostRepository(context);
            userRepository = new UserRepository(context);
            visitorRepository = new VisitorRepository(context);
            requestRepository = new RequestRepository(context);
        }

        [HttpPost]
        public void AddPost(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var reciever = userRepository.Get(post.RecieverId);

                    var _post = new Post()
                    {
                        Text = post.Text,
                        Sender = userRepository.Get(User.Identity.GetUserId()),
                        Reciever = reciever,
                        Date = DateTime.Now
                    };

                    postRepository.Add(_post);
                    postRepository.Save();
                }
                else {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {

            }
        }

        [HttpDelete]
        public void DeletePost(int id)
        {
            try
            {
                var post = postRepository.Get(id);
                postRepository.Remove(id);
                postRepository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IEnumerable<VisitorViewModel> GetLatestVisitors(string id)
        {
            var visitors = visitorRepository.GetTop5LatestsVisitorsForUser(id);

            var model = visitors.Select(visitor => new VisitorViewModel()
            {
                Id = visitor.VisitBy_Id,
                Firstname = visitor.VisitBy.Firstname,
                Lastname = visitor.VisitBy.Lastname
            });

            return model.ToList();
        }

    }
}
