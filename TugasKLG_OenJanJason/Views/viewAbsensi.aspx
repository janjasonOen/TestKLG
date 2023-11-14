<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewAbsensi.aspx.cs" Inherits="TugasKLG_OenJanJason.Views.viewAbsensi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Data Absen</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>Data Kehadiran</h3>
    <asp:GridView ID="gvAttendanceList" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="NIK" HeaderText="NIK" />
        <asp:BoundField DataField="Nama" HeaderText="Nama" />
        <asp:BoundField DataField="Tanggal" HeaderText="Tanggal Absen" DataFormatString="{0:dd/MM/yyyy}" />
    </Columns>
    </asp:GridView>
    <br />
    <asp:GridView ID="gvAttendanceTable" runat="server" AutoGenerateColumns="True"></asp:GridView>
    <br />
    <asp:GridView ID="gvMonthlyAttendance" runat="server" AutoGenerateColumns="True"></asp:GridView>
    <br />
    <asp:Button ID="btnAbsen" runat="server" Text="Absen Form" OnClick="btnAbsen_Click" />
    </div>
    </form>
</body>
</html>
