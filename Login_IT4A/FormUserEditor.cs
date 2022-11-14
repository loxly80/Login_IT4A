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
    public partial class FormUserEditor : Form
    {
        SqlRepository sqlRepository;
        private List<User> users;

        public FormUserEditor()
        {
            InitializeComponent();
            sqlRepository = new SqlRepository();
        }

        private void LoadData()
        {
            users = sqlRepository.GetUsers(tsFind.Text);
            lvUsers.Items.Clear();
            foreach (var user in users)
            {
                lvUsers.Items.Add(user.ToListViewItem());
            }
        }

        private void FormUserEditor_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tsFind_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tsDeleteUser_Click(object sender, EventArgs e)
        {
            if(lvUsers.SelectedItems.Count > 0)
            {
                if(MessageBox.Show("Opravdu chcete smazat vybraného uživatele?","Mazání uživatele", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sqlRepository.DeleteUser(lvUsers.SelectedItems[0].SubItems[0].Text);
                    LoadData();
                }                
            }
            else
            {
                MessageBox.Show("Musíte vybrat uživatele ke smazání");
            }
        }

        private void tsAddUser_Click(object sender, EventArgs e)
        {
            FormUserEditorDialog formUserEditorDialog = new FormUserEditorDialog(null);
            var result = formUserEditorDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void tsChangePassword_Click(object sender, EventArgs e)
        {
            if(lvUsers.SelectedItems.Count > 0)
            {
                FormUserEditorDialog formUserEditorDialog = new FormUserEditorDialog(users[lvUsers.SelectedIndices[0]]);
                formUserEditorDialog.ShowDialog();
            }
            
        }
    }
}
