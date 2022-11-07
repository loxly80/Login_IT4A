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
    public partial class FormUserEditorDialog : Form
    {
        private User? user;

        public FormUserEditorDialog(User? user)
        {
            InitializeComponent();
            this.user = user;
            if (user != null)
            {
                this.Text = "Úprava uživatele";
                btnSave.Text = "Uložit";
                txtUserName.Text = user.Name;
                txtUserName.ReadOnly = true;
            }
            else
            {
                this.Text = "Nový uživatel";
                btnSave.Text = "Vytvořit";
                txtUserName.ReadOnly= false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlRepository sqlRepository = new SqlRepository();
            if (user != null)
            {
                sqlRepository.SaveUser(user);
            }
            else
            {
                user = new User(txtUserName.Text, txtUserName.Text);
                sqlRepository.CreateUser(user);
            }
        }
    }
}
