using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Oracle.DataAccess.Client;


public partial class DTG_ASSETS : System.Web.UI.Page
{
    string dateToday = "";
    string userName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string host = HttpContext.Current.Request.Url.Host;

        if ((string)(Session["abc"]) == "" || Session["abc"] == null)
            Response.Redirect("DTG_Login.aspx");
        

        if (Session["staff_no"] != null)
            userName = (string)(Session["staff_no"]);
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_Ora"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            Console.WriteLine("State: {0}", connection.State);
            Console.WriteLine("ConnectionString: {0}", connection.ConnectionString);
            OracleCommand command = connection.CreateCommand();
            OracleCommand command1 = connection.CreateCommand();
            string sqlSysdate = "select to_char(sysdate,'dd-MON-yyyy') Today from dual";
            command1.CommandText = sqlSysdate;
            OracleDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                dateToday = reader["Today"].ToString();
            }
            connection.Close();
        }
        if (!IsPostBack)
        {
            fill_pono();
            fill_asset_id();
            fill_employees();
            fill_employee_id();
            fill_TYPE();
        }

    }
    protected void main_list_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (main_list.SelectedValue == "0")
        {
            master_panel.Visible = true;
            assign_panel.Visible = false;
            retreived_panel.Visible = false;
            main_panel.Visible = true;
            report_panel.Visible = false;
        }
        if (main_list.SelectedValue == "1")
        {
            assign_panel.Visible = true;
            main_panel.Visible = true;
            master_panel.Visible = false;
            retreived_panel.Visible = false;
            report_panel.Visible = false;
        }
        if (main_list.SelectedValue == "2")
        {
            master_panel.Visible = false;
            assign_panel.Visible = false;
            retreived_panel.Visible = true;
            main_panel.Visible = true;
            report_panel.Visible = false;

        }
        if (main_list.SelectedValue == "3")
        {
            master_panel.Visible = false;       
            assign_panel.Visible = false;
            retreived_panel.Visible = false;
            main_panel.Visible = true;
            report_panel.Visible =true;
            grid_report();
        }
    }
    protected void fill_pono()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command1 = connection.CreateCommand();
            string sqlquery = "select distinct order_no, order_no || ' - ' || desc1 || ' - '  || vend_name order_det, order_dt from mm.order_details where contract_no like 'OA_%' order by order_dt desc";
            command1.CommandText = sqlquery;
            OracleDataAdapter adap = new OracleDataAdapter(sqlquery, connection);
            DataSet dsVendor = new DataSet();
            adap.Fill(dsVendor, "dkljd");
            drp_po_no.DataSource = dsVendor;
            drp_po_no.DataValueField = "order_no";
            drp_po_no.DataTextField = "order_det";
            drp_po_no.DataBind();
            drp_po_no.Items.Insert(0, new ListItem("--Select--", "0"));
            connection.Close();
        }
    }
    protected void fill_TYPE()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command1 = connection.CreateCommand();
            string sqlquery = "select TYPE,TYPE_NAME from DTG_ASSET_TYPE_MASTER;";
            command1.CommandText = sqlquery;
            OracleDataAdapter adap = new OracleDataAdapter(sqlquery, connection);
            DataSet dsVendor = new DataSet();
            adap.Fill(dsVendor, "dkljd");
            drp_type.DataSource = dsVendor;
            drp_type.DataValueField = "TYPE";
            drp_type.DataTextField = "TYPE_NAME";
            drp_type.DataBind();
            drp_type.Items.Insert(0, new ListItem("--Select--", "0"));
            connection.Close();
        }
    }
    protected void Submit_Button_Click(object sender, EventArgs e)
    {
        long max_record_ID = 0;
        int var = 1;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command1 = connection.CreateCommand();
            OracleCommand cmd_recordid = connection.CreateCommand();

            string sql_Max_RecId = "select nvl(max(record_id),0) max_RecordId from DTG_ASSETS_MASTER";
            cmd_recordid.CommandText = sql_Max_RecId;
            OracleDataReader reader = cmd_recordid.ExecuteReader();
            while (reader.Read())
            {
                max_record_ID = long.Parse(reader["max_RecordId"].ToString()) + 1;
            }

            string sqlquery = "insert into DTG_ASSETS_MASTER (DTG_ASSET_ID,SL_NO,TYPE,PO_NO,record_id,DETAILS,STOCK_FLAG) values (:P_DTG_ASSET_ID, :P_SL_NO,:P_TYPE,:P_PO_NO,:P_record_id,:P_DETAILS,:P_STOCK_FLAG)";
            command1.CommandText = sqlquery;
            command1.Parameters.Add("P_DTG_ASSET_ID", asset_id1.Text.ToString());
            command1.Parameters.Add("P_SL_NO", serial_no1.Text.ToString());
            //command1.Parameters.Add("P_TYPE", int.Parse(type_no.SelectedValue.ToString()));
            command1.Parameters.Add("P_TYPE", drp_type.SelectedValue.ToString());
            command1.Parameters.Add("P_PO_NO", drp_po_no.SelectedValue.ToString());
            command1.Parameters.Add("record_id", max_record_ID);
            //command1.Parameters.Add("P_STOCK_FLAG", stock_flag.Text.ToString());
            //command1.Parameters.Add("P_RECORD_ID", record_id.Text.ToString());
            //command1.Parameters.Add("P_CREATED_BY", created_by.Text.ToString());
            //command1.Parameters.Add("P_CREATION_DATE", dateToday);
            //command1.Parameters.Add("P_ISACTIVE", is_active.Text.ToString());
            command1.Parameters.Add("P_DETAILS", details.InnerText.ToString());
            command1.Parameters.Add("P_STOCK_FLAG", var);
            command1.ExecuteNonQuery();
            connection.Close();
        }

       ScriptManager.RegisterStartupScript(this, this.GetType(), "red‌​irect", "alert('Details Saved'); window.location='" + Request.ApplicationPath + "DTG_ASSETS.aspx';", true);
    }
    protected void fill_asset_id()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command1 = connection.CreateCommand();
            string sqlquery = "select DTG_ASSET_ID from DTG_ASSETS_MASTER where stock_flag=1";
            command1.CommandText = sqlquery;
            OracleDataAdapter adap = new OracleDataAdapter(sqlquery, connection);
            DataSet dsVendor = new DataSet();
            adap.Fill(dsVendor, "dkljd");
            asset_id2.DataSource = dsVendor;
            asset_id2.DataValueField = "";
            asset_id2.DataTextField = "DTG_asset_id";
            asset_id2.DataBind();
            asset_id2.Items.Insert(0, new ListItem("--Select--", "0"));
            connection.Close();
        }
    }
    protected void get_slno_OnClick(object sender, EventArgs e)
    {


        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command1 = connection.CreateCommand();
            string sqlquery = "select SL_NO slno from DTG_ASSETS_MASTER where DTG_ASSET_ID='" + asset_id2.SelectedItem.Text.ToString() + "' ";
            command1.CommandText = sqlquery;
            OracleDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                serial_no2.Text = reader["slno"].ToString();
            }

            connection.Close();
        }
    }
    protected void fill_employees()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command1 = connection.CreateCommand();
            string sqlquery = "select * from adm.fts_emplist_all";
            command1.CommandText = sqlquery;
            OracleDataAdapter adap = new OracleDataAdapter(sqlquery, connection);
            DataSet dsVendor = new DataSet();
            adap.Fill(dsVendor, "dkljd");
            drp_employees.DataSource = dsVendor;
            drp_employees.DataValueField = "STAFF_NO";
            drp_employees.DataTextField = "EMP";
            drp_employees.DataBind();
            drp_employees.Items.Insert(0, new ListItem("--Select--", "0"));
            connection.Close();
        }
    }
    protected void assign_OnClick(object sender, EventArgs e)
    {
        long max_record_ID = 0;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            int x = 0;
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command1 = connection.CreateCommand();
            OracleCommand command2 = connection.CreateCommand();
            OracleTransaction transaction;

            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            command1.Transaction = transaction;
            command2.Transaction = transaction;
            OracleCommand cmd_recordid = connection.CreateCommand();

            string sql_Max_RecId = "select nvl(max(record_id),0) max_RecordId from DTG_ASSETS_ASSIGN";
            cmd_recordid.CommandText = sql_Max_RecId;
            OracleDataReader reader = cmd_recordid.ExecuteReader();
            while (reader.Read())
            {
                max_record_ID = long.Parse(reader["max_RecordId"].ToString()) + 1;
            }
            //string sqlquery = "insert into DTG_ASSETS_ASSIGN (DTG_ASSET_ID,SL_NO) values (:P_DTG_ASSET_ID, :P_SL_NO)";
            string sqlquery = "update DTG_ASSETS_MASTER SET STOCK_FLAG=:P_STOCK_FLAG where DTG_ASSET_ID='" + asset_id2.SelectedItem.Text.ToString() + "'";
            command1.CommandText = sqlquery;
            command1.Parameters.Add("P_STOCK_FLAG", x);
            command1.ExecuteNonQuery();

            string sqlquery_1 = "insert into DTG_ASSETS_ASSIGN (DTG_ASSET_ID,SL_NO,STAFF_NO_ASSIGN_TO,CREATED_BY,creation_date,ASSIGNED_DATE,RETREIVED_FLAG,RETREIVED_DATE,RECORD_ID)" +
                "values (:P_DTG_ASSET_ID,:P_SL_NO,:P_STAFF_NO_ASSIGN_TO,:P_CREATED_BY,:P_CREATION_DATE,:P_ASSIGNED_DATE,:P_RETREIVED_FLAG,:P_RETREIVED_DATE,:P_RECORD_ID)";
            command2.CommandText = sqlquery_1;
            command2.Parameters.Add("P_DTG_ASSET_ID", asset_id2.SelectedItem.Text.ToString());
            command2.Parameters.Add("P_SL_NO", serial_no2.Text.ToString());
            command2.Parameters.Add("P_STAFF_NO_ASSIGN_TO", int.Parse(drp_employees.SelectedValue));
            command2.Parameters.Add("P_CREATED_BY", userName);
            command2.Parameters.Add("P_CREATION_DATE", dateToday);
            command2.Parameters.Add("P_ASSIGNED_DATE", dateToday);
            command2.Parameters.Add("P_RETREIVED_FLAG", x);
            command2.Parameters.Add("P_RETREIVED_DATE", null);
            command2.Parameters.Add("P_RECORD_ID", max_record_ID);
            command2.ExecuteNonQuery();
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "red‌​irect", "alert('Details Saved'); window.location='" + Request.ApplicationPath + "DTG_ASSETS.aspx';", true);
    }
    protected void fill_employee_id()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command1 = connection.CreateCommand();
            string sqlquery = "select distinct STAFF_NO_ASSIGN_TO, adm.emp_all(staff_no_assign_to) Details FROM DTG_ASSETS_ASSIGN where retreived_flag =0";
            OracleDataAdapter adap = new OracleDataAdapter(sqlquery, connection);
            DataSet dsVendor = new DataSet();
            adap.Fill(dsVendor, "dkljd");
            drp_employee_id.DataSource = dsVendor;
            drp_employee_id.DataValueField = "STAFF_NO_ASSIGN_TO";
            drp_employee_id.DataTextField = "Details";
            drp_employee_id.DataBind();
            drp_employee_id.Items.Insert(0, new ListItem("--Select--", "0"));
            // loadDTGgrid();
            connection.Close();
        }
    }
    protected void retreive_btn_click(object sender, EventArgs e)
    {

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            int x = 1;
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command1 = connection.CreateCommand();

            OracleCommand command3 = connection.CreateCommand();
            OracleTransaction transaction;

            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            command1.Transaction = transaction;
            command3.Transaction = transaction;

            foreach (GridViewRow rowOfMyGridView in employee_gird.Rows)
            {
                long recordIDMaster = long.Parse(rowOfMyGridView.Cells[1].Text.ToString());
                long recordIDAssign = long.Parse(rowOfMyGridView.Cells[2].Text.ToString());
                CheckBox check = (CheckBox)rowOfMyGridView.Cells[0].FindControl("CheckBox");
                if (check.Checked)
                {
                    string sqlquery = "update DTG_ASSETS_ASSIGN SET RETREIVED_FLAG=:P_RETREIVED_FLAG where STAFF_NO_ASSIGN_TO=" + drp_employee_id.SelectedValue + " and record_id = " + recordIDAssign + "";
                    command1.CommandText = sqlquery;
                    command1.Parameters.Add("P_RETREIVED_FLAG", x);
                    command1.ExecuteNonQuery();
                    string sqlquery2 = "update DTG_ASSETS_MASTER SET STOCK_FLAG=:P_STOCK_FLAG where record_id = " + recordIDMaster + " ";
                    command3.CommandText = sqlquery2;
                    command3.Parameters.Add("P_STOCK_FLAG", 1);
                    command3.ExecuteNonQuery();

                    try
                    {
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }


            }
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "red‌​irect", "alert('Details Retreived'); window.location='" + Request.ApplicationPath + "DTG_ASSETS.aspx';", true);
    }
    protected void assigned_details_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            OracleCommand command4 = connection.CreateCommand();
            string sqlquery_1 = "select distinct b.DTG_ASSET_ID, b.SL_NO, b.TYPE, b.record_id recIDMaster, a.record_id recIDAss, b.po_no from DTG_ASSETS_ASSIGN a, DTG_ASSETS_MASTER b where a.staff_no_assign_to=" + drp_employee_id.SelectedValue + " and a.RETREIVED_FLAG = 0 and a.DTG_ASSET_ID=b.DTG_ASSET_ID ";
            OracleDataAdapter adap = new OracleDataAdapter(sqlquery_1, connection);
            DataSet dsGrid = new DataSet();
            dsGrid.Reset();
            adap.Fill(dsGrid);
            employee_gird.DataSource = null;
            employee_gird.DataBind();
            employee_gird.DataSource = dsGrid;
            employee_gird.DataBind();
            employee_panel.Visible = true;
            connection.Close();
        }

    }
    protected void grid_report()
    {

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionISG_TRAINEE"].ConnectionString;
        using (OracleConnection connection = new OracleConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
          //  if ("RETERIVED_FLAG"==1)
            //{
                string sqlquery = "select DTG_ASSET_ID,SL_NO,STAFF_NO_ASSIGN_TO,ASSIGNED_DATE FROM dtg_assets_assign";
                OracleDataAdapter adap = new OracleDataAdapter(sqlquery, connection);
                DataSet gridds = new DataSet();
                gridds.Reset();
                adap.Fill(gridds);
                report_grid.DataSource = null;
                report_grid.DataBind();
                report_grid.DataSource = gridds;
                report_grid.DataBind();
              //  }
            connection.Close();
        }
    }
}
