using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Activated += AfterLoading;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyPush(0, true);
            Application.ExitThread();
            this.Close();
        }

        public void AfterLoading(object sender, EventArgs e)
        {
            this.Activated -= AfterLoading;
            Trigger();
        }
        private void Trigger()
        {
            TargetBox();
            WriteText();
        }
        private void TargetBox()
        {
            this.richTextBox1.Select();
        }
        private void WriteText()
        {
            KeyPush(1, false);
        }

        private void KeyPush(int value, bool shutdown)
        {
            try
            {
                if (shutdown)
                {
                    SendKeys.Flush();
                    //Application.ExitThread();
                    this.Close();
                }
                else
                {
                    if (value <= 100)
                    {
                        SendKeys.SendWait("Work ");
                        value++;
                    }
                    else if (value > 100)
                    {
                        value = 1;
                        this.richTextBox1.Clear();
                    }
                }

                KeyPush(value, shutdown);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
