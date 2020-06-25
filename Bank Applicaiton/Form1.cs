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
    public partial class Form1 : Form
    {
        //crate an object of type form2
        Form2 myForm2 = new Form2();

        //make array for 4 customers
        public static Customer[] CustomerArray = new Customer[4]
        {
           new Customer ("Customer1", 1111,11111111,11111110, 1000,1000 ),
           new Customer ("Customer2", 2222,22222222,22222220, 2000,2000),
           new Customer ("Customer3", 3333,33333333,33333330, 3000,3000 ),
           new Customer ("Customer4", 4444,44444444,44444440, 4000,4000 )
        };

        public static int attempt = 0; //this will record the number of attempts
        public static int customerIndex = 0; //this will keep track of the user index from the customerArray to others forms

        public Form1()
        {
            InitializeComponent();
            textBox3.PasswordChar = '*';
            textBox3.MaxLength = 4; //only 4 digits      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        //if any changes on the textbox2(userId) and...
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "ADMIN")//...the value entered=ADMIN, enable the login button
                button2.Enabled = true;
        }

        //clear button
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox2.Select();
        }

        //if we press the login button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    for (int i = 0; i < 4; i++)//look for the user or customer
                    {
                        if (CustomerArray[i].UserId == textBox2.Text && CustomerArray[i].Password == Convert.ToInt32(textBox3.Text))
                        {
                            customerIndex = i;//gets the user index from the array
                            this.Visible = false;// make this form invisible
                            myForm2.Visible = true;// lunch the next form= form2
                        }
                    }

                    // this is gets incremented whenever the user fails 
                    attempt++;

                    if (attempt == 4)
                    {
                        textBox4.Text = "PLEASE SEE A BANK OFFICER -- NO FURTHER LOGIN ATTEMPTS ALLOWED.";
                        button2.Enabled = false;
                        textBox2.Select();
                    }
                    else  // The password of the administrative to release the ATM is: 9999 
                    if (textBox2.Text == "ADMIN" && textBox3.Text == "9999")
                    {
                        attempt = 0;  //number of user's attempts starts over
                        textBox4.Text = "ADMINISTRATIVE RELEASE.";
                        textBox2.Select();//focus on userId textbox
                    }
                    else  // The password of admin to terminate the program is: 0000
                    if (textBox2.Text == "ADMIN" && textBox3.Text == "0000")
                    {
                        textBox4.Text = "";
                        DialogResult result = MessageBox.Show("Are you sure?", "Exiting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                            Application.Exit();// the program ends 
                    }
                    else
                    {
                        textBox4.Text = "Wrong User ID Or Password Try Again";
                        textBox2.Select();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Invalid numeric format. Please check all entries.", "Entry Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "Overflow error. Please enter smaller values.", "Entry Error");
            }
        }//end of button

        //this is the methode to validate the data
        public bool IsValidData()
        {
            return
                Validator.IsPresent(textBox2, "User ID") &&
                Validator.IsPresent(textBox3, "Password") &&
                Validator.IsInt32(textBox3, "Password");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }//end of class

}//end of namespace

