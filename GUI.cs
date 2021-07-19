using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Test_WindowsForms
{
    struct QuestionFormat
    {
        public double Points { get; }
        public bool hasAutograding { get; }
        public bool hasMultipleAnswers { get; }
        public bool[] AnswerKey { get; }
        public QuestionFormat(double points, bool grading)
        {
            Points = points;
            hasAutograding = grading;
            hasMultipleAnswers = false;
            AnswerKey = null;
        }
        

        public QuestionFormat(double points, bool grading, bool cardinality, bool[] key)
        {
            Points = points;
            hasAutograding = grading;
            hasMultipleAnswers = cardinality;
            AnswerKey = key;
        }
    }
    static class GUI
    {
        //Menu called for text boxes
        public static double PromptMenu(string text)
        {
            var form = new Form2();
            //set up Form
            form.label1.Text = "Text-Frage erkannt";
            form.label2.Text = text;
            form.label3.Text = "Automatische Bewertung wird für Textantworten noch nicht unterstützt";
          
            form.ShowDialog();
            double points = Convert.ToDouble(form.textBox1.Text);
            //returns possible points only
            return points;
            
        }

        public static QuestionFormat PromptMenu(string text, string[] answers)
        {
            var form = new Form2();
            //set up needed Form
            form.label2.Text = text;
            form.label1.Text = "MultipleChoice-Frage erkannt";
            form.label3.Text = "Bitte richtige Antworten wählen";
            form.checkedListBox1.Visible = true;
            form.panel3.Visible = true;
            form.panel1.Visible = true;
            //adds possible answers to check-list
            foreach (string s in answers)
            {
                form.checkedListBox1.Items.Add(s, false);
            }

            form.ShowDialog();
            //retrieves values from input elements
            double points = Convert.ToDouble(form.textBox1.Text);
            bool grading = form.radioButton1.Checked;
            bool cardinality = form.radioButton4.Checked;
            var answerKey = new bool[answers.Length];
            //reads all check-states in check-list
            for(int i = 0; i < answers.Length; i++)
            {
                answerKey[i] = form.checkedListBox1.GetItemCheckState(i) == CheckState.Checked;
            }
            var result = new QuestionFormat(points, grading, cardinality, answerKey);
            return result;
        }
    }
}
