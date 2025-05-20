using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildUserData();
            if (IsPostBack)
            {
                BuildUserData();
            }
        }
        private void BuildUserData()
        {
            string queryUser = $"SELECT * FROM users";
            var cmd = new CRUD_Command();
            var data = cmd.SelectComand(queryUser);
        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            var cmd = new CRUD_Command();

            try
            {
                if (string.IsNullOrEmpty(txt_idcard.Text))
                {
                    return;
                }

                string queryUser = $"SELECT u.Id_Card, u.firstname, u.lastname, p.Position_Id " +
                                        $"FROM users as u " +
                                        $"Join positions as p ON u.Position_Id = p.Position_Id " +
                                        $"WHERE Id_Card = '{txt_idcard.Text}' AND passwords = '{pass_password.Text}'";

                var dtUser = cmd.SelectComand(queryUser);

                if (dtUser.Rows.Count > 0)
                {
                    // store user Session
                    Session["user"] = dtUser;

                    // insert login datetime
                    var userId = txt_idcard.Text;
                    var login_datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));

                    string queryhader = @"insert into login (login_time,
                                                    Id_Card)";
                    string valuesinsert = $"values('{login_datetime}' , {userId})";

                    string queryfull = queryhader + valuesinsert;

                    //var login = cmd.Insert_Update_Command(queryfull);


                    if (dtUser.Rows.Count > 0)
                    //if (dtUser.Rows.Count > 0 && login > 0)
                    {
                        string userPosition = dtUser.Rows[0]["Position_Id"].ToString(); ;
                        if (userPosition == "1")
                        {
                            Response.Redirect("~/Page_Client/AddBookDetail.aspx");
                        }
                        else if (userPosition == "2")
                        {
                            Response.Redirect("~/Page_Employee/AddLocation.aspx");
                        }
                        else if (userPosition == "3")
                        {
                            Response.Redirect("~/Page_Employee/ManageBookingList.aspx");
                        }
                        else if (userPosition == "4")
                        {
                            Response.Redirect("~/Page_Employee/ManageBookingAdmin.aspx");
                        }

                    }
                }
                else
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Login Failed', " +
                                                           $"text: 'Invalid ID or Password', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Login/Login.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}