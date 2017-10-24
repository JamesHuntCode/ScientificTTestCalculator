using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TtestCalculatorProgram // (t Test calculator for 2 independant means)
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.RowTemplate.Height = 35;
        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            // Set up 10 rows in each column:
            for (int i = 0; i < 10; i++)
            {
                this.dataGridView1.Rows.Add();
            }
        }

        private double GetAverage(List<double> list) // Method used to get the average from an array list
        {
            int len = list.Count;
            double sum = 0;

            for (int i = 0; i < len; i++)
            {
                sum += list[i];
            }

            return sum / len; // Return average
        }

        private List<double> SubAVGThenSquare(List<double> list, double average) // Method used to go through each column, subtract AVG from current value and then square that value
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = (list[i] - average) * (list[i] - average);
            }
            return list;
        }

        private double GetS2Numbers(List<double> list)
        {
            double sum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }

            return sum / 9; // Return S2 Value
        }

        private double GetT(double AVG1, double AVG2, double S2Val1, double S2Val2, int rowCount) // Method used to caluculate the t value:
        {
            double numerator = AVG1 - AVG2;
            double denomenator = Math.Sqrt((S2Val1 / rowCount) + (S2Val2 / rowCount));

            double tValue = numerator / denomenator;

            return tValue;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            List<double> dataSetOne = new List<double>(); // Array list to store inputs from column 1
            List<double> dataSetTwo = new List<double>(); // Array list to store inputs from column 2

            try
            {
                // Gather the inputs from column 1:
                for (int i = 0; i < 10; i++)
                {
                    double val = Convert.ToDouble(this.dataGridView1[0, i].Value);
                    dataSetOne.Add(val);
                }

                // Gather the inputs from column 2:
                for (int i = 0; i < 10; i++)
                {
                    double val = Convert.ToDouble(this.dataGridView1[1, i].Value);
                    dataSetTwo.Add(val);
                }

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            // Get average from both array lists:
            double averageX = GetAverage(dataSetOne);
            double averageY = GetAverage(dataSetTwo);

            // Get new lists:
            dataSetOne = SubAVGThenSquare(dataSetOne, averageX);
            dataSetTwo = SubAVGThenSquare(dataSetTwo, averageY);

            // Get S2 Values:
            double S2ValueX = GetS2Numbers(dataSetOne);
            double S2ValueY = GetS2Numbers(dataSetTwo);

            // Calculate final t value:
            double tValue = GetT(averageX, averageY, S2ValueX, S2ValueY, 10);

            txtDisplayResult.Text = Convert.ToString(tValue);
        }
    }
}
