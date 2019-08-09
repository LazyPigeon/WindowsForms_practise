using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace WindowsForms_practise
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string changeCase = Practise_app.tb.Text;



            //change case
            if (rbUpperCase.Checked) // if (rbUpperCase.Checked == true) 
                changeCase = changeCase.ToUpper();
            else if (rbLowerCase.Checked) // else if (rbLowerCase.Checked == true) 
                changeCase = changeCase.ToLower();
            else if (rbProperCase.Checked) // else if (rbProperCase.Checked) 
            {
                CultureInfo properCase = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfoObject = properCase.TextInfo;

                changeCase = textInfoObject.ToTitleCase(changeCase);
            }

            Practise_app.tb.Text = changeCase;
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
