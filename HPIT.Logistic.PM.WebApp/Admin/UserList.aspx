<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="HPIT.Logistic.PM.WebApp.Admin.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta content="width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no" name="viewport">
    <link rel="stylesheet" href="../plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="../plugins/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../plugins/ionicons/css/ionicons.min.css">
    <link rel="stylesheet" href="../plugins/iCheck/square/blue.css">
    <link rel="stylesheet" href="../plugins/morris/morris.css">
    <link rel="stylesheet" href="../plugins/jvectormap/jquery-jvectormap-1.2.2.css">
    <link rel="stylesheet" href="../plugins/datepicker/datepicker3.css">
    <link rel="stylesheet" href="../plugins/daterangepicker/daterangepicker.css">
    <link rel="stylesheet" href="../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">
    <link rel="stylesheet" href="../plugins/datatables/dataTables.bootstrap.css">
    <link rel="stylesheet" href="../plugins/treeTable/jquery.treetable.css">
    <link rel="stylesheet" href="../plugins/treeTable/jquery.treetable.theme.default.css">
    <link rel="stylesheet" href="../plugins/select2/select2.css">
    <link rel="stylesheet" href="../plugins/colorpicker/bootstrap-colorpicker.min.css">
    <link rel="stylesheet" href="../plugins/bootstrap-markdown/css/bootstrap-markdown.min.css">
    <link rel="stylesheet" href="../plugins/adminLTE/css/AdminLTE.css">
    <link rel="stylesheet" href="../plugins/adminLTE/css/skins/_all-skins.min.css">
    <link rel="stylesheet" href="../css/style.css">
    <link rel="stylesheet" href="../plugins/ionslider/ion.rangeSlider.css">
    <link rel="stylesheet" href="../plugins/ionslider/ion.rangeSlider.skinNice.css">
    <link rel="stylesheet" href="../plugins/bootstrap-slider/slider.css">
    <link rel="stylesheet" href="../plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.css">
</head>
<body>
    <form id="form1" runat="server">
           <!-- 内容头部 -->
<%--            <section class="content-header">
                <h1>
                    用户管理
                    <small>用户列表</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                    <li><a href="#">用户管理</a></li>
                    <li class="active">用户列表</li>
                </ol>
            </section>--%>
            <!-- 内容头部 /-->

            <!-- 正文区域 -->
            <section class="content">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">用户列表</h3>
                    </div>
                    <div class="box-body">
                        <!--工具栏-->
                            <div class="pull-left">
                                <div class="form-group form-inline">
                                    <div class="btn-group">
                                        <button type="button" class="btn btn-default" title="新建" onclick='location.href="AddUser.aspx"'><i class="fa fa-file-o"></i> 新建</button>
                                        <button type="button" class="btn btn-default" title="删除" onclick='confirm("你确认要删除吗？")'><i class="fa fa-trash-o"></i> 删除</button>
                                        <button type="button" class="btn btn-default" title="刷新" onclick="window.location.reload();"><i class="fa fa-refresh"></i> 刷新</button>
                                    </div>
                                </div>
                            </div>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                        <table class="table table-bordered table-striped">
                         <tr>
                             <th>头像</th>
                             <th>用户名</th>
                             <th>账号</th>
                             <th>性别</th>
                             <th>电话</th>
                             <th>邮箱</th>
                             <th>出生日期</th>
                             <th>操作</th>
                         </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <tr>
                              <td><img src='/Handlers/GetImage.ashx?path=<%#Eval("ImagePath")%>' style="width:30px;height:30px;" /></td>
                              <td><%#Eval("UserName")%></td>
                              <td><%#Eval("Account")%></td>
                              <td><%#(int)Eval("Sex") ==0 ? "男":"女"%></td>
                              <td><%#Eval("Phone")%></td>
                              <td><%#Eval("Email")%></td>
                              <td><%#Eval("CheckInTime")%></td>
                              <td class="text-center">
                                   <%--<button type="button" class="btn bg-olive btn-xs" onclick='location.href="all-order-manage-edit.html"'>订单</button>--%>
                                   <%--<button type="button" class="btn bg-olive btn-xs" onclick='location.href="all-order-manage-edit.html"'>详情</button>--%>
                                   <button type="button" class="btn bg-olive btn-xs" onclick='location.href="AddUser.aspx?id=<%#Eval("UserID") %>"'>编辑</button>
                              </td>
                           </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                        </table>
                        </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>

            </section>
    </form>
</body>
</html>
