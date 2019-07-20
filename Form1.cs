using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_practise
{
    public partial class Practise_app : Form
    {

        double value1 = 0;
        double answer = 0;
        string action = "";
        public Practise_app()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MnuQuit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Application.Exit();
        }

        private void MnuCut_Click(object sender, EventArgs e)
        {
            //string someText;

            if (textBox1.SelectedText != "")
            {
                //someText = textBox1.SelectedText;
                //MessageBox.Show(someText);
                textBox1.Cut();
            }
            else
                MessageBox.Show("There is no text selected to cut!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MnuUndo_Click(object sender, EventArgs e)
        {
            if (textBox1.CanUndo == true)
            {
                textBox1.Undo();
                textBox1.ClearUndo();
            }
                
        }

        private void MnuCopy_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Copy();
            }
            else
                MessageBox.Show("There is no text selected to copy!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MnuPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                textBox2.Paste();
                Clipboard.Clear();
            }
            
        }

        private void MnuViewTextBoxes_Click(object sender, EventArgs e)
        {

            mnuViewTextBoxes.Checked = !mnuViewTextBoxes.Checked; // Does exacly what commented part below does - just in one line
            /*
            if (mnuViewTextBoxes.Checked == false)
                mnuViewTextBoxes.Checked = true;
            else
                mnuViewTextBoxes.Checked = false;
            */

            if (mnuViewTextBoxes.Checked)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
            }

        }

        private void MnuViewImages_Click(object sender, EventArgs e)
        {
            string chosen_file = "";

            openFD.Title = "Insert an Image";
            //openFD.InitialDirectory = "C:"; // sets initial directory to 'C'
            openFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal); // sets initial directory to 'Documents'
            openFD.FileName = "";
            openFD.Filter = "JPEG Images (*.jpg)|*.jpg|GIF Images (*.gif)|*.gif|BITMAPS (*.bmp)|*.bmp|All Files (*.*)|*.*";

            //openFD.ShowDialog();

            if (openFD.ShowDialog() == DialogResult.Cancel)
                MessageBox.Show("Operation Cancelled");
            else
            {
                chosen_file = openFD.FileName;
                pictureBox1.Image = Image.FromFile(chosen_file);
            }
            
        }

        private void MnuOpen_Click(object sender, EventArgs e)
        {
            string chosen_file = "";
            openFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFD.Title = "Open a Text File";
            openFD.FileName = "";
            openFD.Filter = "Text Files (*.txt)|*.txt|Word Documents (*.docx)|*.docx|All Files (*.*)|*.*";

            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                chosen_file = openFD.FileName;
                richTextBox1.LoadFile(chosen_file, RichTextBoxStreamType.PlainText);
            }
        }

        private void MnuSave_Click(object sender, EventArgs e)
        {
            string saved_file = "";
            saveFD.InitialDirectory = "C:";
            saveFD.FileName = "";
            saveFD.Title = "Save a Text File";
            saveFD.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                saved_file = saveFD.FileName;
                richTextBox1.SaveFile(saved_file, RichTextBoxStreamType.PlainText);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My First Message", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
        }

        private void BtnString_Click(object sender, EventArgs e)
        {
            string firstName;
            string messageText;

            messageText = "Your name is ";
            firstName = nameTextBox.Text;

            //MessageBox.Show(messageText + firstName, "Name");
            TextMessage.Text = "Your name is " + firstName;
            MessageTextBox.Text = messageText + firstName;
        }

        private void BtnIntegers_Click(object sender, EventArgs e)
        {
            int myInteger;

            myInteger = 25;

            MessageBox.Show(myInteger.ToString(), "Integer Numbers");
        }

        private void BtnFloat_Click(object sender, EventArgs e)
        {
            float myFloat;

            myFloat = 1234.5678F;
            MessageBox.Show(myFloat.ToString(), "Floating Point Numbers");
        }

        private void BtnDouble_Click(object sender, EventArgs e)
        {
            double myDouble;

            myDouble = 12345678.12345678;
            MessageBox.Show(myDouble.ToString(), "Double Numbers");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int firstNumber;
            int secondNumber;
            int integerAnswer;

            firstNumber = 10;
            secondNumber = 32;
            integerAnswer = firstNumber + secondNumber;

            MessageBox.Show(integerAnswer.ToString(), "Integer Addition");
        }

        private void BtnAddFloats_Click(object sender, EventArgs e)
        {
            float firstNumber;
            float secondNumber;
            float floatAnswer;
            int integerAnswer = 20;

            firstNumber = 10.5F;
            secondNumber = 32.5F;
            floatAnswer = firstNumber + secondNumber + integerAnswer;

            MessageBox.Show(floatAnswer.ToString(), "Float Addition");
        }

        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            int answerSubtract;
            int numberOne = 15;
            int numberTwo = 18;

            answerSubtract = 25 - numberOne - numberTwo;

            MessageBox.Show(answerSubtract.ToString(), "Subtraction");
        }

        private void BtnMixed_Click(object sender, EventArgs e)
        {
            int firstNumber;
            int secondNumber;
            int thirdNumber;
            int answer;

            firstNumber = 100;
            secondNumber = 75;
            thirdNumber = 50;
            answer = firstNumber * (secondNumber / thirdNumber);

            MessageBox.Show(answer.ToString(), "Calculation");
        }

        private void BtnAnswer_Click(object sender, EventArgs e)
        {
            int firstTextBoxNumber;
            int secondTextBoxNumber;
            int thirdTextBoxNumber;
            int answer;

            firstTextBoxNumber = int.Parse(textBox1.Text);
            secondTextBoxNumber = int.Parse(textBox2.Text);
            thirdTextBoxNumber = int.Parse(richTextBox1.Text);
            answer = (firstTextBoxNumber / secondTextBoxNumber) + thirdTextBoxNumber;

            MessageBox.Show(answer.ToString(), "Answer");
        }

        private void BtnOne_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnOne.Text;
        }

        private void BtnTwo_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnTwo.Text;
        }

        private void BtnThree_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnThree.Text;
        }

        private void BtnFour_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnFour.Text;
        }

        private void BtnFive_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnFive.Text;
        }

        private void BtnSix_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnSix.Text;
        }

        private void BtnSever_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnSeven.Text;
        }

        private void BtnEight_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnEight.Text;
        }

        private void BtnNine_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnNine.Text;
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnDot.Text;
        }

        private void BtnZero_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnZero.Text;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //txtDisplay.Text = "";
            txtDisplay.Clear();
            value1 = 0;
            answer = 0;
            action = "";
        }

        private void BtnAddition_Click(object sender, EventArgs e)
        {
            value1 = value1 + double.Parse(txtDisplay.Text);
            action = btnAddition.Text;
            txtDisplay.Clear();
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {   /* if ... else way of calculator
            if (action == btnAddition.Text)
            {
                answer = value1 + double.Parse(txtDisplay.Text);
            }
            else if (action == btnSubtraction.Text)
            {
                answer = value1 - double.Parse(txtDisplay.Text);
            }
            else if (action == btnMultiplication.Text)
            {
                answer = value1 * double.Parse(txtDisplay.Text);
            }
            else if (action == btnDivision.Text)
            {
                if (double.Parse(txtDisplay.Text) != 0)
                {
                    answer = value1 / double.Parse(txtDisplay.Text);
                }
                
            }
            txtDisplay.Text = answer.ToString();
            value1 = 0;
            action = "";
            */

            //switch case of calculator
            switch (action)
            {
                case "+":
                    answer = value1 + double.Parse(txtDisplay.Text);
                    txtDisplay.Text = answer.ToString();
                    value1 = 0;
                    action = "";
                    break;
                case "-":
                    answer = value1 - double.Parse(txtDisplay.Text);
                    txtDisplay.Text = answer.ToString();
                    value1 = 0;
                    action = "";
                    break;
                case "*":
                    answer = value1 * double.Parse(txtDisplay.Text);
                    txtDisplay.Text = answer.ToString();
                    value1 = 0;
                    action = "";
                    break;
                case "/":
                    answer = value1 / double.Parse(txtDisplay.Text);
                    txtDisplay.Text = answer.ToString();
                    value1 = 0;
                    action = "";
                    break;
                default:
                    MessageBox.Show("No action was selected!!!", "Error");
                    break;
            }
            

        }

        private void BtnSubtraction_Click(object sender, EventArgs e)
        {
            if (value1 == 0)
                value1 = double.Parse(txtDisplay.Text);
            else
                value1 = value1 - double.Parse(txtDisplay.Text);
            action = btnSubtraction.Text;
            txtDisplay.Clear();
        }

        private void BtnMultiplication_Click(object sender, EventArgs e)
        {
            if (value1 == 0)
                value1 = double.Parse(txtDisplay.Text);
            else
                value1 = value1 * double.Parse(txtDisplay.Text);
            action = btnMultiplication.Text;
            txtDisplay.Clear();
        }

        private void BtnDivision_Click(object sender, EventArgs e)
        {
            if (value1 == 0)
                value1 = double.Parse(txtDisplay.Text);
            else if (txtDisplay.Text != "" && double.Parse(txtDisplay.Text) != 0)
                value1 = value1 / double.Parse(txtDisplay.Text);
            
            action = btnDivision.Text;
            txtDisplay.Clear();
        }

        private void BtnLoop_Click(object sender, EventArgs e)
        {
            int limit = int.Parse(tbLimit.Text);
            int result = 0;
            for (int i = 1; i <= limit; i++)
            {
                result += i;
            }
            lsum.Text = result.ToString();
        }

        private void BtForLoop_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            bool isNumber = false;

            int startValue = 0;
            int endValue = 0;
            int multiplyBy = 0;
            isNumber = int.TryParse(tbLoopStart.Text, out startValue);

            if (!isNumber)
                MessageBox.Show("Type Number in Start Number!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isNumber = int.TryParse(tbLoopEnd.Text, out endValue);
                if (!isNumber)
                    MessageBox.Show("Type Number in End Number!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    isNumber = int.TryParse(tbMultiplyBy.Text, out multiplyBy);
                    if (!isNumber)
                        MessageBox.Show("Type Number in Multiply By!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        //while loop
                        int i = startValue;
                        while (i <= endValue)
                        {
                            answer = i * multiplyBy;
                            listBox1.Items.Add(i + " times " + multiplyBy + " equals " + answer);
                            i++;
                        }
                    }
                }
            }

            /* for loop
            for (int i = startValue; i <= endValue; i++)
            {
                answer = i * multiplyBy;
                listBox1.Items.Add( i + " times " + multiplyBy + " equals " + answer.ToString());
            }
            */

            //do loop
            /*
            int i = startValue;
            do
            {
                answer = i * multiplyBy;
                listBox1.Items.Add(i + " times " + multiplyBy + " equals " + answer);
                i++;
            } while (i <= endValue);
            */

            
        }
    }
}
