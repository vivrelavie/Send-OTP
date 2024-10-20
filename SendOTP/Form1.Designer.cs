namespace SendOTP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtEmail = new TextBox();
            btnSendOTP = new Button();
            label1 = new Label();
            btnSendTicket = new Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(167, 126);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(464, 27);
            txtEmail.TabIndex = 0;
            // 
            // btnSendOTP
            // 
            btnSendOTP.BackColor = Color.White;
            btnSendOTP.Location = new Point(167, 235);
            btnSendOTP.Name = "btnSendOTP";
            btnSendOTP.Size = new Size(164, 64);
            btnSendOTP.TabIndex = 1;
            btnSendOTP.Text = "Send OTP";
            btnSendOTP.UseVisualStyleBackColor = false;
            btnSendOTP.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(373, 84);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 2;
            label1.Text = "email";
            // 
            // btnSendTicket
            // 
            btnSendTicket.BackColor = Color.White;
            btnSendTicket.Location = new Point(473, 235);
            btnSendTicket.Name = "btnSendTicket";
            btnSendTicket.Size = new Size(158, 64);
            btnSendTicket.TabIndex = 3;
            btnSendTicket.Text = "Send Ticket";
            btnSendTicket.UseVisualStyleBackColor = false;
            btnSendTicket.Click += btnSendTicket_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSendTicket);
            Controls.Add(label1);
            Controls.Add(btnSendOTP);
            Controls.Add(txtEmail);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private Button btnSendOTP;
        private Label label1;
        private Button btnSendTicket;
    }
}
