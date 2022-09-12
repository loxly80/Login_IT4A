namespace Login_IT4A
{
    public partial class FormMain : Form
    {
        private Form startupForm;
        private User user;

        public FormMain(User user)
        {
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
            if(startupForm != null)
            {
                startupForm.Close();
            }
        }
    }
}