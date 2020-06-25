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
    public partial class Form3 : Form
    {
        public int index = Form1.customerIndex;
        public string amount;

        string cheching4digits = "****";
        string saving4digits = "****";

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string checkingNum = Form1.CustomerArray[index].CheckingNum.ToString();
            string savingNum = Form1.CustomerArray[index].SavingNum.ToString();

            //only retrieve last 4 digits and ...
            for (int i = 4; i <= 7; i++)
            {
                cheching4digits += checkingNum[i];  //...concatenate it to the checking4digits
                saving4digits += savingNum[i];  //....concatenate it to the saving4digits
            }

            if (Form2.isCheckingAcount)
            {
                amount = DialogBoxFunds.signC + Form2.amount;
                //create listView and add first item which is checking
                ListViewItem lView = new ListViewItem("Checking");

                //add second item which is userId to the listView
                lView.SubItems.Add(Form1.CustomerArray[index].UserId.ToString());

                //add third item which is checking4digits to the listView
                lView.SubItems.Add(cheching4digits);

                //add fourth item which is amount to the listView
                lView.SubItems.Add(amount);

                //add fifth item which is balance to the listView
                lView.SubItems.Add(Form1.CustomerArray[index].CheckingBal.ToString());

                //Finaly add this listView to the overall listView
                listView1.Items.Add(lView);
            }
            if (Form2.isSavingAcount)
            {
                amount = DialogBoxFunds.signS + Form2.amount;

                //create listView and add first item which is saving
                ListViewItem lView1 = new ListViewItem("Saving");

                //add second item which is userId to the listView
                lView1.SubItems.Add(Form1.CustomerArray[index].UserId.ToString());

                //add third item which is saving4digits to the listView
                lView1.SubItems.Add(saving4digits);

                //add fourth item which is amount to the listView
                lView1.SubItems.Add(amount);

                //add fifth item which is balance to the listView
                lView1.SubItems.Add(Form1.CustomerArray[index].SavingBal.ToString());

                //Finaly add this listView to the overall listView
                listView1.Items.Add(lView1);
            }
        }
    }
}
