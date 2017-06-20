using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hall_Effect
{
    public partial class HallForm : Form
    {
        private const double d = 0.5;       // Толщина пластинки
        private double E = 1.60217656 * Math.Pow(10, -19);     // Заряд электрона

        public HallForm()
        {
            InitializeComponent();
        }

        private void bTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            // цифры, клавиша BackSpace (код в ASCII - 8), запятая (код в ASCII - 44), минус (код в ASCII - 45)
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bTextBox.Text = "";
            iTextBox.Text = "";
            label4.Text = "Напряжение (U) = ";
        }

        private double calculateHall (double B, double I, int materialIndex)
        {
            double ue = 1;  // Подвижность электронов
            double up = 1; //  Подвижность дырок
            double ne = 1;  // Концентрация электронов
            double np = 1;  // Концентрация дырок
            
            switch (materialIndex)
            {
                case 0:
                    ue = 0.39;
                    up = 0.19;
                    np = ne = 2.5 * Math.Pow(10, 13);
                    break;
                default:
                    ue = 0.15;
                    up = 0.05;
                    np = ne = 1.4 * (Math.Pow(10, 10));
                    break;
            }

            // Постоянная Холла
            double rHall = (3 * Math.PI * (Math.Pow(ne * ue, 2) - Math.Pow(np * up, 2))) / (8 * E * Math.Pow(ne * ue + np * up, 2));

            // Вычисление напряжения (Холловская разность потенциалов)
            double uHall = rHall * I * B * d;

            return uHall;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((iTextBox.Text.Equals("")) || (bTextBox.Text.Equals("")))
            {
                MessageBox.Show("Введены неполные данные", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            double B, I = 0;

            try
            {
                B = Convert.ToDouble(bTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное значение B", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            try
            {
               I = Convert.ToDouble(iTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное значение I", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            // Индекс материала
            int materialIndex = materialComboBox.SelectedIndex; 

            double uHall = calculateHall(B, I, materialIndex);

            string printValue = uHall.ToString();

            if (uHall != 0)
            {
                // Переводим экспоненциальное представление числа в более "читабельный" вид
                printValue = uHall.ToString("0.###E+0", System.Globalization.CultureInfo.InvariantCulture)
                    .Replace("E-", "*10^-")
                    .Replace("E+", "*10^");
            }

            label4.Text = "Напряжение (U) = " + printValue + " В";
        }

        private void HallForm_Load(object sender, EventArgs e)
        {
            materialComboBox.SelectedIndex = 0;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}

