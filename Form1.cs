using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace oke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshow.Checked)
            {
                txtPassApp.PasswordChar = '\0';
                cbshow.Text = "Hide";
            }
            else
            {
                txtPassApp.PasswordChar = '*';
                cbshow.Text = "Show";
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            try
            {
                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(txtMyMail.Text, txtPassApp.Text);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(txtMyMail.Text);
                        mail.To.Add(txtMail.Text);
                        mail.Subject = txtName.Text + "-" + txtMssv.Text;
                        mail.Body = txtBody.Text;
                        mail.IsBodyHtml = false;

                        client.Send(mail);
                        MessageBox.Show("Email đã được gửi thành công đến " + txtMail.Text);
                    }
                }
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
    
}
