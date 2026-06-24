using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMS2026
{
    public partial class EnrollmentForm : Form
    {
        public EnrollmentForm()
        {
            InitializeComponent();
        }

        private void takesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.takesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.universityDataSet);

        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'universityDataSet.takes' table. You can move, or remove it, as needed.
            this.takesTableAdapter.Fill(this.universityDataSet.takes);

        }
    }
}
