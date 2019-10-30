using HPIT.Logistic.PM.DAL;
using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.BLL
{
    public class UserBll
    {

        public UserDal dal = new UserDal();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public object LoginIn(string userName,string passWord)
        {
            //记录当前登录人的登录信息，加载收藏，加载订单
            return dal.LoginIn(userName,passWord);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserById(string id)
        {
            return dal.GetUserById(id);
        }


        public List<UserModel> GetUsers()
        {
            return dal.GetUserList();
        }

        /// <summary>
        /// 封装bll,添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddUser(UserModel model)
        {
            return dal.AddUser(model);
        }

        /// <summary>
        /// 封装bll,添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateUser(UserModel model)
        {
            return dal.UpdateUser(model);
        }
    }
}
