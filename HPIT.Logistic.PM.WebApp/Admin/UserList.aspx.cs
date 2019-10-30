using HPIT.Logistic.PM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPIT.Logistic.PM.WebApp.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserBll bll = new UserBll();
            //赋值数据源
            Repeater1.DataSource = bll.GetUsers();
            Repeater1.DataBind();
        }
    }
}