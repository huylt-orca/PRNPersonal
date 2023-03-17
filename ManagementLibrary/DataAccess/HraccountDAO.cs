using ManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLibrary.DataAccess
{
    public class HraccountDAO
    {
        CandidateManagementContext db = new CandidateManagementContext();
        private HraccountDAO() { }
        private static HraccountDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static HraccountDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new HraccountDAO();
                    }
                    return instance;
                }
            }
        }

        public Hraccount GetById(object id) => db.Hraccounts.Find(id);

        public IEnumerable<Hraccount> GetAll(String name , int page , int pageSize )
        {
            int skip = (page - 1) * pageSize;
            return db.Hraccounts
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }
        public Hraccount checkAccount(String username, String password)
        {
            var tmp = db.Hraccounts.Find(username);
            
            if (tmp == null || tmp.Password != password) return null;

            return tmp;
        }

        public bool Create (Hraccount hraccount)
        {
            try
            {
                db.Add(hraccount);
                db.SaveChanges();
                return true;
            } catch( Exception e)
            {
                return false;
            }
        }

       

    }
}
