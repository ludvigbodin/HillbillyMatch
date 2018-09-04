using Datalayer;
using Datalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalayer.Extensions;
using Microsoft.AspNet.Identity;

namespace HillbillyMatch.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository userRepository;
        private Random random;

        public HomeController()
        {
            DataContext context = new DataContext();
            userRepository = new UserRepository(context);
            random = new Random();
        }

        public ActionResult Index()
        {
            var users = new List<ApplicationUser>();

            if (User.Identity.IsAuthenticated)
            {
                users = userRepository.GetAllUsersExceptForIdentity(User.Identity.GetUserId());
            }
            else
            {
                users = userRepository.GetAll();
            }

            var randomUsers = new List<ApplicationUser>();

            for (int i = 0; i < 3; i++)
            {
                var user = users[random.Next(users.Count)];

                if (!randomUsers.Exists(x => x == user))
                {
                    randomUsers.Add(user);
                }
                else {
                    i--;
                }
            }

            return View(randomUsers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}