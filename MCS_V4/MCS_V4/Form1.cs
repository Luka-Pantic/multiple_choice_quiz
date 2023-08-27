using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MCS_V4
{
    public partial class Form1 : Form
    {
        string correctAnswer = "0";
        int questionNumber = 1;
        int score;
        int totalQuestions;
        string question = "Wie viele Diagonalen hat ein Dreieck";
        string questionAnswer1 = "0";
        string questionAnswer2 = "1";
        string questionAnswer3 = "2";
        string questionAnswer4 = "3";

              
        public Form1()
        {
            InitializeComponent();
            askQuestion(questionNumber);
            totalQuestions = 20;
            pictureBox1.BackgroundImage = Image.FromFile(@"..\..\..\..\..\shutterstock_1656491479-1.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkAnswer(button1.Text);
        }
        private void getQuestion(int qnum)
        {
            string filename = @"..\..\..\..\..\Quizfragen.txt";
            List<string> questions = File.ReadAllLines(filename).ToList();
            for (int i = 0; i<totalQuestions; i++)
            {
                if (i == qnum)
                {
                    string[] questionItems = questions[i].Split(",");
                    question = questionItems[0];
                    correctAnswer = questionItems[1];

                    List<int> uniqueNoList = new List<int>();
                    int random = new Random().Next(1, 5);
                    uniqueNoList.Add(random);
                    for (int j = 1; j < 4; j++)
                    {
                        int random_ = new Random().Next(1, 5);
                        while (uniqueNoList.Contains(random_))
                        {
                            random_ = new Random().Next(1,5);
                        }
                        uniqueNoList.Add(random_);
                    }
                    questionAnswer1 = questionItems[uniqueNoList[0]];
                    questionAnswer2 = questionItems[uniqueNoList[1]];
                    questionAnswer3 = questionItems[uniqueNoList[2]];
                    questionAnswer4 = questionItems[uniqueNoList[3]];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkAnswer(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkAnswer(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkAnswer(button4.Text);
        }
        private void checkAnswer(string userAnswer)
        {
            if (userAnswer == correctAnswer)
            {      
                score++;
            }

            if (questionNumber == totalQuestions)
            {
                MessageBox.Show(
                    "Quiz Done" + Environment.NewLine + "Your score is " + score + Environment.NewLine + "Congrats");
                score = 0;
                questionNumber = 0;

                askQuestion(questionNumber);

            }
            questionNumber++;
            askQuestion(questionNumber);
        }
        private void askQuestion(int qnum)
        {
            getQuestion(qnum);
            questionLabel.Text = question;
            button1.Text = questionAnswer1;
            button2.Text = questionAnswer2;
            button3.Text = questionAnswer3;
            button4.Text = questionAnswer4;
        }

        private void questionLabel_Click(object sender, EventArgs e)
        {

        }
        public void randomAnswer()
        {

        }
    } 
}
