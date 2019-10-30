using HPIT.Logistic.PM.BLL;
using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPIT.Logistic.PM.WebApp.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        UserBll bll = new UserBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    UserModel model = bll.GetUserById(Request.QueryString["id"]);
                    TextBox_UserName.Text = model.UserName;
                    TextBox_Account.Text = model.Account;
                    TextBox_Born.Text = model.CheckInTime.ToShortDateString();
                    TextBox_Password.Text = model.PassWord;
                    TextBox_Phone.Text= model.Phone;
                    TextBox_Email.Text = model.Email;
                }
            }
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            UserModel model = new UserModel();
            model.UserName = TextBox_UserName.Text;
            model.Account = TextBox_Account.Text;
            model.CheckInTime = Convert.ToDateTime(TextBox_Born.Text);
            model.AlertTime = DateTime.Now;
            model.PassWord = TextBox_Password.Text;
            model.Phone = TextBox_Phone.Text;
            model.Email = TextBox_Email.Text;
            model.RoleId = 1;
            model.IsDelete = 0;
            model.Sex =Convert.ToInt32(radlSex.SelectedItem.Value);
            UserBll bll = new UserBll();
            //上传用户头像
            if (FileUpload_Image.PostedFile.FileName.Trim().Length != 0)
            {
                string savePath;
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssms");
                if (FileUpload_Image.HasFile && FileUpload_Image.PostedFile.FileName.Contains(".jpg"))
                {
                    //指定上传文件在服务器上的保存路径
                    savePath = Server.MapPath("~/Upload/");
                    //检查服务器上是否存在这个物理路径，如果不存在则创建
                    if (!System.IO.Directory.Exists(savePath))
                    {
                        System.IO.Directory.CreateDirectory(savePath);
                    }
                    savePath = savePath + fileName + ".jpg";
                    FileUpload_Image.SaveAs(savePath);
                    //model.ImagePath = "/Upload/" + fileName + ".jpg";
                    model.ImagePath = fileName + ".jpg";
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('请选择JPG图片文件！');", true);
                    return;
                }
            }
            int result = 0;
            if (Request.QueryString["id"] != null)
            {
                model.UserID = Convert.ToInt32(Request.QueryString["id"]);
                result = bll.UpdateUser(model);
            }
            else
            {
               result = bll.AddUser(model);
            }
            if (result > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "alert('保存成功！');window.location = 'UserList.aspx';", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "alert('保存失败！');", true);
            }

        }
    }
}