using System;
using System.Windows.Forms;

namespace dolgNumber
{
    public partial class Form1 : Form
    {
        private TextBox lowerBoundTextBox; // Нижняя граница
        private TextBox upperBoundTextBox; // Верхняя граница
        private Button generateButton;
        private Label resultLabel;

        public Form1()
        {
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.ClientSize = new System.Drawing.Size(400, 300); // Изменяем размер формы

            lowerBoundTextBox = new TextBox(); // Нижняя граница
            lowerBoundTextBox.Location = new System.Drawing.Point(150, 50);
            lowerBoundTextBox.Size = new System.Drawing.Size(100, 20);
            Label lblLowerBound = new Label();
            lblLowerBound.Text = "Нижняя граница:";
            lblLowerBound.Location = new System.Drawing.Point(50, 50);
            lblLowerBound.AutoSize = true;

            upperBoundTextBox = new TextBox(); // Верхняя граница
            upperBoundTextBox.Location = new System.Drawing.Point(150, 100);
            upperBoundTextBox.Size = new System.Drawing.Size(100, 20);
            Label lblUpperBound = new Label();
            lblUpperBound.Text = "Верхняя граница:";
            lblUpperBound.Location = new System.Drawing.Point(50, 100);
            lblUpperBound.AutoSize = true;

            generateButton = new Button();
            generateButton.Location = new System.Drawing.Point(150, 150);
            generateButton.Size = new System.Drawing.Size(100, 23);
            generateButton.Text = "Сгенерировать";
            generateButton.Click += new EventHandler(generateButton_Click);

            resultLabel = new Label();
            resultLabel.AutoSize = true;
            resultLabel.Location = new System.Drawing.Point(150, 200);

            this.Controls.Add(lowerBoundTextBox);
            this.Controls.Add(upperBoundTextBox);
            this.Controls.Add(generateButton);
            this.Controls.Add(resultLabel);
            this.Controls.Add(lblLowerBound);
            this.Controls.Add(lblUpperBound);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Кнопка нажата!"); // Отладочное сообщение
            int lowerBound, upperBound;

            // Выводим значения текстовых полей для отладки
            System.Diagnostics.Debug.WriteLine("Нижняя граница: " + lowerBoundTextBox.Text);
            System.Diagnostics.Debug.WriteLine("Верхняя граница: " + upperBoundTextBox.Text);

            // Пробуем преобразовать текст в числа
            if (!int.TryParse(lowerBoundTextBox.Text, out lowerBound) || !int.TryParse(upperBoundTextBox.Text, out upperBound))
            {
                MessageBox.Show("Пожалуйста, введите целые числа для нижней и верхней границ диапазона.");
                return;
            }

            resultLabel.Text = GeneratePrimeNumbers(lowerBound, upperBound);
        }

        private string GeneratePrimeNumbers(int lowerBound, int upperBound)
        {
            string result = "Простые числа в диапазоне от " + lowerBound + " до " + upperBound + ":\n";

            for (int num = lowerBound; num <= upperBound; num++)
            {
                if (IsPrime(num))
                {
                    result += num + ", ";
                }
            }

            return result.TrimEnd(',', ' ');
        }

        private bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
