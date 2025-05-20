using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental
{
    public partial class Employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildUserData();
        }
        private void BuildUserData()
        {
            // retrieve user Session
            var user = (DataTable)Session["user"];
            string userid = user.Rows[0]["Id_Card"].ToString();

            string queryUser = $"SELECT * FROM users as u " +
                                        $"join positions as p " +
                                        $"WHERE Id_Card = {userid} " +
                                        $"and u.Position_Id = p.Position_Id;";
            var cmd = new CRUD_Command();
            var dtUser = cmd.SelectComand(queryUser);

            if (dtUser.Rows.Count > 0)
            {
                DataRow display = dtUser.Rows[0];
                firstname.Text = display["firstname"].ToString();
                position.Text = display["title"].ToString();
            }

        }

        protected void logout_button_Click(object sender, EventArgs e)
        {
            // retrieve user Session
            var user = (DataTable)Session["user"];
            string userid = user.Rows[0]["Id_Card"].ToString();

            LogUserLogout(userid);

            Response.Redirect("~/Page_Login/Login.aspx");
        }

        private void LogUserLogout(string userId)
        {
            var cmd = new CRUD_Command();
            var logout_datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
            string updateLogout = $@"UPDATE login 
                                            SET logout_time = '{logout_datetime}' 
                                            WHERE Id_Card = {userId}";

            var resultUpdate_Logout = cmd.Insert_Update_Command(updateLogout);
        }
    }
}