using ManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLibrary.DataAccess
{
    public class JobPostingDAO
    {
        CandidateManagementContext db = new CandidateManagementContext();
        private JobPostingDAO() { }
        private static JobPostingDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static JobPostingDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new JobPostingDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<JobPosting> GetAll => db.JobPostings.ToList();

    }
}
