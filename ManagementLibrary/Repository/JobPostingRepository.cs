using ManagementLibrary.DataAccess;
using ManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLibrary.Repository
{
    public class JobPostingRepository
    {
        public IEnumerable<JobPosting> GetAll => JobPostingDAO.Instance.GetAll;
    }
}
