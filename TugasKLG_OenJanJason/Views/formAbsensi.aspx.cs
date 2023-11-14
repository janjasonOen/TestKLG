using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using TugasKLG_OenJanJason.Model;

namespace TugasKLG_OenJanJason.Views
{
    public partial class formAbsensi : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var employees = db.Employees.ToList();

                ddlEmployee.DataSource = employees.Select(emp => new
                {
                    DisplayText = emp.nama + " - " + emp.nik,
                    Value = emp.nik
                });

                ddlEmployee.DataTextField = "DisplayText";
                ddlEmployee.DataValueField = "Value";
                ddlEmployee.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string selectedNIK = ddlEmployee.SelectedValue;
            DateTime selectedDate;
            if (DateTime.TryParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
            {
                db.Absens.AddObject(new Absen { nik = selectedNIK, tanggal = selectedDate });
                db.SaveChanges();
            }
            else
            {
                lblErrorMessage.Text = "Invalid date format. Please enter a valid date in the format dd/MM/yyyy.";
                lblErrorMessage.Visible = true;
            }
        }

        protected void btnViewData_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewAbsensi.aspx");
        }
    }
}
