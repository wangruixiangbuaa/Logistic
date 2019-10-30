using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.DAL
{
    public class UserDal
    {
        /// <summary>
        /// 登录验证的方法
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public object LoginIn(string userName, string passWord)
        {
            //与数据库操作的步骤
            string sql = "select * from[LogisticsDB].[dbo].[User] where UserName=@username AND Password=@password ";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@username", userName);
            sqlParameters[1] = new SqlParameter("@password", passWord);
            //5.执行命令，返回结果
            object result = DBHelper.ExcuteScalar(sql, sqlParameters);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserById(string id)
        {
            UserModel model = new UserModel();
            //根据用户id 查询用户信息
            string sql = "select * from[LogisticsDB].[dbo].[User] where UserID=@ID ";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
            //5.执行命令，返回结果
            SqlDataReader reader = DBHelper.ExcuteSqlDataReader(sql, sqlParameters);
            //判断有没有读到数据，hasRows 有没有行数据
            if (reader.HasRows)
            {
                //读取第一条数据
                while (reader.Read())
                {
                    model.UserName = reader["UserName"].ToString();
                    model.PassWord = reader["Password"].ToString();
                    model.Phone = reader["Phone"].ToString();
                    model.Account = reader["Account"].ToString();
                    model.UserID = int.Parse(reader["UserID"].ToString());
                    model.Sex = Convert.ToInt32(reader["Sex"]);
                    model.Email = reader["Email"].ToString();
                    model.AlertTime = Convert.ToDateTime(reader["AlterTime"]);
                    model.CheckInTime = Convert.ToDateTime(reader["CheckInTime"]);
                    model.ImagePath = reader["ImagePath"].ToString();
                }
            }
            //返回结果
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetUserList()
        {
            string sql = "select * from [LogisticsDB].[dbo].[User]";
            SqlDataReader reader = DBHelper.ExcuteSqlDataReader(sql);
            //判断有没有读到数据，hasRows 有没有行数据
            List<UserModel> users = new List<UserModel>();
            if (reader.HasRows)
            {
                //读取第一条数据
                while (reader.Read())
                {
                    UserModel model = new UserModel();
                    model.UserName = reader["UserName"].ToString();
                    model.PassWord = reader["Password"].ToString();
                    model.Phone = reader["Phone"].ToString();
                    model.Account = reader["Account"].ToString();
                    model.UserID = int.Parse(reader["UserID"].ToString());
                    model.Sex = Convert.ToInt32(reader["Sex"]);
                    model.Email = reader["Email"].ToString();
                    model.AlertTime = Convert.ToDateTime(reader["AlterTime"]);
                    model.CheckInTime = Convert.ToDateTime(reader["CheckInTime"]);
                    model.ImagePath = reader["ImagePath"].ToString();
                    users.Add(model);
                }
            }
            return users;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddUser(UserModel model)
        {
            //定义插入的sql
            string sql = @"insert into [LogisticsDB].[dbo].[User] (UserName,Sex,Account,Phone,Email,Password,CheckInTime,FK_RoleID,IsDelete,AlterTime,ImagePath) 
                         values (@name,@sex,@account,@phone,@email,@password,@checkInTime,@roleId,@isDelete,@alertTime,@imagePath)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            //构造插入的参数
            sqlParameters.Add(new SqlParameter("@name",model.UserName));
            sqlParameters.Add(new SqlParameter("@sex", model.Sex));
            sqlParameters.Add(new SqlParameter("@account", model.Account));
            sqlParameters.Add(new SqlParameter("@phone", model.Phone));
            sqlParameters.Add(new SqlParameter("@email", model.Email));
            sqlParameters.Add(new SqlParameter("@password", model.PassWord));
            sqlParameters.Add(new SqlParameter("@checkInTime", model.CheckInTime));
            sqlParameters.Add(new SqlParameter("@roleId", model.RoleId));
            sqlParameters.Add(new SqlParameter("@isDelete", model.IsDelete));
            sqlParameters.Add(new SqlParameter("@alertTime", model.AlertTime));
            sqlParameters.Add(new SqlParameter("@imagePath", model.ImagePath));
            //执行插入数据
            string sqlExist = "select * from [LogisticsDB].[dbo].[User] where UserName=@name and Account=@account";
            SqlParameter[] existP = new SqlParameter[2];
            existP[0] = new SqlParameter("@name",model.UserName);
            existP[1] = new SqlParameter("@account",model.Account);
            object ex = DBHelper.ExcuteScalar(sqlExist,existP);
            int result = 0;
            if (ex == null)
            {
                result = DBHelper.ExcuteSqlNonQuery(sql, sqlParameters.ToArray());
            }
            return result;
        }


        public int UpdateUser(UserModel model)
        {
            //定义插入的sql
            string sql = @"update [LogisticsDB].[dbo].[User] set UserName=@name,Sex=@sex,Account=@account,Phone=@phone,Email=@email,Password=@password,CheckInTime=@checkInTime,FK_RoleID=@roleId,IsDelete=@isDelete,AlterTime=@alertTime,ImagePath=@imagePath 
                         where UserID=@id";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            //构造插入的参数
            sqlParameters.Add(new SqlParameter("@name", model.UserName));
            sqlParameters.Add(new SqlParameter("@sex", model.Sex));
            sqlParameters.Add(new SqlParameter("@account", model.Account));
            sqlParameters.Add(new SqlParameter("@phone", model.Phone));
            sqlParameters.Add(new SqlParameter("@email", model.Email));
            sqlParameters.Add(new SqlParameter("@password", model.PassWord));
            sqlParameters.Add(new SqlParameter("@checkInTime", model.CheckInTime));
            sqlParameters.Add(new SqlParameter("@roleId", model.RoleId));
            sqlParameters.Add(new SqlParameter("@isDelete", model.IsDelete));
            sqlParameters.Add(new SqlParameter("@alertTime", model.AlertTime));
            sqlParameters.Add(new SqlParameter("@imagePath", model.ImagePath));
            sqlParameters.Add(new SqlParameter("@id", model.UserID));
            //执行插入数据
            int result = DBHelper.ExcuteSqlNonQuery(sql, sqlParameters.ToArray());
            return result;
        }
    }
}
