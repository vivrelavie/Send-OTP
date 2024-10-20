using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SendOTP
{
    internal class EmailUtility
    {
        public abstract class Email
        {
            protected string FromEmail = "stefaniegabion111@gmail.com";
            protected string FromPassword = "jomd jhyk dkbt ombm";

            protected string Subject { get; set; }
            protected string Body { get; set; }
            protected string ToEmail { get; set; }

            protected MailMessage Mail = new MailMessage();

            public void CreateEmail()
            {
                Mail.From = new MailAddress(FromEmail);
                Mail.Subject = Subject;
                Mail.Body = Body;
                Mail.IsBodyHtml = true;
                Mail.To.Add(ToEmail);

                SendEmail(Mail);
            }

            public void SendEmail(MailMessage mail)
            {
                // Setup SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(FromEmail, FromPassword),
                    EnableSsl = true,
                };

                try
                {
                    smtpClient.Send(mail);
                    MessageBox.Show("Email sent successfully.", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Failed to send email: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public class Otp : Email
        {
            public Otp(string email)
            {
                // Email Subject and Body
                Subject = "OTP Verification for Airplane Ticketing";
                Body = "<h1>Your OTP Code</h1><p>Your one-time password (OTP) is: <strong>123456</strong></p>";
                ToEmail = email;
            }

            public void GenerateOtp() //TODO: Generate email logic
            {
                /*
                 * Generate random 6 chars alphanumeric OTP 
                 */
                Body += "</br>Generated OTP HERE";
                CreateEmail();
            }
        }

        public class TicketPdf : Email
        {
            public TicketPdf(string toEmail)
            {
                // Email Subject and Body
                Subject = "Ticket for Airplane Ticketing";
                Body = "<h1>Your ticket</h1><p>Please find your airplane booking ticket attached.</p>";
                this.ToEmail = toEmail;
            }

            public void GenerateTicket(string user)
            {
                // File path for the generated PDF
                string pdfPath = Path.Combine(Environment.CurrentDirectory, "Certificate.pdf");

                // Create a new PDF document
                PdfWriter writer = new PdfWriter(pdfPath);
                PdfDocument pdf = new PdfDocument(writer);
                iText.Layout.Document document = new iText.Layout.Document(pdf);

                // Add content to the PDF
                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                document.Add(new Paragraph("Certificate of Achievement")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(24)
                    .SetFontColor(ColorConstants.BLUE)
                    .SetFont(font));

                document.Add(new Paragraph("This is to certify that")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(18));

                document.Add(new Paragraph(user)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(22)
                    .SetBold());

                document.Add(new Paragraph("has successfully completed the course.")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(18));

                document.Add(new Paragraph($"Date: {DateTime.Now:MMMM dd, yyyy}")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(14));

                document.Close();

                AttachTicket(pdfPath);
            }

            public void AttachTicket(string attachmentPath)
            {
                // Attach the generated ticket
                Attachment attachment = new Attachment(attachmentPath);
                Mail.Attachments.Add(attachment);

                CreateEmail();
            }
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                    RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
