using Datalayer.Repositories;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalayer.Entities
{
    public class Visitor : IEntity<int>
    {
        public int Id { get; set; }

        public DateTime VisitDate { get; set; }
        [ForeignKey("VisitBy")]
        public string VisitBy_Id { get; set; }
        public virtual ApplicationUser VisitBy { get; set; }

        [ForeignKey("VisitTo")]
        public string VisitTo_Id { get; set; }
        public virtual ApplicationUser VisitTo { get; set; }
    }
}
