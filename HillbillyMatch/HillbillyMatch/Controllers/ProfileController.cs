using Datalayer.Entities;
using Datalayer.Repositories;
using HillbillyMatch.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace HillbillyMatch.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private UserRepository userRepository;
        private PostRepository postRepository;
        private FriendRepository friendRepository;
        private RequestRepository requestRepository;
        private VisitorRepository visitorRepository;
        public ProfileController() 
        {
            DataContext context = new DataContext();
            userRepository = new UserRepository(context);
            postRepository = new PostRepository(context);
            friendRepository = new FriendRepository(context);
            visitorRepository = new VisitorRepository(context);
            requestRepository = new RequestRepository(context);
        }

        // GET: ProfilePage
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = userRepository.Get(userId);
            var posts = postRepository.GetAllPostForUserIncludeSenderOrderByDateDesc(userId);
            var friends = friendRepository.GetAllIncludeFriendForUserId(userId);
            var visitors = visitorRepository.GetAllVisitorsForIdentityUser(userId);

            var myFriends = new List<FriendViewModel>();
            foreach (var item in friends)
            {
                myFriends.Add(new FriendViewModel()
                {
                    Me = item.TheUser,
                    Friend = item.TheFriend
                });
            }

            var model = new MyProfileViewModel
            {
                CurrentUser = user,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                ProfilpageImage = user.ProfileImage,
                Description = user.Description,
                Gender = user.Gender,
                Email = user.Email,
                Friends = myFriends,
                Visitors = visitors
            };

            var postModel = ConvertPostToPostViewModelIdentity(posts, user.Id);
            model.Posts = postModel; 

            return View(model);
        }     

        public ActionResult Edit()
        {
            var userId = User.Identity.GetUserId();
            var user = userRepository.Get(userId);

            var model = new ProfilePageEditViewModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Description = user.Description,
                Gender = user.Gender,
                ProfilpageImage = user.ProfileImage,
                IsVisibleForSearches = user.IsVisibleForSearches,
                IsActive = user.IsActive,

                QuestionKindOfHillbilly = user.QuestionKindOfHillbilly,
                QuestionBoundaries = user.QuestionBoundaries,
                QuestionDrive = user.QuestionDrive,
                QuestionDrunkPeriods = user.QuestionDrunkPeriods,
                QuestionLive = user.QuestionLive,
                QuestionSpeed = user.QuestionSpeed,
                QuestionFun = user.QuestionFun,
                QuestionFood = user.QuestionFood,
                QuestionMaterial = user.QuestionMaterial
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProfilePageEditViewModel model, HttpPostedFileBase imageFile)
        {
            var userId = User.Identity.GetUserId();
            var user = userRepository.Get(userId);

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            if (imageFile != null)
            {
                byte[] imageByte;
                var fileName = Path.GetFileName(imageFile.FileName);
                var fileExtension = Path.GetExtension(fileName);
                int fileSize = imageFile.ContentLength;

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png"
                    || fileExtension.ToLower() == ".jpeg")
                {
                    Stream stream = imageFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    imageByte = binaryReader.ReadBytes((int)stream.Length);
                    user.ProfileImage = imageByte;
                }
            }
            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;
            user.Description = model.Description;
            user.Email = model.Email;
            user.IsVisibleForSearches = model.IsVisibleForSearches;

            user.QuestionKindOfHillbilly = model.QuestionKindOfHillbilly;
            user.QuestionBoundaries = model.QuestionBoundaries;
            user.QuestionDrive = model.QuestionDrive;
            user.QuestionDrunkPeriods = model.QuestionDrunkPeriods;
            user.QuestionLive = model.QuestionLive;
            user.QuestionSpeed = model.QuestionSpeed;
            user.QuestionFun = model.QuestionFun;
            user.QuestionFood = model.QuestionFood;
            user.QuestionMaterial = model.QuestionMaterial;

            userRepository.Save();

            return RedirectToAction("Index");
        }

        //Returns a PartialView with the inlogged users friends
        public PartialViewResult MyFriends()
        {
            var friends = friendRepository.GetAllIncludeFriendForUserId(User.Identity.GetUserId());

            var favorite = friends.Where(friend => friend.Category == FriendCategory.favorite)
                .Select(item => new FriendViewModelTest()
                {
                    Name = item.TheFriend.Firstname + " " + item.TheFriend.Lastname,
                    FriendId = item.Id,
                    UserId = item.TheFriendId,
                    Image = item.TheFriend.ProfileImage,
                });

            var standard = friends.Where(friend => friend.Category == FriendCategory.standard)
                .Select(item => new FriendViewModelTest()
                {
                    Name = item.TheFriend.Firstname + " " + item.TheFriend.Lastname,
                    FriendId = item.Id,
                    UserId = item.TheFriendId,
                    Image = item.TheFriend.ProfileImage,
                });

            var model = new FriendIncludeCategoryViewModel()
            {
                FavoriteFriends = favorite.ToList(),
                StandardFriends = standard.ToList()
            };

            return PartialView("_Friends", model);
        }

        //Returns a PartialView with the inlogged users requests
        public PartialViewResult MyFriendRequests()
        {
            var requests = requestRepository.GetAllForUserIdOrderByDateDesc(User.Identity.GetUserId());

            if (requests.Count > 0)
            {
                var model = requests.Select(request => new RequestViewModel()
                {
                    requestId = request.Id,
                    UserId = request.RequestedBy.Id,
                    Name = request.RequestedBy.Firstname + " " + request.RequestedBy.Lastname,
                    Date = request.RequestDate,
                    TimeAgo = TimeConverter.TimeAgo(request.RequestDate),
                    Image = request.RequestedBy.ProfileImage
                });

                return PartialView("_Requests", model);
            }

            return PartialView("_NoRequest");
        }

        //Returns a PartialView with the inlogged users posts
        public PartialViewResult WallPage(string id)
        {
            var posts = postRepository.GetAllPostForUserIncludeSenderOrderByDateDesc(id);

            var model = ConvertPostToPostViewModelIdentity(posts, id);

            return PartialView("_Posts", model);
        }

        [HttpDelete]
        public void DeleteFriend(int id)
        {
            friendRepository.DeleteFriendForUsers(id);
            friendRepository.Save();
        }

        [HttpPost]
        public void AcceptRequest(int id)
        {
            try
            {
                var req = requestRepository.Get(id);

                var friend1 = new Friend()
                {
                    TheUser = req.RequestedTo,
                    TheFriend = req.RequestedBy,
                    Category = FriendCategory.standard,
                };

                var friend2 = new Friend()
                {
                    TheUser = req.RequestedBy,
                    TheFriend = req.RequestedTo,
                    Category = FriendCategory.standard,
                };

                friendRepository.Add(friend1);
                friendRepository.Add(friend2);
                requestRepository.Remove(req.Id);

                friendRepository.Save();
                requestRepository.Save();

            }
            catch (Exception ex)
            {

            }
        }

        [HttpPost]
        public void SendRequest(string id)
        {
            if (!friendRepository.IsAlreadyFriend(id, User.Identity.GetUserId()))
            {
                var user = userRepository.Get(id);
                var identity = userRepository.Get(User.Identity.GetUserId());

                var request = new Request()
                {
                    RequestDate = DateTime.Now,
                    RequestedTo = user,
                    RequestedBy = identity,
                };

                if (request.RequestedBy != null && request.RequestedTo != null)
                {
                    requestRepository.Add(request);
                    requestRepository.Save();
                }
            }
        }

        [HttpDelete]
        public void DeclineRequest(int id)
        {
            try
            {
                var req = requestRepository.Get(id);
                if (req != null)
                {
                    requestRepository.Remove(req.Id);
                    requestRepository.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Mark and unmark friends with favorite/standard tag
        [HttpPut]
        public void FavoriteTag(int id)
        {
            var friend = friendRepository.Get(id);

            if (friend.Category == FriendCategory.standard)
            {
                friend.Category = FriendCategory.favorite;
            }
            else
            {
                friend.Category = FriendCategory.standard;
            }
            friendRepository.Save();
        }

        //Other profiles
        public ActionResult UserProfile(string id)
        {
            if (id == User.Identity.GetUserId())
            {
                return RedirectToAction("Index");
            }

            var user = userRepository.Get(id);
            var posts = postRepository.GetAllPostForUserIncludeSenderOrderByDateDesc(id);
            var identity = userRepository.Get(User.Identity.GetUserId());

            var model = new UserProfileViewModel
            {
                UserId = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Description = user.Description,
                Image = user.ProfileImage,
                IsAlreadyFriend = friendRepository.IsAlreadyFriend(id, User.Identity.GetUserId()),
                MatchingPercentage = Math.Round(MatchAlgorithm.MatchAlgorithm.GetMatchPercentage(identity, user), 1)
            };

            if (model.IsAlreadyFriend)
            {
                var friend = friendRepository.GetAll().First(x => x.TheFriendId == user.Id && x.TheUserId == User.Identity.GetUserId());
                model.RelationStatusId = friend.Id;
                model.RelationStatusToIdentity = RelationStatusToIdentity.IsFriend;
            }
            else
            {
                model.HasSendRequest = requestRepository.HasAlreadySentRequest(id, User.Identity.GetUserId());
                if (model.HasSendRequest)
                {
                    var request = requestRepository.GetAll().First(x => x.RequestedBy_Id == User.Identity.GetUserId() && x.RequestedTo_Id == model.UserId);
                    model.RelationStatusId = request.Id;
                    model.RelationStatusToIdentity = RelationStatusToIdentity.HasSendRequest;
                }
                else
                {
                    model.HasRecievedRequest = requestRepository.HasRecievedRequest(id, User.Identity.GetUserId());
                    if (model.HasRecievedRequest)
                    {
                        var request = requestRepository.GetAll().First(x => x.RequestedTo_Id == User.Identity.GetUserId() && x.RequestedBy_Id == model.UserId);
                        model.RelationStatusId = request.Id;
                        model.RelationStatusToIdentity = RelationStatusToIdentity.HasRecievedRequest;
                    }
                    else
                    {
                        model.RelationStatusToIdentity = RelationStatusToIdentity.IsNotFriend;
                    }

                }
            }

            model.Posts = ConvertPostToPostViewModelIdentity(posts, id);
            model.Posts.IsFriendOrNot = model.IsAlreadyFriend;

            var visitor = new Visitor()
            {
                VisitBy = userRepository.Get(User.Identity.GetUserId()),
                VisitTo = user,
                VisitDate = DateTime.Now
            };
            visitorRepository.Add(visitor);
            visitorRepository.Save();

            return View(model);
        }

        //Returns a PartialView with new content depending on the current relation between the inlogged user and the userprofile
        public PartialViewResult UserProfileRelationStatusToIdentity(string id)
        {
            var model = new UserProfileRelationStatus();

            var user = userRepository.Get(id);
            model.UserId = user.Id;

            var IsAlreadyFriend = friendRepository.IsAlreadyFriend(id, User.Identity.GetUserId());

            if (IsAlreadyFriend)
            {
                var friend = friendRepository.GetAll().First(x => x.TheFriendId == user.Id && x.TheUserId == User.Identity.GetUserId());
                model.RelationStatusId = friend.Id;
                model.RelationStatusToIdentity = RelationStatusToIdentity.IsFriend;
            }
            else
            {
                var HasSendRequest = requestRepository.HasAlreadySentRequest(id, User.Identity.GetUserId());
                if (HasSendRequest)
                {
                    var request = requestRepository.GetAll().First(x => x.RequestedBy_Id == User.Identity.GetUserId() && x.RequestedTo_Id == model.UserId);
                    model.RelationStatusId = request.Id;
                    model.RelationStatusToIdentity = RelationStatusToIdentity.HasSendRequest;
                }
                else
                {
                    var HasRecievedRequest = requestRepository.HasRecievedRequest(id, User.Identity.GetUserId());
                    if (HasRecievedRequest)
                    {
                        var request = requestRepository.GetAll().First(x => x.RequestedTo_Id == User.Identity.GetUserId() && x.RequestedBy_Id == model.UserId);
                        model.RelationStatusId = request.Id;
                        model.RelationStatusToIdentity = RelationStatusToIdentity.HasRecievedRequest;
                    }
                    else
                    {
                        model.RelationStatusToIdentity = RelationStatusToIdentity.IsNotFriend;
                    }

                }
            }
            return PartialView("_UserRelationStatusToIdentity", model);
        }

        //Creates an object that contains a List<Post> and properties about the relationship between the inlogged user and the userprofile
        public PostViewModelIdentity ConvertPostToPostViewModelIdentity(List<Post> posts, string id)
        {
            var postsModel = posts.Select(post => new PostViewModel()
            {
                Id = post.Id,
                Text = post.Text,
                TimeAgo = TimeConverter.TimeAgo(post.Date),
                Sender = post.Sender
            });

            var model = new PostViewModelIdentity
            {
                Posts = postsModel.ToList()
            };

            if (User.Identity.GetUserId() == id) model.IsIdentity = true;
            else model.IsIdentity = false;

            model.identityId = User.Identity.GetUserId();

            return model;
        }

        //Serializing the inlogged user to a XML file and open it in a new window.
        public void Serialize()
        {

            var user = userRepository.Get(User.Identity.GetUserId());
            //requests, sended and recieved
            var requestSended = requestRepository.GetAllRequestsSendedByUserIncludeRequestedToOrderByDateDesc(user.Id);
            var requestRecieved = requestRepository.GetAllRequestsRecievedByUserIncludeRequestedToOrderByDateDesc(user.Id);
            //friends
            var friends = friendRepository.GetAllIncludeFriendForUserId(user.Id);

            //posts, shared and recieved
            var postsShared = postRepository.GetAllPostsSharedByUserIncludeRecieverOrderByDateDesc(user.Id);
            var postsRecieved = postRepository.GetAllPostForUserIncludeSenderOrderByDateDesc(user.Id);

            //visitors
            var visitors = visitorRepository.GetTop5LatestsVisitorsForUser(user.Id);

            var model = new UserXmlViewModel();
            model.Firstname = user.Firstname;
            model.Lastname = user.Lastname;
            model.gender = user.Gender;
            model.userId = user.Id;

            //Creating Lists with UserXmlViewModels
            model.RequestsSended = requestSended.Select(request => new UserRequestSendedXmlViewModel()
            {
                SendedTo = request.RequestedTo.Firstname + " " + request.RequestedTo.Lastname,
                Date = request.RequestDate
            }).ToList();

            model.RequestsRecieved = requestRecieved.Select(request => new UserRequestRecievedXmlViewModel()
            {
                Sender = request.RequestedBy.Firstname + " " + request.RequestedBy.Lastname,
                Date = request.RequestDate
            }).ToList();

            model.Friends = friends.Select(friend => new UserFriendXmlViewModel()
            {
                Firstname = friend.TheFriend.Firstname,
                Lastname = friend.TheFriend.Lastname,
                FriendCategory = friend.Category
            }).ToList();

            model.PostsRecieved = postsRecieved.Select(post => new UserPostRecievedXmlViewModel()
            {
                Sender = post.Sender.Firstname + " " + post.Sender.Lastname,
                Text = post.Text,
                Date = post.Date
            }).ToList();

            model.PostsShared = postsShared.Select(post => new UserPostSharedXmlViewModel()
            {
                SendedTo = post.Reciever.Firstname + " " + post.Reciever.Lastname,
                Text = post.Text,
                Date = post.Date
            }).ToList();

            model.Visitors = visitors.Select(visitor => new UserVisitorTop5Latest()
            {
                Name = visitor.VisitBy.Firstname + " " + visitor.VisitBy.Lastname,
                VisitDate = visitor.VisitDate
            }).ToList();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var serverPath = Server.MapPath("~/Content/Generated_files");
            
            try
            {
                var serializer = new XmlSerializer(typeof(UserXmlViewModel));

                using (var stream = new StreamWriter(serverPath + "\\MyProfile.xml"))
                {
                    serializer.Serialize(stream, model);
                    stream.Flush();
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/xml";
                Response.WriteFile(Server.MapPath("~/Content/Generated_files/MyProfile.xml"));
                Response.Flush();
                Response.End();
            }
            catch (Exception)
            {
               
            }
        }



        [HttpGet]
        public JsonResult IfUserHasAnyRequests()
        {
            var requests = requestRepository.GetAllForUserIdOrderByDateDesc(User.Identity.GetUserId());
            var success = true;

            if (requests.Any()) success = true;
            else success = false;

            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CloseAccount()
        {
            var user = userRepository.Get(User.Identity.GetUserId());
            user.IsActive = false;
            userRepository.Save();

            var AuthenticationManager = HttpContext.GetOwinContext().Authentication;
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}