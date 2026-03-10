using System;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class ExtendRentalForm : Form
    {
        public DateTime NewEndDate { get; private set; }

        public ExtendRentalForm(DateTime currentEndDate)
        {
            InitializeComponent();
            dtpNewEndDate.MinDate = currentEndDate.AddDays(1);
            dtpNewEndDate.Value = currentEndDate.AddDays(7);
            lblCurrentEndDate.Text = $"Текущая дата окончания: {currentEndDate:dd.MM.yyyy}";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            NewEndDate = dtpNewEndDate.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}