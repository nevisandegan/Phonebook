using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prozhe_DB
{
    public partial class Form1 : Form
    {
        IContactRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dg.AutoGenerateColumns = false;
            dg.DataSource = repository.SelectAll();
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bntrefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddOrEdit frm = new AddOrEdit();
            frm.ShowDialog();
            if(frm.DialogResult==DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(dg.CurrentRow!=null)
            {
                string name = dg.CurrentRow.Cells[1].Value.ToString();
                string family = dg.CurrentRow.Cells[2].Value.ToString();
                string fullname = name + " " + family;

                if (MessageBox.Show($"ایا از حذف {fullname} مطمن هستید؟","توجه",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int contactid = int.Parse(dg.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(contactid);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را از لیست انتخاب کنید");
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if(dg.CurrentRow!=null)
            {
                int contactid = int.Parse(dg.CurrentRow.Cells[0].Value.ToString());
                AddOrEdit frm = new AddOrEdit();
                frm.contactid = contactid;
                if(frm.ShowDialog()==DialogResult.OK)
                {
                    BindGrid();
                }
            }
            else
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = repository.search(txtSearch.Text);
        }
    }
}
