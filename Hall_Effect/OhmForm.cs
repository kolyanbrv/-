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
    public partial class OhmForm : Form
    {
        private double E = 1.60217656 * Math.Pow(10, -19);     // Заряд электрона
        private double S = 0.1 * Math.Pow(10, -6);   // Площадь поперечного сечения образца, мм
        private double l = 20; // Длина образца, мм

        public OhmForm()
        {
            InitializeComponent();
        }

        private void tTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
            tTextBox.Text = "";
            iTextBox.Text = "";
            label4.Text = "Напряжение (U) = ";
        }

        private double calculateOhm(double I, double t, int materialIndex)
        {
            double p20 = 1; // Удельное сопротивление материала при комнатной температуре (20° C), Ом·м
            double alpha = 1; // Температурный коэффициент материала при комнатной температуре, 10^-3 / K 

            switch (materialIndex)
            {
                case 0:
                    p20 = 0.43;
                    alpha = -0.05;
                    break;
                default:
                    p20 = 2300;
                    alpha = -70;
                    break;
            }

            // Формула для нахождения удельного сопротивления: ρ = ρ20 [1 + alpha (t − 20° C)] 

            double p = p20 * (1 + alpha * (t - 20));

            // Формула для нахождения сопротивления: R = ρ*l/S;

            double R = p * l / S;

            // Закон Ома

            double U = I * R;

            return U;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((iTextBox.Text.Equals("")) || (tTextBox.Text.Equals("")))
            {
                MessageBox.Show("Введены неполные данные", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            double t, I = 0;

            try
            {
                t = Convert.ToDouble(tTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное значение t", "Ошибка", MessageBoxButtons.OK);
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

            double U = calculateOhm(I, t, materialIndex);

            string printValue = U.ToString();

            if (U != 0)
            {
                // Переводим экспоненциальное представление числа в более "читабельный" вид
                printValue = U.ToString("0.###E+0", System.Globalization.CultureInfo.InvariantCulture)
                    .Replace("E-", "*10^-")
                    .Replace("E+", "*10^");
            }

            label4.Text = "Напряжение (U) = " + printValue + " В";
        }

        private void OhmForm_Load(object sender, EventArgs e)
        {
            materialComboBox.SelectedIndex = 0;
        }
    }
}

