using System;
using System.Collections.Generic;
using InspireEventsEntry.UserServiceReference;

namespace InspireEventsEntry
{
    public partial class _Default : System.Web.UI.Page
    {
        public int SelectedLogin { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                { 
                    UserServiceContractClient client = new UserServiceContractClient();
                    List<User> users = client.GetUsers();
                    this.DdlUsers.DataSource = users;
                    this.DdlUsers.DataBind();
                }
            }
               

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserServiceContractClient client = new UserServiceContractClient();
            List<User> users = client.GetUsers();
            User user = users[this.DdlUsers.SelectedIndex];
       
            if (!string.IsNullOrEmpty(this.TbPassword.Text))
            {

                user.Password = this.TbPassword.Text;               

                if (client.LoginAttempt(user.Login, user.Password))
                {
                    this.LblFail.Visible = false;
                    base.Response.Redirect("Events.aspx");
                }
                else
                {
                    this.LblFail.Visible = true;
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.DdlUsers.Items.Count > 0)
            {
                this.DdlUsers.SelectedIndex = 0;
            }
            this.TbPassword.Text = string.Empty;
        }

     }
}