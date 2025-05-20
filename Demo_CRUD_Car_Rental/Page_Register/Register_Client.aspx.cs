using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Register
{
    public partial class Register_Client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_button_Click(object sender, EventArgs e)
        {
            var id = txt_idcard.Text;
            var firstname = this.txt_firstname.Text;
            var lastname = this.txt_lastname.Text;
            var email = mail_email.Text;
            var password = pass_password.Text;
            var address = txt_address.Text;
            var phones = tel_phone.Text;
            int position = 1;

            //string idPattern = @"^[0-9]{13}$";
            //if (!System.Text.RegularExpressions.Regex.IsMatch(id, idPattern))
            //{
            //    string sweetAlertScript = $"Swal.fire({{ title: 'Invalid ID Card Number', " +
            //                                            $"text: 'ID Card must be 13 numbers', " +
            //                                            $"icon: 'error', confirmButtonText: 'OK' }});";
            //    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
            //    return;
            //}

            string phonePattern = @"^[0-9]{10}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(phones, phonePattern))
            {
                string sweetAlertScript = $"Swal.fire({{ title: 'Invalid Phone Number', " +
                                                        $"text: 'Phone number must be 10 digits', " +
                                                        $"icon: 'error', confirmButtonText: 'OK' }});";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                return; 
            }

            var cmd = new CRUD_Command();

            string queryAccount = $"SELECT * FROM users WHERE Id_Card = {id}";
            var dtAccount = cmd.SelectComand(queryAccount);

            try
            {

                if (dtAccount.Rows.Count > 0)
                {
                    string dataAccount = dtAccount.Rows[0]["Id_Card"].ToString();

                    if (dataAccount == txt_idcard.Text)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Registered Account Failed', " +
                                                               $"text: 'Duplicate ID Card', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Register/Register_Client.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                }
                else
                {
                    string queryHeader = @"INSERT INTO users (Id_Card,
                                                passwords,
                                                firstname,
                                                lastname,
                                                email,
                                                address,
                                                phone,
                                                Position_Id)";
                    string valuesInsert = $"VALUES({id}, '{password}', '{firstname}', '{lastname}', '{email}', '{address}', '{phones}', {position})";
                    string queryFull = queryHeader + valuesInsert;

                    var result = cmd.Insert_Update_Command(queryFull);

                    if (result > 0)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Registered Account', " +
                                                              $"text: 'Success', " +
                                                              $"icon: 'success', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Login/Login.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Registered Account Failed', " +
                                                               $"text: 'Failed', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Register/Register_Client.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}