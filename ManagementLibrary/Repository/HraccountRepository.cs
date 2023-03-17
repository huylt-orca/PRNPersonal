using ManagementLibrary.DataAccess;
using ManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLibrary.Repository
{
    public class HraccountRepository
    {
        public Hraccount checkAccount(String username, String password) => HraccountDAO.Instance.checkAccount(username, password);

        public IEnumerable<Hraccount> GetAll(String name ="" , int page = 1 , int pageSize =10 ) => HraccountDAO.Instance.GetAll(name,page,pageSize);

        public Hraccount GetById(object id) => HraccountDAO.Instance.GetById(id);

        public bool Create(Hraccount hraccount) => HraccountDAO.Instance.Create(hraccount);
    }
}
