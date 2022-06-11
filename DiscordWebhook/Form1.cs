using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordWebhook
{
    public partial class Form1 : Form
    {
        bool spammer = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if(button1.Text == "Start")
            {
                if (textBox2.Text != "")
                { 
                    button1.Text = "Stop";
                    spammer = true;
                    timer1.Start(); 
                }
                else
                {
                    label4.Text = "Insert Massager";
                    label4.ForeColor = Color.Red;
                }
            }
            else if(button1.Text == "Stop")
            {
                label4.Text = "Stop...";
                label4.ForeColor = Color.Red;
                button1.Text = "Start";
                spammer = false;
                timer1.Stop();
            }
            else
            {
                button1.Text = "Error";
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (spammer && textBox2.Text != null)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.UploadString(textBox1.Text,
                            "{\"content\": \"" + textBox2.Text + "\" }");
                    }
                    label4.Text = "Running...";
                    label4.ForeColor = Color.Green;
                }
                catch (Exception)
                {
                    label4.Text = "Error Invalid Webhook";
                    label4.ForeColor = Color.Red;
                    button1.Text = "Start";
                    spammer = false;
                    timer1.Stop();
                }
            }
            else if (textBox2.Text == "")
            {
                    label4.Text = "Insert Massager";
                    label4.ForeColor = Color.Red; 
                    button1.Text = "Start";
                    spammer = false;
                    timer1.Stop();
            }
        }
    }
}
