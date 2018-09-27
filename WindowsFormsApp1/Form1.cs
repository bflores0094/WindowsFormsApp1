using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Random randomizer = new Random();
        int addend1;
        int addend2;
        int subend1;
        int subend2;
        int multend1;
        int multend2;
        int div1;
        int div2;

        int timeLeft;
        

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            subend1 = randomizer.Next(1, 101);
            subend2 = randomizer.Next(1, subend1);
            multend1 = randomizer.Next(2, 11);
            multend2 = randomizer.Next(2, 11);
            div1 = randomizer.Next(2, 11);
            div2 = randomizer.Next(2, 11);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            minusLeftLabel.Text = subend1.ToString();
            minusRightLabel.Text = subend2.ToString();
            timesLeftLabel.Text = multend1.ToString();
            timesRightLabel.Text = multend2.ToString();
            divideLeftLabel.Text = div1.ToString();
            divideRightLabel.Text = div2.ToString();


            sum.Value = 0;
            difference.Value = 0;
            product.Value = 0;
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
            timeLabel.BackColor = Color.White;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft < 6)
                {
                    for (int i = 5; i > 0; i--)
                    {
                        if (timeLabel.BackColor == Color.White)
                            timeLabel.BackColor = Color.Red;
                        else
                            timeLabel.BackColor = Color.White;
                    }
                }
            

            }
            else
            {
                timeLabel.BackColor = Color.Red;
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.",
                                "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = subend1 - subend2;
                product.Value = multend1 * multend2;
                quotient.Value = div1 / div2;
                startButton.Enabled = true;
            }


        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (subend1 - subend2 == difference.Value)
                && (multend1 * multend2 == product.Value) && (div1 / div2 == quotient.Value))
                return true;
            else
                return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }


    }
}
