using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
       
        private void NumBtn_Click(object sender, EventArgs e)
        {
            // gets rid of the zero or infintie symbol prior to adding numbers
            if(display.Text == "0" || display.Text == "∞")
            {
                display.Clear();
            }
            display.Text += ((Button)sender).Text;
            
        }

        private void ClearEntryBtn_Click(object sender, EventArgs e)
        {
            // Clears the currently displayed value.
            display.Text = "0";
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Clear the display and any global variables
            // used in the calculation.

            display.Text = "0";
            
            leftOperand = 0.0;
            mathOperation = string.Empty;
            SetMathOpBtnSensitivity(true);
        }

        private void EqualsBtn_Click(object sender, EventArgs e)
        {
            // The actual math processing takes place here
            // after the user clicks equalsBtn
            // we match the operation that was on the button text
            // select what to do with the 2 operands
            // 1 - L value in leftOperand
            // 2 - the display's current Text property
            switch (mathOperation)
            {
                case "+":
                    display.Text = (leftOperand + double.Parse(display.Text)).ToString();
                    break;
                case "-":
                    display.Text = (leftOperand - double.Parse(display.Text)).ToString();
                    break;
                case "x":
                    display.Text = (leftOperand * double.Parse(display.Text)).ToString();
                    break;
                case "/":
                    display.Text = (leftOperand / double.Parse(display.Text)).ToString();
                    if (display.Text == "∞" || display.Text == "-∞")
                    {
                        display.Text ="Cannot divide by 0";
                    }
                    break;
                default:
                    // This code should be unreachable
                    MessageBox.Show("ERROR Something went wrong! CLose and restart the calculator.");
                    break;
            }
           
            SetMathOpBtnSensitivity(true);
        }

        
        private double leftOperand;
       
        private string mathOperation;
        private void mathOpBtn_Click(object sender, EventArgs e)
        {
            // Save the state that a math operation has started
            //startMathOperation = true;

            // We need to save the left operand.
            leftOperand = double.Parse(display.Text);

            // The operator/math operation being used
            mathOperation = ((Button)sender).Text;

            //clear the display for the next operand
            display.Clear();
            
            SetMathOpBtnSensitivity(false);
        
        }

        private void SetMathOpBtnSensitivity(bool sensitive)
        {
            addBtn.Enabled =  subtractBtn.Enabled = multiplyBtn.Enabled = divideBtn.Enabled = sensitive;
        }



        private void BackSpaceBtn_Click(object sender, EventArgs e)
        {
            // nominal case
            if (display.Text.Length > 1)
            {
                display.Text = display.Text.Substring(0, display.Text.Length - 1);

                // case where the operation above leaves a decimal point "."
                if (display.Text[display.Text.Length - 1] == '.')
                {
                    display.Text = display.Text.Substring(0, display.Text.Length - 1);
                }
            }
            else
            {
                // Otherwise, set the display back to 0.
                display.Text = "0";
            }
        }

        private void posNegBtn_Click(object sender, EventArgs e)
        {
            // To get the inverse, grab the current string from display,
            // parse into a number ,flip the sign, then call to string method.
            display.Text = (-double.Parse(display.Text)).ToString();
        }

        private void decimalPtBtn_Click(object sender, EventArgs e)
        {

            if (!display.Text.Contains("."))
            {
                // nominal case
                display.Text += ((Button)sender).Text;
            }
            // do nothing
        }
    }
}
