using ManagementLibrary.DataAccess;
using ManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLibrary.Repository
{
    public class CandidateProfileRepository
    {
        public CandidateProfile GetById(object id) => CandidateProfileDAO.Instance.GetById(id);

        public IEnumerable<CandidateProfile> GetAll(int page = 1, int pageSize = 10, String name = "",DateTime? searchBirthday = null)
            => CandidateProfileDAO.Instance.GetAll(name, page, pageSize,searchBirthday);

        public bool Delete (object id) => CandidateProfileDAO.Instance.Delete(id);

        public bool Create (CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.Create(candidateProfile);

        public bool Update (CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.Update(candidateProfile);

        public int GetTotal() => CandidateProfileDAO.Instance.GetTotal();


    }
}
