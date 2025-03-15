using System;
using System.Windows.Forms;
using System.Xml.Linq;



namespace StudentGradesApplication
{
    public partial class frmStudentGradeProgram : Form
    {
        public frmStudentGradeProgram()
        {
            InitializeComponent();
        }

        private void btnGenerateAverage_Click(object sender, EventArgs e)
        {
            // Validate input fields    
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEnglish.Text) ||
                string.IsNullOrWhiteSpace(txtMath.Text) ||
                string.IsNullOrWhiteSpace(txtScience.Text) ||
                string.IsNullOrWhiteSpace(txtFilipino.Text) ||
                string.IsNullOrWhiteSpace(txtHistory.Text))
            {
                MessageBox.Show("Please enter all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Get user inputs and convert to numbers
                string studentName = txtName.Text;
                double english = Convert.ToDouble(txtEnglish.Text);
                double math = Convert.ToDouble(txtMath.Text);
                double science = Convert.ToDouble(txtScience.Text);
                double filipino = Convert.ToDouble(txtFilipino.Text);
                double history = Convert.ToDouble(txtHistory.Text);

                // Compute average
                double average = (english + math + science + filipino + history) / 5;

                // Determine pass or fail using the ternary operator
                string result = average >= 75 ? "passed" : "failed";

                // Display result
                lblResult.Text = $"The student {studentName} {result}.\nThe general average of {studentName} is {average:F2}.";
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for grades.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
