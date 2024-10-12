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
    public partial class Form3 : Form
    {
        Model1 db = new Model1();
        int tong = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void LoaddataKhoa()
        {
            cmbKhoa.DataSource = db.Khoas.ToList(); // Gán danh sách khoa vào ComboBox
            cmbKhoa.DisplayMember = "tenkhoa"; // Hiển thị tên khoa
            cmbKhoa.ValueMember = "makhoa";    // Lấy mã khoa
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có nhập ít nhất một trong ba trường
            if (string.IsNullOrEmpty(txtMssv.Text) && string.IsNullOrEmpty(txtName.Text) && cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill at least one field or select a department");
                return;
            }

            string mssv = txtMssv.Text;
            string name = txtName.Text;

            // Lấy tên khoa từ ComboBox
            string tenKhoa = cmbKhoa.Text;

            // Truy vấn để lấy mã khoa dựa trên tên khoa
            var selectedKhoa = db.Khoas.FirstOrDefault(k => k.tenkhoa == tenKhoa);
            if (selectedKhoa == null)
            {
                MessageBox.Show("Khoa không tồn tại.");
                return;
            }

            // Lấy mã khoa từ kết quả truy vấn
            int makhoa = selectedKhoa.makhoa;

            // Tạo truy vấn cơ bản từ danh sách sinh viên
            var query = db.sinhviens.AsQueryable();

            // Tìm kiếm theo mã sinh viên nếu có
            if (!string.IsNullOrEmpty(mssv))
            {
                query = query.Where(s => s.ma == mssv);
            }

            // Tìm kiếm theo tên sinh viên nếu có
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.hoten.Contains(name));
            }

            // Tìm kiếm theo mã khoa đã lấy được từ tên khoa
            query = query.Where(s => s.makhoa == makhoa);

            var students = query.ToList();

            if (students.Any())
            {
                // Hiển thị thông tin sinh viên trong DataGridView
                var relatedData = from s in students
                                  join k in db.Khoas on s.makhoa equals k.makhoa
                                  select new
                                  {
                                      massv = s.ma,
                                      hovaten = s.hoten,
                                      khoa = k.tenkhoa,
                                      diemtb = s.dtb
                                  };

                dgvtimkiem.DataSource = relatedData.ToList();
            }
            else
            {
                // Thông báo nếu không có sinh viên phù hợp
                MessageBox.Show("Không tìm thấy sinh viên nào thuộc khoa này.");
            }
        }




        private void Loaddata()
        {
            // load data from database
            var query = from s in db.sinhviens
                        join k in db.Khoas on s.makhoa equals k.makhoa
                        select new
                        {
                            massv = s.ma,
                            hovaten = s.hoten,
                            khoa = k.tenkhoa,
                            diemtb = s.dtb
                        };

            dgvtimkiem.DataSource = query.ToList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            
        }

        
    }
    
}
