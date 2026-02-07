// This is a placeholder for the designer partial class.
// You will need to use Visual Studio Designer to generate the full GUI code.
using System.Windows.Forms;

namespace CalculatorTask
{
    public partial class CalculatorForm : Form
    {
        private TextBox display;
        private Button[] digitButtons;
        private Button addButton, subButton, mulButton, divButton, eqButton, clrButton;

        private void InitializeComponent()
        {
            this.Text = "Calculator";
            this.Width = 300;
            this.Height = 400;

            display = new TextBox { ReadOnly = true, Text = "0", Width = 260, Top = 10, Left = 10, TextAlign = HorizontalAlignment.Right };
            this.Controls.Add(display);

            digitButtons = new Button[10];
            for (int i = 0; i < 10; i++)
            {
                digitButtons[i] = new Button { Text = i.ToString(), Width = 60, Height = 40 };
                digitButtons[i].Click += DigitButton_Click;
                this.Controls.Add(digitButtons[i]);
            }

            addButton = new Button { Text = "+", Width = 60, Height = 40 };
            subButton = new Button { Text = "-", Width = 60, Height = 40 };
            mulButton = new Button { Text = "*", Width = 60, Height = 40 };
            divButton = new Button { Text = "/", Width = 60, Height = 40 };
            eqButton = new Button { Text = "=", Width = 60, Height = 40 };
            clrButton = new Button { Text = "C", Width = 60, Height = 40 };

            addButton.Click += OperationButton_Click;
            subButton.Click += OperationButton_Click;
            mulButton.Click += OperationButton_Click;
            divButton.Click += OperationButton_Click;
            eqButton.Click += EqButton_Click;
            clrButton.Click += ClrButton_Click;

            this.Controls.Add(addButton);
            this.Controls.Add(subButton);
            this.Controls.Add(mulButton);
            this.Controls.Add(divButton);
            this.Controls.Add(eqButton);
            this.Controls.Add(clrButton);

            // Layout buttons
            int startX = 10, startY = 60;
            for (int i = 1; i <= 9; i++)
            {
                int row = (i - 1) / 3;
                int col = (i - 1) % 3;
                digitButtons[i].Top = startY + row * 50;
                digitButtons[i].Left = startX + col * 70;
            }
            digitButtons[0].Top = startY + 3 * 50;
            digitButtons[0].Left = startX + 70;

            addButton.Top = startY;
            addButton.Left = startX + 210;
            subButton.Top = startY + 50;
            subButton.Left = startX + 210;
            mulButton.Top = startY + 100;
            mulButton.Left = startX + 210;
            divButton.Top = startY + 150;
            divButton.Left = startX + 210;

            eqButton.Top = startY + 3 * 50;
            eqButton.Left = startX + 140;
            clrButton.Top = startY + 3 * 50;
            clrButton.Left = startX;
        }

        // Event handlers will be implemented in the main class file
    }
}
