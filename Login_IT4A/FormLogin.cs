using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_IT4A
{
    public partial class FormLogin : Form
    {
        private User admin = new User("admin", "password");

        //private string username = "admin";
        //private string password = "password";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == admin.Name && txtPassword.Text == admin.Password)
            {
                var mainForm = new FormMain(admin);
                mainForm.Show(this);
                Hide();
            }
            else
            {
                MessageBox.Show("Username or password incorrect.");
            }
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogIn.PerformClick();
            }
        }
    }
}
