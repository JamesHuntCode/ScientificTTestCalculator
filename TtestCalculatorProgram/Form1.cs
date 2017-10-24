using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TtestCalculatorProgram
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
            // Steps:

            // Step 1:

                // Set up two columnbs with var 10 rows each

                // Take average of column 1 (all 10 rows) and then field 2 (all 10 rows)

                // Go through the column and subtract the average from each input of that row and then square it

                // Do this for both columns

            // Step 2:

                // Calculate S squared values

                // Add all NEW row data together & then divide it by number of inputs minus 1

                // This then gives us two different values of S squared (from our 2 different columns) 

            // Step 3:

                // Calculate t value (1 value) 

                // Take averages the original AVG values from column 1 & 2

                // Subtract OG AVG value from column 1 from OG AVG value of column 2

                // Divide that number by the square root of the s2 value of col1 + the s2 value of col2 over the number of rows in each column

            // Set up 10 rows:

            for (int i = 0; i < 10; i++)
            {
                this.dataGridView1.Rows.Add();
            }
        }

        public int GetAverage(List<int> list) // Method used to get the average from an array list
        {
            int len = list.Count;

            for (int i = 0; i < len; i++)
            {

            }

            return 1; // Return average
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            List<int> dataSetOne = new List<int>(); // Array list to store inputs from column 1
            List<int> dataSetTwo = new List<int>(); // Array list to store inputs from column 2

            try
            {
                // Gather the inputs from column 1:
                for (int i = 0; i < 10; i++)
                {
                    int val = Convert.ToInt32(this.dataGridView1[0, i].Value);
                    dataSetOne.Add(val);
                }

                // Gather the inputs from column 2:
                for (int i = 0; i < 10; i++)
                {
                    int val = Convert.ToInt32(this.dataGridView1[1, i].Value);
                    dataSetTwo.Add(val);
                }

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
