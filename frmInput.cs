using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_KPI
{
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            addRecord(int.Parse(tbID.Text), tbName.Text, int.Parse(tbCompletion.Text));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bool myCondition = true;

           
            if (MessageBox.Show("You are about to clear your form, Do you wish to continue?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, myCondition ? MessageBoxDefaultButton.Button2 : MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                tbID.Text = "";
                tbName.Text = "";
                tbCompletion.Text = "";
            }
        }

        public static void addRecord(int iID, string sName, int iCompletion)
        {
            
            try
            {
                
                using (StreamWriter file = new StreamWriter("StudentCompletion.csv", true))
                {
                   
                    file.WriteLine($"{iID},{sName},{iCompletion}");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error: ", ex);
            }
        }

        private void frmInput_Load(object sender, EventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            frmRetrieve newForm = new frmRetrieve();
            this.Hide();
            newForm.Show();
        }
    }
}
