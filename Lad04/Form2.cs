using Lad04.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lad04
{
    public partial class Form2 : Form
    {
        Model1 db = new Model1();
        public Form2()
        {
            InitializeComponent();
            Loaddata();
        }

        private void Loaddata()
        {
            var khoas = from k in db.Khoas
                        select new
                        {
                            ma = k.makhoa,
                            ten = k.tenkhoa,
                            tong = k.tongGs
                        };
            dgvkhoa.DataSource = db.Khoas.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMkhoa.Text == "" || txtNameKhoa.Text == "" || txtGs.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            Khoa khoa = new Khoa
            {
                
                makhoa = int.Parse(txtMkhoa.Text),
                tenkhoa = txtNameKhoa.Text,
                tongGs = int.Parse(txtGs.Text)
            };
            db.Khoas.Add(khoa);
            db.SaveChanges();
            Loaddata();
            MessageBox.Show("Save successful");
        }


        private void btnOut_Click(object sender, EventArgs e)
        {
            //xóa khoa trong datagridview và database
            // khi chọn ở dgv thì nó sẽ hiện lại thông tin ở các textbox 

            if (dgvkhoa.SelectedRows.Count > 0)
            {
                
                if (MessageBox.Show("Are you sure to delete this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // xóa d?ng d?ng ch?n
                    int index = dgvkhoa.SelectedRows[0].Index;
                    int makhoa = int.Parse(dgvkhoa.Rows[index].Cells[0].Value.ToString());
                    Khoa khoa = db.Khoas.Find(makhoa);
                    db.Khoas.Remove(khoa);
                    db.SaveChanges();
                    Loaddata();
                    MessageBox.Show("Delete successful");
                }
            }
        }

        private void btnBrk_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
