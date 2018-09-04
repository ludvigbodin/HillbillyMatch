using Datalayer.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalayer.Entities
{
    public class Friend : IEntity<int>
    {
        public int Id { get; set; }

        [ForeignKey("TheUser")]
        public virtual string TheUserId { get; set; }
        public virtual ApplicationUser TheUser { get; set; }
        [ForeignKey("TheFriend")]
        public virtual string TheFriendId { get; set; }
        public virtual ApplicationUser TheFriend { get; set; }

        public FriendCategory Category { get; set; }
    }

    public enum FriendCategory
    {
        standard,
        favorite
    }
}
