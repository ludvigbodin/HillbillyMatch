using Datalayer;
using Datalayer.Entities;
using HillbillyMatch.International;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HillbillyMatch.Models
{
    public class MyProfileViewModel
    {
        public ApplicationUser CurrentUser { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Description { get; set; }
        public byte[] ProfilpageImage { get; set; }
        public PostViewModelIdentity Posts { get; set; }
        public List<FriendViewModel> Friends { get; set; }
        public List<Visitor> Visitors { get; set; }
    }

    public class FriendViewModel
    {
        public ApplicationUser Me { get; set; }
        public ApplicationUser Friend { get; set; }
    }

    public class ProfilePageEditViewModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(300, ErrorMessage = "Your description can have max 300 characters")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public byte[] ProfilpageImage { get; set; }

        [Display(Name = "Visible to searches")]
        public bool IsVisibleForSearches { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "What kind of hillbilly are you?")]
        public QuestionKindOfHillbilly QuestionKindOfHillbilly { get; set; }
        [Required]
        [Display(Name = "Do you have any boundaries?")]
        public QuestionBoundaries QuestionBoundaries { get; set; }
        [Required]
        [Display(Name = "What car do you drive?")]
        public QuestionDrive QuestionDrive { get; set; }
        [Required]
        [Display(Name = "For how long periods are you usually drunk?")]
        public QuestionDrunkPeriods QuestionDrunkPeriods { get; set; }
        [Required]
        [Display(Name = "How do you want to live?")]
        public QuestionLive QuestionLive { get; set; }
        [Required]
        [Display(Name = "Do you like full speed or slow pace?")]
        public QuestionSpeed QuestionSpeed { get; set; }
        [Required]
        [Display(Name = "What is the most fun?")]
        public QuestionFun QuestionFun { get; set; }
        [Required]
        [Display(Name = "What is your favourite food?")]
        public QuestionFood QuestionFood { get; set; }
        [Required]
        [Display(Name = "Mud or Sand?")]
        public QuestionMaterial QuestionMaterial { get; set; }
    }

    public class FriendViewModelTest
    {
        public int FriendId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public FriendCategory Category { get; set; }

    }


    public class FriendIncludeCategoryViewModel
    {
        public List<FriendViewModelTest> FavoriteFriends { get; set; }
        public List<FriendViewModelTest> StandardFriends { get; set; }
    }


    public class RequestViewModel
    {
        public int requestId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string TimeAgo { get; set; }
        public byte[] Image { get; set; }
    }

    public class PostViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string TimeAgo { get; set; }
        public virtual ApplicationUser Sender { get; set; }
    }

    public class PostViewModelIdentity
    {
        public string identityId { get; set; }
        public bool IsIdentity { get; set; } = false;
        public bool IsFriendOrNot { get; set; } = true;
        public List<PostViewModel> Posts { get; set; }

    }

    public class VisitorViewModel
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}