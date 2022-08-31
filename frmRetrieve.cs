using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_KPI
{
    public partial class frmRetrieve : Form
    {
        public frmRetrieve()
        {
            InitializeComponent();
        }
      
        public List<dynamic> records = new List<dynamic>();

        private void btnRetrieveLB_Click(object sender, EventArgs e)
        {
            recordList();

            foreach (var record in records) 
            {
             
                lbDisplay.Items.Add($"{record.ID}, {record.Name}, {record.Completion}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
            int recordSelect = (int.Parse(cbChoice.Text)-1);

            recordList();
            lblNameout.Text = records.ElementAt(recordSelect).Name;
            lblCompout.Text = records.ElementAt(recordSelect).Completion;
            pbComp.Value = int.Parse(records.ElementAt(recordSelect).Completion);
        }

        private void frmRetrieve_Load(object sender, EventArgs e)
        {
            recordList();
            foreach (var record in records)
            {
                cbChoice.Items.Add($"{record.ID}");
            }
        }

        public void recordList()
        {
            try
            {
               
                using (var fileRead = new StreamReader("StudentCompletion.csv"))

                using (var csv = new CsvReader(fileRead, CultureInfo.InvariantCulture))
                {
                 
                    records = csv.GetRecords<dynamic>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error: ", ex);
            }
        }
    }
}
