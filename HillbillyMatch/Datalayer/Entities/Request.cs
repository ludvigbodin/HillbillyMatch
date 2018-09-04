﻿using Datalayer.Repositories;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalayer.Entities
{
    public class Request : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }

        [ForeignKey("RequestedBy")]
        public virtual string RequestedBy_Id { get; set; }
        public virtual ApplicationUser RequestedBy { get; set; }

        [ForeignKey("RequestedTo")]
        public virtual string RequestedTo_Id { get; set; }
        public virtual ApplicationUser RequestedTo { get; set; }
    }
}
