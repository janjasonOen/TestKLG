using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TugasKLG_OenJanJason.Model;

namespace TugasKLG_OenJanJason.Views
{
    public partial class viewAbsensi : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                BindGridViewTable();
                BindMonthlyAttendanceTable();
            }
        }

        private void BindGridView()
        {
            var query = from absen in db.Absens
                        join employee in db.Employees on absen.nik equals employee.nik
                        select new
                        {
                            NIK = absen.nik,
                            Nama = employee.nama,
                            Tanggal = absen.tanggal
                        };

            gvAttendanceList.DataSource = query.ToList();
            gvAttendanceList.DataBind();
        }

        private void BindGridViewTable()
        {
            var queryResults = (from absen in db.Absens
                                join employee in db.Employees on absen.nik equals employee.nik
                                select new
                                {
                                    NIK = absen.nik,
                                    Nama = employee.nama,
                                    Tanggal = absen.tanggal
                                }).ToList();

            var groupedResults = queryResults.GroupBy(item => new { item.NIK, item.Nama })
                                             .Select(group => new
                                             {
                                                 NIK = group.Key.NIK,
                                                 Nama = group.Key.Nama,
                                                 AbsenDates = group.Select(g => g.Tanggal.Date)
                                             }).ToList();

            var distinctDates = groupedResults.SelectMany(item => item.AbsenDates)
                                              .Distinct()
                                              .OrderBy(d => d)
                                              .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("NIK");
            dt.Columns.Add("Nama");
            foreach (var date in distinctDates)
            {
                dt.Columns.Add(date.ToString("dd-MM-yyyy"));
            }
            dt.Columns.Add("Total");

            foreach (var item in groupedResults)
            {
                DataRow row = dt.NewRow();
                row["NIK"] = item.NIK;
                row["Nama"] = item.Nama;

                foreach (var date in distinctDates)
                {
                    row[date.ToString("dd-MM-yyyy")] = item.AbsenDates.Contains(date) ? "X" : "";
                }

                row["Total"] = item.AbsenDates.Count();
                dt.Rows.Add(row);
            }

            gvAttendanceTable.DataSource = dt;
            gvAttendanceTable.DataBind();
        }

        private void BindMonthlyAttendanceTable()
        {
            var queryResults = (from absen in db.Absens
                                join employee in db.Employees on absen.nik equals employee.nik
                                select new
                                {
                                    NIK = absen.nik,
                                    Nama = employee.nama,
                                    Tanggal = absen.tanggal
                                }).ToList();

            if (queryResults.Any())
            {
                DateTime startDate = queryResults.Min(item => item.Tanggal.Date);
                DateTime endDate = queryResults.Max(item => item.Tanggal.Date);
                var filteredResults = queryResults.Where(item => item.Tanggal.Date >= startDate && item.Tanggal.Date <= endDate).ToList();
            }


            var groupedResults = queryResults.GroupBy(item => new { item.NIK, item.Nama })
                                             .Select(group => new
                                             {
                                                 NIK = group.Key.NIK,
                                                 Nama = group.Key.Nama,
                                                 AbsenDates = group.Select(g => g.Tanggal.Date)
                                             }).ToList();

            var distinctMonths = groupedResults.SelectMany(item => item.AbsenDates)
                                               .Select(date => new { Year = date.Year, Month = date.Month })
                                               .Distinct()
                                               .OrderBy(d => d.Year)
                                               .ThenBy(d => d.Month)
                                               .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("NIK");
            dt.Columns.Add("Nama");
            foreach (var month in distinctMonths)
            {
                dt.Columns.Add(month.Year + month.Month.ToString("00"));
            }
            dt.Columns.Add("Total");

            foreach (var item in groupedResults)
            {
                DataRow row = dt.NewRow();
                row["NIK"] = item.NIK;
                row["Nama"] = item.Nama;

                foreach (var month in distinctMonths)
                {
                    row[month.Year + month.Month.ToString("00")] = item.AbsenDates.Count(d => d.Year == month.Year && d.Month == month.Month);

                }

                row["Total"] = item.AbsenDates.Count();
                dt.Rows.Add(row);
            }

            gvMonthlyAttendance.DataSource = dt;
            gvMonthlyAttendance.DataBind();
        }


        protected void btnAbsen_Click(object sender, EventArgs e)
        {
            Response.Redirect("formAbsensi.aspx");
        }
    }
}