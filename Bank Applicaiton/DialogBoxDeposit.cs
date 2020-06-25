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
    public partial class DialogBoxDeposit : Form
    {
        public int index;

        public DialogBoxDeposit()
        {
            InitializeComponent();
        }

        private void DialogBoxDeposit_Load(object sender, EventArgs e)
        {
            index = Form1.customerIndex;
            comboBox1.Items.Add("Cheking : " + Form1.CustomerArray[index].CheckingNum);
            comboBox1.Items.Add("Saving  : " + Form1.CustomerArray[index].SavingNum);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public bool IsValidData()
        {
            return
            Validator.IsComboPresent(comboBox1, "Account number") &&
            Validator.IsPresent(textBox1, "Deposit Amount") &&
            Validator.IsInt32(textBox1, "Deposit Amount");
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
                    Form1.CustomerArray[index].CheckingBal += Convert.ToInt32(textBox1.Text);
                    Form2.amount = "+" + textBox1.Text;//save the amount of transaction
                    Form2.isCheckingAcount = true;
                }
                else if (Convert.ToString(comboBox1.Text) == "Saving  : " + Form1.CustomerArray[index].SavingNum)
                {
                    Form1.CustomerArray[index].SavingBal += Convert.ToInt32(textBox1.Text);
                    Form2.amount = "+" + textBox1.Text;
                    Form2.isSavingAcount = true;
                }

                //print a receipt for the transaction
                Form3 myForm3 = new Form3();
                myForm3.Visible = true;
            }
        }

        //button2= return to main menu
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 myForm2 = new Form2();
            myForm2.Visible = true;
        }

    }//end of class
}//end of spacename
