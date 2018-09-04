using Datalayer;
using Datalayer.Extensions;
using Datalayer.Repositories;
using HillbillyMatch.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HillbillyMatch.Controllers
{
    public class SearchController : Controller
    {
        private UserRepository userRepository;
        public SearchController()
        {
            DataContext context = new DataContext();
            userRepository = new UserRepository(context);
        }

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        //Get result from search
        [HttpGet]
        public PartialViewResult Result(string id)
        {
            var users = userRepository.GetUserAfterSearchText(id);

            var model = users.Select(user => new SearchUserViewModel()
            {
                UserId = user.Id,
                Name = user.Firstname + " " + user.Lastname,
                Gender = user.Gender,
                Image = user.ProfileImage
            });

            return PartialView("_SearchResult", model);
        }
        [HttpGet]
        public PartialViewResult FindMatchingPartner()
        {
            var identity = userRepository.Get(User.Identity.GetUserId());

            var usersWithOppositeGender = new List<ApplicationUser>();

            //To exclude the inlogged user to been showed at the startpage. (even tho it is not possible with the gender condition)
            if (User.Identity.IsAuthenticated)
            {
                var genderString = User.Identity.GetGender();
                var succeeded = Enum.TryParse(genderString, true, out Gender gender);

                if (succeeded)
                {
                    usersWithOppositeGender = userRepository.GetAllWithOppositeGenderWithoutIdentity(gender, identity.Id);
                }
                else
                {
                    usersWithOppositeGender = userRepository.GetAllUsersExceptForIdentity(identity.Id);
                }
            }
            else
            {
                usersWithOppositeGender = userRepository.GetAll();
            }

            var model = usersWithOppositeGender.Select(user => new FindMatchingPartnerViewModel()
            {
                UserId = user.Id,
                Name = user.Firstname + " " + user.Lastname,
                Gender = user.Gender,
                Image = user.ProfileImage,
                Percentage = Math.Round(MatchAlgorithm.MatchAlgorithm.GetMatchPercentage(identity, user), 1)
            });

            var modelOrderByPercentage = model.OrderByDescending(m => m.Percentage).Take(5);

            return PartialView("_FindMatchingPartner", modelOrderByPercentage);
        }
    }
}