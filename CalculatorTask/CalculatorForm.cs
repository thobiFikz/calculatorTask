using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalculatorTask
{
    public partial class CalculatorForm : Form
    {
        private double _currentValue = 0;
        private double _lastValue = 0;
        private Operation _currentOperation = null;
        private Dictionary<string, Operation> _operations;

        public CalculatorForm()
        {
            InitializeComponent();
            _operations = new Dictionary<string, Operation>
            {
                {"+", new Addition()},
                {"-", new Subtraction()},
                {"*", new Multiplication()},
                {"/", new Division()}
            };
        }

        private bool isNewEntry = true;

        private void DigitButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (isNewEntry || display.Text == "0")
            {
                display.Text = btn.Text;
                isNewEntry = false;
            }
            else
            {
                display.Text += btn.Text;
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            _lastValue = double.Parse(display.Text);
            _currentOperation = _operations[btn.Text];
            isNewEntry = true;
        }

        private void EqButton_Click(object sender, EventArgs e)
        {
            if (_currentOperation != null)
            {
                double secondValue = double.Parse(display.Text);
                try
                {
                    double result = _currentOperation.Execute(_lastValue, secondValue);
                    display.Text = result.ToString();
                }
                catch (Exception ex)
                {
                    display.Text = ex.Message;
                }
                _currentOperation = null;
                isNewEntry = true;
            }
        }

        private void ClrButton_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            _lastValue = 0;
            _currentOperation = null;
            isNewEntry = true;
        }
    }
}
