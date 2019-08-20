using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculationButton_Click(object sender, EventArgs e)
        {
            result.Text = new Reverse_Polish_Notation.RPN().Calculate(expression.Text).ToString();
        }
    }
}
