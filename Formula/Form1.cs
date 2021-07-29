using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formula
{
    public partial class Form1 : Form
    {
        string st;
        public Form1()
        {
            InitializeComponent(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            st = textBox1.Text;
            FORMULA m=new FORMULA(st);
            if (st.Length != 0)
                if (m.IsFormula())
                    label1.Text = "IT'S  A  FORMULA";
                else
                    label1.Text = "IT'S  NOT  A  FORMULA";
            else
                label1.Text = "INSERT THE FORMULA!";
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "";
        }
    }
}
