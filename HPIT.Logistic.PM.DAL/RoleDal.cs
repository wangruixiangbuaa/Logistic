using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace HPIT.Logistic.PM.DAL
{
    public class RoleDal
    {
        public List<RoleModel> GetRoleList()
        {
            //1.定义sql
            string sql = "select * from [LogisticsDB].[dbo].[Role]";
            //2.执行查询
            SqlDataReader sqlDataReader = DBHelper.ExcuteSqlDataReader(sql);
            List<RoleModel> roles = new List<RoleModel>();
            //3.返回结果
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    RoleModel model = new RoleModel();
                    model.RoleID = Convert.ToInt32(sqlDataReader["RoleID"]);
                    model.RoleName = sqlDataReader["RoleName"].ToString();
                    model.RolePurview = sqlDataReader["RolePurview"].ToString();
                    roles.Add(model);
                }
            }
            return roles;
        }
    }
}
