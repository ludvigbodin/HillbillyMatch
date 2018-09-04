using System.Collections.Generic;
using System.Linq;

namespace Datalayer.Repositories
{
    public class UserRepository : Repository<ApplicationUser, string>
    {
        public UserRepository(DataContext context) : base(context)
        {

        }


        public List<ApplicationUser> GetAllUsersExceptForIdentity(string id)
        {
            return Items.Where(user => user.Id != id).ToList();
        }

        public List<ApplicationUser> GetAllWithOppositeGenderWithoutIdentity(Gender gender, string identityId)
        {
            return Items.Where(user => user.Gender != gender && user.Id != identityId).ToList();
        }

        public List<ApplicationUser> GetUserAfterSearchText(string text)
        {
            return Items.Where(user => user.Firstname.Contains(text) && user.IsVisibleForSearches == true && user.IsActive == true
                                || user.Lastname.Contains(text) && user.IsVisibleForSearches == true && user.IsActive == true).ToList();
        }

        public bool IfUserEmailExist(string email)
        {
            var items = Items.Where(user => user.Email == email);
            return items.Any();
        }

    }
}
