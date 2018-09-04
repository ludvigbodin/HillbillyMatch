using Datalayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Datalayer.Repositories
{
    public class FriendRepository : Repository<Friend, int>
    {
        public FriendRepository(DataContext context) : base(context)
        {

        }

        public List<Friend> GetAllIncludeFriendForUserId(string identityId)
        {
            return Items.Include(x => x.TheFriend)
                .Where(x => x.TheUserId == identityId && x.TheFriend.IsActive == true).ToList();
        }

        public bool IsAlreadyFriend(string userId, string identityId)
        {
            var query = Items.Where(x => x.TheUserId == identityId && x.TheFriendId == userId).ToList();
            if (query.Count > 0) return true;
            else return false;
        }

        public void DeleteFriendForUsers(int id)
        {
            var friend = this.Get(id);
            var friend2 = Items.First(x => x.TheUserId == friend.TheFriendId && x.TheFriendId == friend.TheUserId);
            this.Remove(friend.Id);
            this.Remove(friend2.Id);
        }
    }
}
