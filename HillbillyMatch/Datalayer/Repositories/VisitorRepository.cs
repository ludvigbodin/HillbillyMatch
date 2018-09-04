using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Datalayer.Repositories
{
    public class VisitorRepository : Repository<Visitor, int>
    {
        public VisitorRepository(DataContext context) : base(context)
        {

        }

        public List<Visitor> GetAllVisitorsForIdentityUser(string id)
        {
            return Items.Where(user => user.VisitTo_Id == id).ToList();
        }

        public List<Visitor> GetTop5LatestsVisitorsForUser(string id)
        {
            var itemsOrderByDateDesc = Items.OrderBy(visitor => visitor.VisitDate);
            var noDuplicates = itemsOrderByDateDesc.GroupBy(visitor => visitor.VisitBy_Id).Select(visitor => visitor.First());

            var items = Items.Include(x => x.VisitBy)
                        .Where(x => x.VisitTo_Id == id)
                        .OrderByDescending(x => x.VisitDate)
                        .ToList();

            return items.GroupBy(x => x.VisitBy_Id).Select(y => y.First()).Take(5).ToList();
        }
    }
}
