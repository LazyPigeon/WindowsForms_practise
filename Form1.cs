﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsForms_practise
{
    public partial class Practise_app : Form
    {
        //Variables for calculator
        double value1 = 0;
        double answer = 0;
        string action = "";

        //Variables for SQL databases
        DataBaseConnection objConnect;
        string conString;
        DataSet ds;
        DataRow dRow;
        int MaxRows;
        int inc = 0;

        //Variables multiple forms
        public static TextBox tb = new TextBox();

        public Practise_app()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //combobox exercise
            initialize_combobox();

            //SQL databases
            try
            {
                objConnect = new DataBaseConnection();

                conString = Properties.Settings.Default.EmployeesConnectionString;
                objConnect.connection_string = conString; //give address of our SQL database to connect to
                objConnect.Sql = Properties.Settings.Default.SQL; //set up our SQL querry

                ds = objConnect.GetConnection; // receive data set from our class, that makes it from data it gets from SQL database

                MaxRows = ds.Tables[0].Rows.Count;
                NavigateRecords(); // fills fields in our forms tab
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            //Multiple forms exercise
            tb = txtChangeCase;
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

        private void BSelectMovies_Click(object sender, EventArgs e)
        {
            string movies = "";

            if (cbComedy.Checked)
            {
                if (movies == "")
                    movies = cbComedy.Text + "\n";
                else
                    //movies = movies + ", " + cbComedy.Text;
                    movies = movies + cbComedy.Text + Environment.NewLine;
            }
            if (cbAction.Checked)
            {
                if (movies == "")
                    movies = cbAction.Text + Environment.NewLine;
                else
                    //movies = movies + ", " + cbAction.Text;
                    movies = movies + cbAction.Text + "\n";
            }
            if (cbScienceFiction.Checked)
            {
                if (movies == "")
                    movies = cbScienceFiction.Text + "\n";
                else
                    //movies = movies + ", " + cbScienceFiction.Text;
                    movies = movies + cbScienceFiction.Text + "\n";
            }
            if (cbRomance.Checked)
            {
                if (movies == "")
                    movies = cbRomance.Text + Environment.NewLine;
                else
                    //movies = movies + ", " + cbRomance.Text;
                    movies = movies + cbRomance.Text + Environment.NewLine;
            }
            if (cbAnimation.Checked)
            {
                if (movies == "")
                    movies = cbAnimation.Text + "\n";
                else
                    //movies = movies + ", " + cbAnimation.Text;
                    movies = movies + cbAnimation.Text + "\n";
            }

            if (movies == "")
                MessageBox.Show("I don't have any favorite movie", "Favorite Movies");
            else
                MessageBox.Show("Types of movies you like:\n" + movies, "Favorite Movies");
        }

        private void BFavoriteMovie_Click(object sender, EventArgs e)
        {
            string movie = "";

            if (rbComedy.Checked)
                movie = rbComedy.Text;
            else if (rbAction.Checked)
                movie = rbAction.Text;
            else if (rbScienceFiction.Checked)
                movie = rbScienceFiction.Text;
            else if (rbRomance.Checked)
                movie = rbRomance.Text;
            else if (rbAnimation.Checked)
                movie = rbAnimation.Text;

            if (movie == "")
                MessageBox.Show("I don't have any favorite movie", "Favorite Movie");
            else
                MessageBox.Show("Your Favorite type of movie is " + movie, "Favorite Movie");
        }

        private void BtnDebug_Click(object sender, EventArgs e)
        {
            int lettercount = 0;
            string text = "Debugging";
            string letter;
            for (int i = 0; i < text.Length; i++)
            {
                letter = text.Substring(i,1);
                if (letter == "g")
                {
                    lettercount++;
                }
            }
            tbDebug.Text = "g count is " + lettercount.ToString();
        }

        private void BAddUp_Click(object sender, EventArgs e)
        {
            int firstNumber;
            int secondNumber;
            bool isNumber;
            isNumber = int.TryParse(tbFirstNumber.Text, out firstNumber);
            if (!isNumber)
                MessageBox.Show("Please Enter 1st number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isNumber = int.TryParse(tbSecondNumber.Text, out secondNumber);
                if (!isNumber)
                    MessageBox.Show("Please Enter 2nd number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    AddUp(firstNumber, secondNumber);
                }
            }               
        }

        void AddUp(int firstNumber, int secondNumber)
        {
            int answer = firstNumber + secondNumber;
            MessageBox.Show(firstNumber.ToString() + " + " + secondNumber.ToString() + " = " + answer.ToString(), "Add Up");

            return;
        }

        private int Subtract(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
        private int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        private int Divide(int firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }

        private void BSubtract_Click(object sender, EventArgs e)
        {
            int firstNumber;
            int secondNumber;
            bool isNumber;
            int answer;
            isNumber = int.TryParse(tbFirstNumber.Text, out firstNumber);
            if (!isNumber)
                MessageBox.Show("Please Enter 1st number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isNumber = int.TryParse(tbSecondNumber.Text, out secondNumber);
                if (!isNumber)
                    MessageBox.Show("Please Enter 2nd number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    answer = Subtract(firstNumber, secondNumber);
                    MessageBox.Show(firstNumber.ToString() + " - " + secondNumber.ToString() + " = " + answer.ToString(), "Subtraction");
                }
            }
        }

        private void BDivide_Click(object sender, EventArgs e)
        {
            int firstNumber;
            int secondNumber;
            bool isNumber;
            int answer;
            isNumber = int.TryParse(tbFirstNumber.Text, out firstNumber);
            if (!isNumber)
                MessageBox.Show("Please Enter 1st number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isNumber = int.TryParse(tbSecondNumber.Text, out secondNumber);
                if (!isNumber)
                    MessageBox.Show("Please Enter 2nd number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    answer = Divide(firstNumber, secondNumber);
                    MessageBox.Show(firstNumber.ToString() + " / " + secondNumber.ToString() + " = " + answer.ToString(), "Division");
                }
            }
        }

        private void BMultiply_Click(object sender, EventArgs e)
        {
            int firstNumber;
            int secondNumber;
            bool isNumber;
            int answer;
            isNumber = int.TryParse(tbFirstNumber.Text, out firstNumber);
            if (!isNumber)
                MessageBox.Show("Please Enter 1st number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isNumber = int.TryParse(tbSecondNumber.Text, out secondNumber);
                if (!isNumber)
                    MessageBox.Show("Please Enter 2nd number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    answer = Multiply(firstNumber, secondNumber);
                    MessageBox.Show(firstNumber.ToString() + " * " + secondNumber.ToString() + " = " + answer.ToString(), "Multiplication");
                }
            }
        }

        private void BtnArrays_Click(object sender, EventArgs e)
        {
            //clear listBox
            listBox1.Items.Clear();

            //Create array int
            /*
            int[] lottery_numbers;
            int startValue;
            int endValue;
            int multiplyBy;
            bool isNumber;
            isNumber = int.TryParse(tbLoopStart.Text, out startValue);
            if (!isNumber)
                MessageBox.Show("Please enter value in Start Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isNumber = int.TryParse(tbLoopEnd.Text, out endValue);

                if (!isNumber)
                    MessageBox.Show("Please enter value in End Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    isNumber = int.TryParse(tbMultiplyBy.Text, out multiplyBy);

                    if (!isNumber)
                        MessageBox.Show("Please enter value in Multiply By", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        lottery_numbers = new int[endValue - startValue + 1]; //startValue = 1; endValue = 10; to get table from start to end (including) we need to add 1 entry at end (endValue)
                        for (int i = 0; i < lottery_numbers.Length; i++)
                        {
                            lottery_numbers[i] = (startValue + i) * multiplyBy; //Add value to array at position i
                            listBox1.Items.Add((1+i).ToString() + " times " + multiplyBy.ToString() + " equals " + lottery_numbers[i].ToString()); //Display value from array at position i in listBox
                        }
                    }
                }
                
            }
            */

            //String array example
            string[] stringArray;
            stringArray = new string[5];

            stringArray[0] = "This";
            stringArray[1] = "is";
            stringArray[2] = "a";
            stringArray[3] = "string";
            stringArray[4] = "array";

            foreach (string arrayEntry in stringArray)
            {
                listBox1.Items.Add(arrayEntry);
            }

        }

        private void Btn2DArray_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            int[,] arrayTimes;
            int arrayRows = 5;
            int arrayCols = 3;

            arrayTimes = new int[arrayRows, arrayCols];

            int number = 0;

            for (int i = 0; i < arrayRows; i++)
            {
                number = number + 10;

                for (int j = 0; j < arrayCols; j++)
                {
                    arrayTimes[i, j] = number;
                    number = number * 10;
                    listBox1.Items.Add("arrayPos=" + i.ToString() + "," + j.ToString() + " val = " + arrayTimes[i, j].ToString());
                }
                number = number / 1000;
            }
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<string> students = new List<string>();

            students.Add("Jenny");
            students.Add("Peter");
            students.Add("Mary Jane");

            //let's use foreach loop here on list
            foreach (string child in students)
            {
                listBox1.Items.Add(child);
            }

            students.Add("Azhar");
            listBox1.Items.Add("New entry = " + students[3]);

            students.Sort();
            listBox1.Items.Add("==============");

            //but here we use for loop on list
            for (int i = 0; i < students.Count; i++)
            {
                listBox1.Items.Add(students[i]);
            }

            students.Remove("Peter");
            students.RemoveRange(0, 2);
            listBox1.Items.Add("===============");

            foreach (string kid in students)
            {
                listBox1.Items.Add(kid);
            }
            MessageBox.Show(e.ToString());
        }

        private void BtnHashtable_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Hashtable students = new Hashtable();

            //add data in hashtable -> python dictionary way --- will overwrite exixting value if key will already be in hashtable
            students["Jenny"] = 87;
            students["Peter"] = "No Score";
            //add data in hashtable -> the other way, with method --- won't add dublicate value
            students.Add("Marry Jane", 64);
            students.Add("Azhar", 79);

            foreach (DictionaryEntry child in students)
            {
                listBox1.Items.Add( child.Key + ": " + child.Value);
            }

            listBox1.Items.Add("---------------");
            students.Remove("Peter");
            foreach (DictionaryEntry kid in students)
            {
                listBox1.Items.Add(kid.Key + ": " + kid.Value);
            }
        }

        //enumeration example
        enum Subjects { English, IT, Science, Design, Math };
        private void BtnEnumeration_Click(object sender, EventArgs e)
        {
            Subjects newSubject = Subjects.Science;
            int numNumber = (int)newSubject;
            MessageBox.Show(newSubject.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            for (int i = 0; i < 4; i++)
                if (i == numNumber)
                    MessageBox.Show("You are taking Science", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnStringExample_Click(object sender, EventArgs e)
        {
            /*
            string stringVar = tbString.Text;
            tbString.Text = stringVar.ToUpper();
            MessageBox.Show(stringVar.Length.ToString());
            tbString.Text = tbString.Text.Trim();
            stringVar = tbString.Text;
            MessageBox.Show(stringVar.Length.ToString());
            */
            string stringEmail = tbString.Text;
            //int result = stringEmail.IndexOf("@",0,9);
            int result = stringEmail.IndexOf("@");

            if (result == -1)
                MessageBox.Show("Invalid Email Address");
            else
                MessageBox.Show("@ found at position " + result.ToString());

            /*
            string example = "Some Text old text new text just text";
            example = example.Insert( 5, "More ");
            MessageBox.Show(example);
            */

            //remove and replace 
            /*
            string example = "Some Text old text new text just text";
            MessageBox.Show(example);
            string newexample = example.Remove(10, 9);
            MessageBox.Show(newexample, "Remove");
            newexample = example.Replace("text", "hicup");
            MessageBox.Show(newexample, "Replace");
            */

            //string email = "john.snow@gmail.com";
            int index = stringEmail.Length - 6;
            string value = stringEmail.Substring(index);
            if (value == ".co.uk")
                MessageBox.Show(value + ", " + index.ToString());
            else
                MessageBox.Show("Invalid email address");
        }

        private void BtnPadding_Click(object sender, EventArgs e)
        {
            string padding = tbPadding.Text;
            padding = padding.PadLeft(20,'-');
            tbPadding.Text = padding;
        }

        private void BtnSplitJoin_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string lineOfText = "item1, item2, item3, item4, item5";
            string[] wordArray = lineOfText.Split(',');

            listBox1.Items.Add(lineOfText);
            listBox1.Items.Add("---------------");
            foreach (string element in wordArray)
            {
                listBox1.Items.Add(element.Trim());
            }
            listBox1.Items.Add("---------------");
            string newline = String.Join(" &", wordArray);
            listBox1.Items.Add(newline);
        }

        private void TabTimes_MouseLeave(object sender, EventArgs e)
        {
            tabTimes.BackColor = Color.WhiteSmoke;
        }

        private void TabTimes_MouseEnter(object sender, EventArgs e)
        {
            tabTimes.BackColor = Color.GreenYellow;
        }

        private void TabTimes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MessageBox.Show("Left button clicked");
            else if (e.Button == MouseButtons.Right)
                MessageBox.Show("Right button clicked");
        }

        private void TbPadding_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
                MessageBox.Show(e.KeyValue.ToString());
        }

        private void TbLoopStart_Leave(object sender, EventArgs e)
        {
            if (tbLoopStart.Text == "")
            {
                MessageBox.Show("You can't leave this box blank");

                tbLoopStart.Focus();
            }
        }

        private void initialize_combobox()
        {
            string[] options = { "Cheque", "Credut Card", "PayPal" };
            //int index = 0;
            foreach (string choice in options)
            {
                cbPaymentTypes.Items.Add(choice);
            }
        }

        private void CbPaymentTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateOptions(cbPaymentTypes.SelectedIndex);
        }

        private void populateOptions(int index)
        {
            lbOptions.Items.Clear();

            string[] cheque = { "Business Cheque", "eCheque", "Pension Cheque"};
            string[] creditCard = {"American Express", "Discover", "Mastercard", "Visa"};
            string[] payPal = { };

            if (index == 0)
            {
                foreach (string option in cheque)
                    lbOptions.Items.Add(option);
            }
            else if (index == 1)
                foreach (string option in creditCard)
                    lbOptions.Items.Add(option);
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            string webPage = tbAddress.Text;
            if (webPage.Length > 4 && webPage.Substring(webPage.Length - 4) == ".com")
            {
                webBrowser1.Navigate(webPage);
            }
            
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
                webBrowser1.GoBack();
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
                webBrowser1.GoForward();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void BtnBack_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnBack, "Back One Page");
            btnBack.Image = imageList1.Images[20];
        }

        private void BtnForward_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnForward, "Forward One Page");
            btnForward.Image = imageList1.Images[21];
        }

        private void BtnHome_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnHome, "Go To Homepage");
            btnHome.Image = imageList1.Images[22];
        }

        private void BtnStop_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnStop, "Stop Loading");
            btnStop.Image = imageList1.Images[26];
        }

        private void BtnRefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnRefresh, "Refresh Page");
            btnRefresh.Image = imageList1.Images[25];
        }

        private void BtnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.Image = imageList1.Images[5];
        }

        private void BtnForward_MouseLeave(object sender, EventArgs e)
        {
            btnForward.Image = imageList1.Images[6];
        }

        private void BtnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.Image = imageList1.Images[23];
        }

        private void BtnStop_MouseLeave(object sender, EventArgs e)
        {
            btnStop.Image = imageList1.Images[9];
        }

        private void BtnRefresh_MouseLeave(object sender, EventArgs e)
        {
            btnRefresh.Image = imageList1.Images[24];
        }

        private void BtnHappyBday_Click(object sender, EventArgs e)
        {
            //HappyBirthday birthdayMessage = new HappyBirthday();
            // or
            //HappyBirthday birthdayMessage;
            //birthdayMessage = new HappyBirthday();

            //birthdayMessage.HaveParty = true;
            //birthdayMessage.PresentCount = 5;

            //birthdayMessage.myMessage = tbBirthday.Text;

            //MessageBox.Show(birthdayMessage.myMessage, "Classes 1st example");

            BirthdayParty partyOn = new BirthdayParty();

            MessageBox.Show(partyOn.getMessage(tbBirthday.Text), "Classes Inheritance");
            MessageBox.Show(partyOn.getPresents(8), "Classes Inheritance");
            MessageBox.Show(partyOn.getParty(true), "Classes Inheritance");
            MessageBox.Show(partyOn.getParty(true, "Ann"), "Classes Inheritance");

        }

        private void BtnStatic_Click(object sender, EventArgs e)
        {
            string answer;
            answer = stats.addUp(9, 13).ToString();
            MessageBox.Show(answer, "Static classes");
        }

        private void BtnReadFile_Click(object sender, EventArgs e)
        {
            string directory_path = "C:\\Users\\ReinisJ\\source\\repos\\WindowsForms_practise\\";
            string file_name = "example1.txt";
            string file_path = directory_path + file_name;

            //Check if file exists
            if (System.IO.File.Exists(file_path))
            {
                //Create StreamerReader obhect, that will contain our file
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(file_path);

                tbFile.Text = objReader.ReadToEnd(); //reads all content form StreamReaders object -> our file
                tbFile.Text = tbFile.Text + "\r\n";
                //read content from object/file line by line
                //int i = 1;
                //do
                //{
                //    tbFile.Text = tbFile.Text + i.ToString() + ". line: " + objReader.ReadLine() + "\r\n";
                //    i++;
                //} while (objReader.Peek() != -1); //Checks next carecter in object file, but don't consume it

                objReader.Close(); //closes our file/StreamReader
            }
            else
            {
                MessageBox.Show("File Not found!\n" + file_path, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReadLines_Click(object sender, EventArgs e)
        {
            string directory_path = "C:\\Users\\ReinisJ\\source\\repos\\WindowsForms_practise\\";
            string file_name = "example1.txt";
            string file_path = directory_path + file_name;

            tbFile.Text = ""; //Clear textBox if there was something in it


            //Check if file exists
            if (System.IO.File.Exists(file_path))
            {
                //Create StreamerReader object, that will contain our file
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(file_path);

                //tbFile.Text = objReader.ReadToEnd(); //reads all content form StreamReaders object -> our file

                //read content from object/file line by line
                int i = 1;
                do
                {
                    tbFile.Text = tbFile.Text + i.ToString() + ". line: " + objReader.ReadLine() + "\r\n";
                    i++;
                } while (objReader.Peek() != -1); //Checks next carecter in object file, but don't consume it

                objReader.Close(); //closes our file/StreamReader
            }
            else
            {
                MessageBox.Show("File Not found!\n" + file_path, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            string directory_path = "C:\\Users\\ReinisJ\\source\\repos\\WindowsForms_practise\\";
            string file_name = "example2.txt";
            string file_path = directory_path + file_name;

            //no need to check if file exists, because we will create it if it doesn't
            System.IO.StreamWriter ObjWriter = new System.IO.StreamWriter(file_path, true); //true means, that data will be appended to file; false -> data are over-written in file
            ObjWriter.Write(tbFile.Text); //writes all file at once
            ObjWriter.Close(); // always close file/object when you are done
        }

        private void BtnCopyFile_Click(object sender, EventArgs e)
        {
            string directory_path = "C:\\Users\\ReinisJ\\source\\repos\\WindowsForms_practise\\";
            string fileToCopy_name = "example1.txt";
            string fileToCopy_path = directory_path + fileToCopy_name;

            string new_directory = "C:\\Users\\ReinisJ\\Documents\\CopiedFiles\\";

            //check if directory where we want to copy file exists
            if (System.IO.Directory.Exists(new_directory))
            {
                //check if file we want to copy exists
                if (System.IO.File.Exists(fileToCopy_path))
                {
                    System.IO.File.Copy(fileToCopy_path, new_directory + fileToCopy_name, true); //copies file; ture will over-write existing file; false -> error if in destination that file existst
                    //System.IO.File.Move(fileToCopy_path, new_directory + fileToCopy_name, true); //moves file; sane applies to move
                }
                else
                {
                    MessageBox.Show("File Not found!\n" + fileToCopy_path, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Directory Not found!\n" + new_directory, "Destination Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteFile_Click(object sender, EventArgs e)
        {
            string directory_path = "C:\\Users\\ReinisJ\\Documents\\CopiedFiles\\";
            string file_name = "example1.txt";
            string file_path = directory_path + file_name;

            //Check if file exists
            if (System.IO.File.Exists(file_path))
            {
                System.IO.File.Delete(file_path);
            }
            else
            {
                MessageBox.Show("File Not found!\n" + file_path, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NavigateRecords()
        {
            dRow = ds.Tables[0].Rows[inc]; //selct row from data set

            txtFirstName.Text = dRow.ItemArray.GetValue(1).ToString();
            txtSurname.Text = dRow.ItemArray.GetValue(2).ToString();
            txtJobTitle.Text = dRow.ItemArray.GetValue(3).ToString();
            txtDepartment.Text = dRow.ItemArray.GetValue(4).ToString();

            UpdateInfo();
        }

        private void BtnFirstRecord_Click(object sender, EventArgs e)
        {
            if (inc > 0)
            {
                inc = 0;
                NavigateRecords();
            }
        }

        private void BtnPreviousRecord_Click(object sender, EventArgs e)
        {
            if (inc > 0)
            {
                inc--; // inc = inc - 1
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("Already at 1st record", "Out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnNextRecord_Click(object sender, EventArgs e)
        {
            if (inc < MaxRows - 1)
            {
                inc++; // inc = inc + 1
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("Already at last record", "Out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnLastRecord_Click(object sender, EventArgs e)
        {
            if (inc < MaxRows - 1)
            {
                inc = MaxRows - 1;
                NavigateRecords();
            }
        }

        private void BtnAddNew_Click_1(object sender, EventArgs e)
        {
            //clear text boxses so we can add a new entry
            txtFirstName.Clear();
            txtSurname.Clear();
            txtJobTitle.Clear();
            txtDepartment.Clear();

            //enables Save and Cancel buttons, to add a record or undo change. Disable Add New button while in adding mode
            btnAddNew.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            NavigateRecords();

            btnAddNew.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //actual saving/adding of record in SQL database and dataset

            //add row/entry to dataset
            DataRow row = ds.Tables[0].NewRow();

            row[1] = txtFirstName.Text;
            row[2] = txtSurname.Text;
            row[3] = txtJobTitle.Text;
            row[4] = txtDepartment.Text;

            ds.Tables[0].Rows.Add(row);

            //update database
            try
            {
                objConnect.UpdateDatabase(ds);
                ds = objConnect.GetConnection; // receive data set from our class, that makes it from data it gets from SQL database

                MaxRows++;
                inc = MaxRows - 1;
                UpdateInfo();

                MessageBox.Show("Database Updated!", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnAddNew.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

        }


        private void UpdateInfo()
        {
            lInfo.Text = "Record " + (inc + 1).ToString() + " of " + MaxRows.ToString();
        }

        private void BtnUpdate_Click_1(object sender, EventArgs e)
        {
            //
            DataRow row = ds.Tables[0].Rows[inc];
            row[1] = txtFirstName.Text;
            row[2] = txtSurname.Text;
            row[3] = txtJobTitle.Text;
            row[4] = txtDepartment.Text;

            //update database
            try
            {
                objConnect.UpdateDatabase(ds);

                MessageBox.Show("Record Updated!", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click_1(object sender, EventArgs e)
        {
            ds.Tables[0].Rows[inc].Delete();

            try
            {
                objConnect.UpdateDatabase(ds);

                MaxRows--;
                inc = inc - 1;
                NavigateRecords();

                MessageBox.Show("Record Deleted!", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        Form2 secondForm = new Form2();
        
        private void BtnFormTwo_Click(object sender, EventArgs e)
        {
            //create 2nd form, so it would be displayed when button clicked
            //secondForm.Show(); //shows second form, but can still work with the form1 as well


            secondForm.ShowDialog(); //shows second form, user unable to press any buttons in 1st form
                                     //if (secondForm.DialogResult == DialogResult.OK)
                                     //if (secondForm.ShowDialog() == DialogResult.OK)
                                     //{
                                     //MessageBox.Show("Button OK was pressed");
                                     //}

            
           
        }

        private void BtnDateTime_Click(object sender, EventArgs e)
        {
            DateTime theDate;
            //theDate = DateTime.Now;// date and time
            theDate = DateTime.Today; // date - time is 00:00.00
            DateTime firstDate = new DateTime(2013, 01, 14);
            TimeSpan dateDiff;
            dateDiff = theDate.Subtract(firstDate);
            //MessageBox.Show(theDate.ToString("D"), "Date & Time"); // "d" in ToSring("d") allows to show only date without time -> dd/mm/yyyy; "D" represents dd month yyyy
            MessageBox.Show("dateDiff: " + dateDiff.ToString());
        }
    }
}
