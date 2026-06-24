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
    public partial class SchedulingForm : Form
    {
        public SchedulingForm()
        {
            InitializeComponent();
        }

        private void time_slotBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.time_slotBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.universityDataSet);

        }

        private void SchedulingForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'universityDataSet.time_slot' table. You can move, or remove it, as needed.
            this.time_slotTableAdapter.Fill(this.universityDataSet.time_slot);

        }
    }
}
