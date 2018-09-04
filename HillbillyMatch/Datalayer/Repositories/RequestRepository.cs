using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Datalayer.Repositories
{
    public class RequestRepository : Repository<Request, int>
    {
        public RequestRepository(DataContext context) : base(context)
        {

        }

        public List<Request> GetAllForUserIdOrderByDateDesc(string userId)
        {
            return Items.Include(x => x.RequestedBy)
                    .Where(request => request.RequestedTo_Id == userId)
                    .OrderByDescending(x => x.RequestDate)
                    .ToList();
        }

        public List<Request> GetAllRequestsSendedByUserIncludeRequestedToOrderByDateDesc(string userId)
        {
            return Items.Include(x => x.RequestedTo)
                    .Where(request => request.RequestedBy_Id == userId)
                    .OrderByDescending(x => x.RequestDate)
                    .ToList();
        }

        public List<Request> GetAllRequestsRecievedByUserIncludeRequestedToOrderByDateDesc(string userId)
        {
            return Items.Include(x => x.RequestedBy)
                    .Where(request => request.RequestedTo_Id == userId)
                    .OrderByDescending(x => x.RequestDate)
                    .ToList();
        }

        public bool HasAlreadySentRequest(string userId, string identityId)
        {
            var query = Items.Where(x => x.RequestedBy_Id == identityId
                    && x.RequestedTo_Id == userId).ToList();
            if (query.Count > 0) return true;
            else return false;
        }

        public bool HasRecievedRequest(string userId, string identityId)
        {
            var query = Items.Where(x => x.RequestedBy_Id == userId
                    && x.RequestedTo_Id == identityId).ToList();
            if (query.Count > 0) return true;
            else return false;
        }
    }
}
