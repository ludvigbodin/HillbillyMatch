using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HillbillyMatch.Models
{
    public class SearchUserViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public byte[] Image { get; set; }

    }

    public class FindMatchingPartnerViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public byte[] Image { get; set; }

        public double Percentage { get; set; }

    }
}