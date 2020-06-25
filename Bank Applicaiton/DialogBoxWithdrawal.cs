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
    public partial class DialogBoxWithdrawal : Form
    {
        public int index;

        public DialogBoxWithdrawal()
        {
            InitializeComponent();
        }

        private void DialogBoxWithdrawal_Load(object sender, EventArgs e)
        {
            index = Form1.customerIndex;
            comboBox1.Items.Add("Cheking : " + Form1.CustomerArray[index].CheckingNum);
            comboBox1.Items.Add("Saving  : " + Form1.CustomerArray[index].SavingNum);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2.amount = "";
            Form2.isCheckingAcount = false;
            Form2.isSavingAcount = false;

            if (IsValidData())
            {
                if (Convert.ToString(comboBox1.Text) == "Cheking : " + Form1.CustomerArray[index].CheckingNum)
                {
                    if (Form1.CustomerArray[index].CheckingBal >= Convert.ToInt32(textBox1.Text))
                    {
                        Form1.CustomerArray[index].CheckingBal -= Convert.ToInt32(textBox1.Text);
                        Form2.amount = "-" + textBox1.Text;//save the amount of transaction
                        Form2.isCheckingAcount = true;

                        //print a receipt for the transaction
                        Form3 myForm3 = new Form3();
                        myForm3.Visible = true;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Unsuficient balance in your Cheking account!! ", "Status", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            this.Focus();
                        }
                    }
                }
                else if (Convert.ToString(comboBox1.Text) == "Saving  : " + Form1.CustomerArray[index].SavingNum)
                {
                    if (Form1.CustomerArray[index].SavingBal >= Convert.ToInt32(textBox1.Text))
                    {
                        Form1.CustomerArray[index].SavingBal -= Convert.ToInt32(textBox1.Text);
                        Form2.amount = "-" + textBox1.Text;
                        Form2.isSavingAcount = true;

                        //print a receipt for the transaction
                        Form3 myForm3 = new Form3();
                        myForm3.Visible = true;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Unsuficient balance in your saving account!! ", "Status", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            this.Focus();
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 myForm2 = new Form2();
            myForm2.Visible = true;
        }


        public bool IsValidData()
        {
            return
            Validator.IsComboPresent(comboBox1, "Account number") &&
            Validator.IsPresent(textBox1, "Withdraw Amount") &&
            Validator.IsInt32(textBox1, "Withdraw Amount");
        }

    }//end of class
}