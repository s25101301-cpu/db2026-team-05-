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
    public partial class DepartmentForm : Form
    {
        public DepartmentForm()
        {
            InitializeComponent();
        }

        private void departmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.departmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.universityDataSet);

        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'universityDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.universityDataSet.department);

        }
    }
}
