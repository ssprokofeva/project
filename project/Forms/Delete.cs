using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Delete : Form
    {
        private int exhibitionId;
        public Delete(int id, string exhibitionName)
        {
            InitializeComponent();
            exhibitionId = id;
            lblMessage.Text = $"Вы действительно хотите удалить выставку '{exhibitionName}'?";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }
    }
}
