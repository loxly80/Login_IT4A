namespace Login_IT4A
{
    public partial class FormMain : Form
    {
        private bool closeAll;
        private Form startupForm;
        private User user;

        public FormMain(User user)
        {
            closeAll = true;
            this.user = user;
            InitializeComponent();
            lblLogin.Text = user.Name;
        }

        public void Show(Form startupForm)
        {
            this.startupForm = startupForm;
            Show();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (startupForm != null && closeAll)
            {
                startupForm.Close();
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            closeAll = false;
            startupForm.Show();
            Close();
        }

        private void btnUserEditor_Click(object sender, EventArgs e)
        {
            FormUserEditor formUserEditor = new FormUserEditor();
            formUserEditor.ShowDialog();
        }
    }
}