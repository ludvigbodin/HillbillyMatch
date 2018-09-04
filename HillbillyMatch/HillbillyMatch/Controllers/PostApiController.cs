using Datalayer.Entities;
using Datalayer.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HillbillyMatch.Controllers
{
    public class PostApiController : ApiController
    {
        PostRepository postRepository;
        UserRepository userRepository;

        public PostApiController()
        {
            DataContext context = new DataContext();
            postRepository = new PostRepository(context);
            userRepository = new UserRepository(context);
        }

        [HttpPost]
        public void AddPost(Post post)
        {
            try
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
    }
}
