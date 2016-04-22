using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmAdder : Form
    {
        public frmAdder()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int num1, num2;
            int sum;
            try
            {
                num1 = int.Parse(txtX.Text);
                num2 = int.Parse(txtY.Text);
                sum = num1 + num2;
                txtSum.Text = Convert.ToString(sum);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }

        }
    }
}
