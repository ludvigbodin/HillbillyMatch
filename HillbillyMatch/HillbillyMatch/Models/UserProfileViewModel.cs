using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HillbillyMatch.Models
{
    public class UserProfileViewModel
    {
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public PostViewModelIdentity Posts { get; set; }
        public bool IsAlreadyFriend { get; set; } = false;
        public bool HasSendRequest { get; set; } = false;
        public bool HasRecievedRequest { get; set; } = false;
        public double MatchingPercentage { get; set; }
        public RelationStatusToIdentity RelationStatusToIdentity { get; set; }
        public int RelationStatusId { get; set; }
    }

    public enum RelationStatusToIdentity
    {
        IsNotFriend,
        IsFriend,
        HasSendRequest,
        HasRecievedRequest
    }

    public class PostPageViewModel
    {
        public string UserId { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class UserProfileRelationStatus
    {
        public string UserId { get; set; }
        public RelationStatusToIdentity RelationStatusToIdentity { get; set; }
        public int RelationStatusId { get; set; }
    }
}