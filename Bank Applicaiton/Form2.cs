using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmeenaC_sharp2
{
    public partial class Form2 : Form
    {
        public static bool isCheckingAcount = false, isSavingAcount = false;
        public static string amount = "";

        DialogBoxDeposit dialogDeposit = new DialogBoxDeposit();
        DialogBoxWithdrawal dialogWithdrawal = new DialogBoxWithdrawal();
        DialogBoxBalance dialogBalance = new DialogBoxBalance();
        DialogBoxFunds dialogFunds = new DialogBoxFunds();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Visible = false;
            dialogDeposit.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Visible = false;
            dialogWithdrawal.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.Visible = false;
            dialogBalance.Visible = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.Visible = false;
            dialogFunds.Visible = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you willing to log out?", "return to login screen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                Form1 myForm1 = new Form1();
                myForm1.Visible = true;
            }
            else
            {
                this.Close();
                Form2 myForm2 = new Form2();
                myForm2.Visible = true;
            }

        }

    }//end of class

}//end of namespace
