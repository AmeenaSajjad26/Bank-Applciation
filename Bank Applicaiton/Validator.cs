using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmeenaC_sharp2
{
    public static class Validator
    {
        private static string title = "Entry Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public static bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
                return true;
            else
            {
                MessageBox.Show(name + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsComboPresent(ComboBox comboBox, string name)
        {
            if (comboBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", Title);
                comboBox.Focus();
                return false;
            }
            return true;
        }

    }//end of class
}//end of namespace

