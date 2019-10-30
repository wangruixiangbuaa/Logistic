using HPIT.Logistic.PM.DAL;
using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.BLL
{
    public class RoleBll
    {
        public RoleDal roleDal = new RoleDal();
        public List<RoleModel> GetRoleList()
        {
            return roleDal.GetRoleList();
        }
    }
}
