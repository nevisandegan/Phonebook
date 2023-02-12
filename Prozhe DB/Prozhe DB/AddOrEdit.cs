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
    public partial class AddOrEdit : Form
    {
        IContactRepository repository;
        public int contactid = 0;
        public AddOrEdit()
        {
            repository = new ContactRepository();
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddOrEdit_Load(object sender, EventArgs e)
        {
            if(contactid==0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                DataTable dt = repository.SelectRow(contactid);
                txtname.Text = dt.Rows[0][1].ToString();
                txtfamily.Text = dt.Rows[0][2].ToString();
                txtmobile.Text = dt.Rows[0][3].ToString();
                txtemail.Text = dt.Rows[0][4].ToString();
            }
        }
        bool validateinputs()
        {
            if(txtname.Text=="")
            {
              
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtfamily.Text == "")
            {
                
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtmobile.Text == "")
            {
                
                MessageBox.Show("لطفا موبایل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtemail.Text == "")
            {
               
                MessageBox.Show("لطفا ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            if(validateinputs())
            {
                bool isSuccess;

                if(contactid==0)
                {
                    isSuccess = repository.insert(txtname.Text, txtfamily.Text, txtmobile.Text, txtemail.Text);
                }

                else
                {
                    isSuccess = repository.Update(contactid, txtname.Text, txtfamily.Text, txtmobile.Text, txtemail.Text);
                }

                if(isSuccess == true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت");
                  DialogResult=  DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات ناموفق", "خطا");
                }
            }
        }
    }
}
 