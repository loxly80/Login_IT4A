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
        SqlRepository sqlRepository;

        public FormLogin()
        {
            InitializeComponent();
            sqlRepository = new SqlRepository();
            sqlRepository.ConvertUsersToHashed();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            var user = sqlRepository.GetUser(txtUsername.Text.Trim());
            if (user != null)
            {
                if (user.VerifyPassword(txtPassword.Text))
                {
                    var mainForm = new FormMain(user);
                    mainForm.Show(this);
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    Hide();
                    return;
                }
            }
            MessageBox.Show("Username or password incorrect.");
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn.PerformClick();
            }
        }
    }
}
