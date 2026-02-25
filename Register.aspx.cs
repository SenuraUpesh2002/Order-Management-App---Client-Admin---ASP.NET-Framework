using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OrderManagementApp
{
    public partial class Register : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {

            RegisterDAL obj = new RegisterDAL();
            bool result = obj.RegisterUser(
                txtName.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPassword.Text.Trim()


                
            );

            if (result)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Registration Successful!";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Registration Failed!";
            }
        }

    }

    
}