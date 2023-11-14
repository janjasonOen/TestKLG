<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formAbsensi.aspx.cs" Inherits="TugasKLG_OenJanJason.Views.formAbsensi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>From Absensi Employee</title>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"/>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
    <asp:Label ID="lblErrorMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
    <br />
    <asp:Label ID="lblNIKNama" runat="server" Text="NIK - Nama:"></asp:Label>
    <asp:DropDownList ID="ddlEmployee" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="lblTglAbsen" runat="server" Text="Tgl Absen:"></asp:Label>
    <div class="datepicker-container">
    <asp:TextBox ID="txtDate" runat="server" CssClass="datepicker-input"></asp:TextBox>
    <i class="fas fa-calendar-alt datepicker-icon"></i>
    <i class="fas fa-times datepicker-clear-icon"></i>
    </div>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <br />
    <asp:Button ID="btnViewData" runat="server" Text="View Data" OnClick="btnViewData_Click" />
    </div>
    </div>
    </form>
    <script  type="text/javascript">
        $(function () {
            $("#<%= txtDate.ClientID %>").datepicker({
                dateFormat: 'dd/mm/yy', 
                showButtonPanel: true
            });

            $(".datepicker-icon").on("click", function () {
                $("#<%= txtDate.ClientID %>").datepicker("show");
            });

            $(".datepicker-clear-icon").on("click", function () {
                $("#<%= txtDate.ClientID %>").val("");
            });
        });
    </script>
</body>
</html>
