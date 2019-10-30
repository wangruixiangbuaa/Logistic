using HPIT.Logistic.PM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPIT.Logistic.PM.WebApp.Admin
{
    public partial class RoleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定repeater 数据源，以及绑定
            //查询角色列表
            RoleBll roleBll = new RoleBll();
            Repeater1.DataSource = roleBll.GetRoleList();
            //绑定数据源
            Repeater1.DataBind();
        }
    }
}