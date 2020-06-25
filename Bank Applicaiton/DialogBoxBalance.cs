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
    public partial class DialogBoxBalance : Form
    {
        public int index;

        public DialogBoxBalance()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 myForm2 = new Form2();
            myForm2.Visible = true;
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
                    textBox1.Text = Convert.ToString(Form1.CustomerArray[index].CheckingBal);
                    Form2.isCheckingAcount = true;
                }
                else if (Convert.ToString(comboBox1.Text) == "Saving  : " + Form1.CustomerArray[index].SavingNum)
                {
                    textBox1.Text = Convert.ToString(Form1.CustomerArray[index].SavingBal);
                    Form2.isSavingAcount = true;
                }

                //print a receipt for the transaction
                Form3 myForm3 = new Form3();
                myForm3.Visible = true;
            }


        }

        private void DialogBoxBalance_Load(object sender, EventArgs e)
        {
            index = Form1.customerIndex;
            comboBox1.Items.Add("Cheking : " + Form1.CustomerArray[index].CheckingNum);
            comboBox1.Items.Add("Saving  : " + Form1.CustomerArray[index].SavingNum);
        }


        public bool IsValidData()
        {
            return
            Validator.IsComboPresent(comboBox1, "Account number");
        }

    }//end of class
}