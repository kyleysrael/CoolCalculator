using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeriodicCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MinimizeBox = false; 
            this.MaximizeBox = false; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void quiz1Items_TextChanged(object sender, EventArgs e)
        {

        }

        private void quiz2Score_TextChanged(object sender, EventArgs e)
        {

        }

        private void quiz2Items_TextChanged(object sender, EventArgs e)
        {

        }

        private void lab1Score_TextChanged(object sender, EventArgs e)
        {

        }

        private void lab1Items_TextChanged(object sender, EventArgs e)
        {

        }

        private void lab2Score_TextChanged(object sender, EventArgs e)
        {

        }

        private void lab2Items_TextChanged(object sender, EventArgs e)
        {

        }

        private void lab3Score_TextChanged(object sender, EventArgs e)
        {

        }

        private void lab3Items_TextChanged(object sender, EventArgs e)
        {

        }

        private void class1Score_TextChanged(object sender, EventArgs e)
        {

        }

        private void class1Items_TextChanged(object sender, EventArgs e)
        {

        }

        private void class2Score_TextChanged(object sender, EventArgs e)
        {

        }

        private void class2Items_TextChanged(object sender, EventArgs e)
        {

        }

        private void class3Score_TextChanged(object sender, EventArgs e)
        {

        }

        private void class3Items_TextChanged(object sender, EventArgs e)
        {

        }

        private void examScore_TextChanged(object sender, EventArgs e)
        {

        }

        private void examItems_TextChanged(object sender, EventArgs e)
        {

        }

        private void computedPeriodicGrade_TextChanged(object sender, EventArgs e)
        {

        }

        private void equivalentGrade_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void errorHandler_Click(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Clear textboxes for quiz scores and items
            quiz1Score.Text = "";
            quiz1Items.Text = "";
            quiz2Score.Text = "";
            quiz2Items.Text = "";

            // Clear textboxes for lab scores and items
            lab1Score.Text = "";
            lab1Items.Text = "";
            lab2Score.Text = "";
            lab2Items.Text = "";
            lab3Score.Text = "";
            lab3Items.Text = "";

            // Clear textboxes for class scores and items
            class1Score.Text = "";
            class1Items.Text = "";
            class2Score.Text = "";
            class2Items.Text = "";
            class3Score.Text = "";
            class3Items.Text = "";

            // Clear textbox for exam scores and items
            examScore.Text = "";
            examItems.Text = "";

            // Clear computed grade, equivalent grade, and remarks labels
            computedPeriodicGrade.Text = "";
            equivalentGrade.Text = "";
            remarksLabel.Text = "";

            // Clear any error messages
            errorHandler.Text = "";
        }


        private void remarks_Click(object sender, EventArgs e)
        {

        }

        private void computeBtn_Click(object sender, EventArgs e)
        {
            errorHandler.Text = ""; // Reset error message

            try
            {
                // Retrieve quiz scores and items
                double q1Score = double.Parse(quiz1Score.Text);
                double q1Items = double.Parse(quiz1Items.Text);
                double q2Score = double.Parse(quiz2Score.Text);
                double q2Items = double.Parse(quiz2Items.Text);

                // Retrieve lab scores and items
                double l1Score = double.Parse(lab1Score.Text);
                double l1Items = double.Parse(lab1Items.Text);
                double l2Score = double.Parse(lab2Score.Text);
                double l2Items = double.Parse(lab2Items.Text);
                double l3Score = double.Parse(lab3Score.Text);
                double l3Items = double.Parse(lab3Items.Text);

                // Retrieve classroom scores and items
                double c1Score = double.Parse(class1Score.Text);
                double c1Items = double.Parse(class1Items.Text);
                double c2Score = double.Parse(class2Score.Text);
                double c2Items = double.Parse(class2Items.Text);
                double c3Score = double.Parse(class3Score.Text);
                double c3Items = double.Parse(class3Items.Text);

                ScoreValidator validator = new ScoreValidator();

                // Validation for quiz
                validator.ValidateScoreAndItems(q1Score, q1Items, 5, 50, "Quiz 1");
                validator.ValidateScoreAndItems(q2Score, q2Items, 5, 50, "Quiz 2");

                // Validation for Classroom activities
                validator.ValidateScoreAndItems(c1Score, c1Items, 30, 100, "Classroom Act 1");
                validator.ValidateScoreAndItems(c2Score, c2Items, 30, 100, "Classroom Act 2");
                validator.ValidateScoreAndItems(c3Score, c3Items, 30, 100, "Classroom Act 3");

                // Validation for Laboratory activities
                validator.ValidateScoreAndItems(l1Score, l1Items, 50, 100, "Lab 1");
                validator.ValidateScoreAndItems(l2Score, l2Items, 50, 100, "Lab 2");
                validator.ValidateScoreAndItems(l3Score, l3Items, 50, 100, "Lab 3");

                // Check if exam score and items are not empty
                if (!string.IsNullOrEmpty(examScore.Text) && !string.IsNullOrEmpty(examItems.Text))
                {
                    // Retrieve exam score and items
                    double examScoreValue = double.Parse(examScore.Text);
                    double examItemsValue = double.Parse(examItems.Text);

                    // Validation for Exam
                    validator.ValidateExam(examScoreValue, examItemsValue);

                    // Perform calculations
                    double grade = Calculation(q1Score, q1Items, q2Score, q2Items, l1Score, l1Items, l2Score, l2Items, l3Score, l3Items, c1Score, c1Items, c2Score, c2Items, c3Score, c3Items, examScoreValue, examItemsValue);

                    // Display the computed grade
                    computedPeriodicGrade.Text = grade.ToString();

                    // Determine equivalent grade
                    string equivalent = DetermineEquivalentGrade(grade);

                    // Display equivalent grade
                    equivalentGrade.Text = equivalent;

                    // Determine remarks
                    string remarks = DetermineRemarks(grade);

                    // Display remarks
                    remarksLabel.Text = remarks;
                }
                else
                {
                    // Display an error message if exam score or items are empty
                    errorHandler.Text = "Please enter both exam score and total items.";
                }
            }
            catch (Exception ex)
            {
                errorHandler.Text = ex.Message;
            }
        }


        private double Calculation(double q1, double q1a, double q2, double q2a, double l1, double l1a, double l2, double l2a, double l3, double l3a, double c1, double c1a, double c2, double c2a, double c3, double c3a, double x, double xa)
        {
            double qw1 = q1 / q1a * 50 + 50;
            double qw2 = q2 / q2a * 50 + 50;
            double qc = Math.Round(((qw1 + qw2) / 2) * 0.1, 3);

            double lw = ((l1 + l2 + l3) / (l1a + l2a + l3a)) * 50 + 50;
            double lc = Math.Round(lw * 0.5, 3);

            double cw = ((c1 + c2 + c3) / (c1a + c2a + c3a)) * 50 + 50;
            double cc = Math.Round(cw * 0.1, 3);

            double xw = x / xa * 50 + 50;
            double xc = Math.Round(xw * 0.3, 3);

            return Math.Round(qc + lc + cc + xc, 3);
        }

        private string DetermineEquivalentGrade(double grade)
        {
            if (grade >= 97.5)
                return "1.0";
            else if (grade >= 94.5)
                return "1.25";
            else if (grade >= 91.5)
                return "1.5";
            else if (grade >= 88.5)
                return "1.75";
            else if (grade >= 85.5)
                return "2.0";
            else if (grade >= 82.5)
                return "2.25";
            else if (grade >= 79.5)
                return "2.5";
            else if (grade >= 76.5)
                return "2.75";
            else if (grade >= 74.5)
                return "3.0";
            else
                return "5.0";
        }

        private string DetermineRemarks(double grade)
        {
            if (grade >= 74.5)
                return "Passed";
            else
                return "Failed";
        }

        public class ScoreValidator
        {
            public void ValidateScoreAndItems(double score, double items, double minItems, double maxItems, string fieldName)
            {
                if (score < 0)
                    throw new ArgumentException($"{fieldName} score cannot be less than zero.");

                if (items < minItems || items > maxItems)
                    throw new ArgumentOutOfRangeException($"{fieldName} items must be between {minItems} and {maxItems}.");

                if (score > items)
                    throw new ArgumentException($"Score cannot exceed total items in {fieldName}.");
            }

            public void ValidateExam(double score, double items)
            {
                if (items != 100)
                    throw new ArgumentOutOfRangeException("Total items for Exam must always be 100.");

                ValidateScoreAndItems(score, items, 100, 100, "Exam");
            }
        }

        private void ValidateIntegerKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

    }
}

