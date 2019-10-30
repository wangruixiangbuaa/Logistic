using HPIT.Logistic.PM.DAL;
using HPIT.Logistic.PM.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HPIT.Logistic.PM.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = DapperDBHelper.Instance.ExcuteQuery<UserModel>("select * from [LogisticsDB].[dbo].[User] where Email like @Email", new UserModel { Email = "%cn" });
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestInsert()
        {
            UserModel model = new UserModel()
            {
                Email = "627730788@qq.com",
                Account = "wrx",
                CheckInTime = DateTime.Now,
                IsDelete = 0,
                Phone = "17700611332",
                AlertTime = DateTime.Now,
                PassWord = "123",
                RoleId = 1,
                FK_RoleID = 1,
                Sex = 1,
                UserName = "王瑞祥"

            };
            var result = DapperDBHelper.Instance.ExcuteInsert<UserModel>(@"insert into [LogisticsDB].[dbo].[User] 
                                                                        (UserName,Sex,Account,Phone,Email,PassWord,CheckInTime,FK_RoleID,IsDelete,AlterTime) values 
                                                                        (@UserName,@Sex,@Account,@Phone,@Email,@PassWord,
                                                                         @CheckInTime,@FK_RoleID,@IsDelete,@AlertTime)", model);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestDelete()
        {
            var result = DapperDBHelper.Instance.ExcuteInsert<dynamic>(@"delete from  [LogisticsDB].[dbo].[User] 
                                                                       where UserID=@ID", new { ID= 20});
            Assert.AreNotEqual(0, result);
        }


        [TestMethod]
        public void TestUpdate()
        {
            UserModel model = new UserModel()
            {
                UserID = 19,
                Email = "627730788@qq.com",
                Account = "wrx",
                CheckInTime = DateTime.Now,
                IsDelete = 0,
                Phone = "17700611332",
                AlertTime = DateTime.Now,
                PassWord = "123",
                RoleId = 1,
                FK_RoleID = 1,
                Sex = 1,
                UserName = "王瑞祥"

            };
            var result = DapperDBHelper.Instance.ExcuteInsert<UserModel>(@"update [LogisticsDB].[dbo].[User] 
                                                                        set UserName=@UserName,Sex=@Sex,Account=@Account,Phone=@Phone,Email=@Email,PassWord=@PassWord,CheckInTime=@CheckInTime,FK_RoleID=@FK_RoleID,IsDelete=@IsDelete,AlterTime=@AlertTime where UserID=@UserID", model);
            Assert.AreNotEqual(0, result);
        }
    }
}
