using ManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLibrary.DataAccess
{
    public class CandidateProfileDAO
    {
        CandidateManagementContext db = new CandidateManagementContext();
        private CandidateProfileDAO() { }
        private static CandidateProfileDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static CandidateProfileDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CandidateProfileDAO();
                    }
                    return instance;
                }
            }
        }

        public CandidateProfile GetById(object id) => db.CandidateProfiles.Find(id);

        public IEnumerable<CandidateProfile> GetAll(String name, int page, int pageSize,DateTime? searchBirthday)
        {
            int skip = (page - 1) * pageSize;
            return db.CandidateProfiles
                .Where(p => p.Fullname.Contains(name)
                || (!searchBirthday.HasValue && p.Birthday == searchBirthday)
                )
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public bool Create (CandidateProfile candidateProfile)
        {
            try
            {
                db.CandidateProfiles.Add(candidateProfile);
                db.SaveChanges();
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }

        public bool Update (CandidateProfile candidateProfile)
        {
            try
            {
                var tmp = db.CandidateProfiles.Find(candidateProfile.CandidateId);
                if (tmp == null) return false;
                //tmp = candidateProfile;
                tmp.Fullname = candidateProfile.Fullname;
                tmp.Birthday = candidateProfile.Birthday;
                tmp.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                tmp.ProfileUrl = candidateProfile.ProfileUrl;
                tmp.PostingId = candidateProfile.PostingId;
                db.SaveChanges();
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete (object id)
        {
            try
            {
                var tmp = db.CandidateProfiles.Find(id);
                if (tmp == null) return true;
                db.CandidateProfiles.Remove(tmp);
                db.SaveChanges();
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }

        public int GetTotal(String name, DateTime? searchBirthday)
        {
            return db.CandidateProfiles.Where(p => p.Fullname.Contains(name)
                || (!searchBirthday.HasValue && p.Birthday == searchBirthday)
                ).Count();
        }
    }
}
