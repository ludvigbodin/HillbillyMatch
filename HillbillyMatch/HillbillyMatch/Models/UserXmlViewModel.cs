using Datalayer;
using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace HillbillyMatch.Models
{
    [Serializable]
    public class UserXmlViewModel
    {
        public UserXmlViewModel()
        {

        }
        public string userId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender gender { get; set; }

        [XmlElement(ElementName = "RequestsRecieved")]
        public List<UserRequestRecievedXmlViewModel> RequestsRecieved { get; set; }
        [XmlElement(ElementName = "RequestsSended")]
        public List<UserRequestSendedXmlViewModel> RequestsSended { get; set; }
        [XmlElement(ElementName = "PostsRecieved")]
        public List<UserPostRecievedXmlViewModel> PostsRecieved { get; set; }
        [XmlElement(ElementName = "PostsShared")]
        public List<UserPostSharedXmlViewModel> PostsShared { get; set; }
        [XmlElement(ElementName = "Friends")]
        public List<UserFriendXmlViewModel> Friends { get; set; }
        [XmlElement(ElementName = "Top5LatestVisitors")]
        public List<UserVisitorTop5Latest> Visitors { get; set; }
    }

    [Serializable]
    public class UserRequestRecievedXmlViewModel
    {
        public UserRequestRecievedXmlViewModel()
        {

        }
        public string Sender { get; set; }
        public DateTime Date { get; set; }
    }
    [Serializable]
    public class UserRequestSendedXmlViewModel
    {
        public UserRequestSendedXmlViewModel()
        {

        }
        public string SendedTo { get; set; }
        public DateTime Date { get; set; }
    }
    [Serializable]
    public class UserFriendXmlViewModel
    {
        public UserFriendXmlViewModel()
        {

        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public FriendCategory FriendCategory { get; set; }
    }
    [Serializable]
    public class UserPostRecievedXmlViewModel
    {
        public UserPostRecievedXmlViewModel()
        {

        }
        public string Sender { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
    [Serializable]
    public class UserPostSharedXmlViewModel
    {
        public UserPostSharedXmlViewModel()
        {

        }
        public string SendedTo { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
    [Serializable]
    public class UserVisitorTop5Latest
    {
        public UserVisitorTop5Latest()
        {

        }
        public string Name { get; set; }
        public DateTime VisitDate { get; set; }
    }
}