namespace SendOTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string toEmail = txtEmail.Text;

            if (EmailUtility.IsValidEmail(toEmail))
            {
                EmailUtility.Otp otp = new EmailUtility.Otp(toEmail);
                otp.GenerateOtp();
            }
            else
            {
                MessageBox.Show("Invalid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendTicket_Click(object sender, EventArgs e)
        {
            string toEmail = txtEmail.Text;

            if (EmailUtility.IsValidEmail(toEmail))
            {
                EmailUtility.TicketPdf ticket = new EmailUtility.TicketPdf(toEmail);
                ticket.GenerateTicket("Stefanie");
            }
            else
            {
                MessageBox.Show("Invalid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}