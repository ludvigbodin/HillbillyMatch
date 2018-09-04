using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Datalayer.Repositories
{
    public class PostRepository : Repository<Post, int>
    {
        public PostRepository(DataContext context) : base(context)
        {
        }

        public List<Post> GetAllPostForUserIncludeSenderOrderByDateDesc(string id)
        {
            return Items.Include(p => p.Sender).ToList().Where(post => post.RecieverId == id).OrderByDescending(post => post.Date).ToList();

        }

        public List<Post> GetAllPostsSharedByUserIncludeRecieverOrderByDateDesc(string id)
        {
            return Items.Include(p => p.Reciever).ToList().Where(post => post.SenderId == id).OrderByDescending(post => post.Date).ToList();
        }
    }
}
