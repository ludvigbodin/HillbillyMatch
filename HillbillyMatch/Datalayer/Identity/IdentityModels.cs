using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Datalayer.Entities;
using Datalayer.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Datalayer
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Your firstname must be atleast 2 characters")]
        public string Firstname { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Your lastname must be atleast 2 characters")]
        public string Lastname { get; set; }
        [StringLength(300, ErrorMessage = "Your description can have max 300 characters")]
        public string Description { get; set; }
        public string BirthDate { get; set; }
        public byte[] ProfileImage { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsVisibleForSearches { get; set; } = true;
        public Gender Gender { get; set; }
        public QuestionKindOfHillbilly QuestionKindOfHillbilly { get; set; }
        public QuestionBoundaries QuestionBoundaries { get; set; }
        public QuestionDrive QuestionDrive { get; set; }
        public QuestionDrunkPeriods QuestionDrunkPeriods { get; set; }
        public QuestionLive QuestionLive { get; set; }
        public QuestionSpeed QuestionSpeed { get; set; }
        public QuestionFun QuestionFun { get; set; }
        public QuestionFood QuestionFood { get; set; }
        public QuestionMaterial QuestionMaterial { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Visitor> ProfileLastVisitors { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            userIdentity.AddClaim(new Claim("Firstname", this.Firstname.ToString()));
            userIdentity.AddClaim(new Claim("Lastname", this.Lastname.ToString()));
            userIdentity.AddClaim(new Claim("Gender", this.Gender.ToString()));


            // Add custom user claims here
            return userIdentity;
        }
    }

    public enum Gender
    {
        Man,
        Woman
    }

    public enum QuestionKindOfHillbilly
    {
        [Display(Name = "Old school")]
        Oldschool,
        [Display(Name = "More modern")]
        Modern
    }

    public enum QuestionBoundaries
    {
        [Display(Name = "Absolutely not!")]
        AbsolutelyNot,
        [Display(Name = "Maybe some")]
        MaybeSome
    }

    public enum QuestionDrive
    {
        [Display(Name = "I try to walk")]
        TryToWalk,
        [Display(Name = "A sunky one")]
        ASunkyOne
    }

    public enum QuestionDrunkPeriods
    {
        [Display(Name = "Typically 1-3 days")]
        OneThreeDays,
        [Display(Name = "More than one week")]
        MoreThankOneWeek
    }

    public enum QuestionLive
    {
        [Display(Name = "Trailer park")]
        TrailerPark,
        [Display(Name = "No home")]
        NoHome
    }

    public enum QuestionSpeed
    {
        [Display(Name = "Full speed!")]
        FullSpeed,
        [Display(Name = "Slow pace...")]
        SlowPace
    }
    public enum QuestionFun
    {
        [Display(Name = "Burning tires")]
        BurningTires,
        [Display(Name = "No tires!")]
        NoTires
    }
    public enum QuestionFood
    {
        [Display(Name = "Beef")]
        Beef,
        [Display(Name = "Stake")]
        Stake
    }
    public enum QuestionMaterial
    {
        [Display(Name = "Mud")]
        Mud,
        [Display(Name = "Sand")]
        Sand
    }
}