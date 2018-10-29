using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _041report_today : System.Web.UI.Page
    {
        // REPORT INFO
        string tnum { get; set; }
        DataTable TableA { get; set; }
        DataTable TableB { get; set; }

        DataTable TableC { get; set; }
        DataTable TableD { get; set; }

        DataTable TableE { get; set; }

        DataTable TableF { get; set; }
        DataTable TableG { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CsDailyReport TodayReport = new CsDailyReport(tnum, TableA, TableB, TableC, TableD, TableE,TableF, TableG);
                ConnectionClass.DisplayReport(TodayReport);

                ReportA.DataSource = TodayReport.aTable;
                ReportA.DataBind();

                ReportB.DataSource = TodayReport.bTable;
                ReportB.DataBind();


                ReportC.DataSource = TodayReport.cTable;
                ReportC.DataBind();



                ReportD.DataSource = TodayReport.dTable;
                ReportD.DataBind();

                ReportE.DataSource = TodayReport.fTable;
                ReportE.DataBind();




                ReportF.DataSource = TodayReport.gTable;
                ReportF.DataBind();
            



            }
            catch
            {

            }

            finally
            {

            }
            
        }

        protected void DetailReport1_Click(object sender, EventArgs e)
        {

        //    CsDailyReport TodayReport = new CsDailyReport(tnum, TableA, TableB, TableC, TableD, TableE, TableF, TableG);
        //    ConnectionClass.DisplayReport(TodayReport);

        //    if (BtnSwitch.Text == "DAILY")
        //    {

        //        ReportD.DataSource = TodayReport.eTable;
        //        ReportD.DataBind();
        //        BtnSwitch.Text = "CATEGORY";
        //    }

        //    else
        //    {
        //        ReportD.DataSource = TodayReport.dTable;
        //        ReportD.DataBind();
        //        BtnSwitch.Text = "DAILY";

        //    }
        }
    }
}