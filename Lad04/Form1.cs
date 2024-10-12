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
        public partial class Form1 : Form
        {
            List<String> lst = new List<String>();
            Model1 db = new Model1();

        public Form1()
        {
            InitializeComponent();
            LoaddataKhoa(); // Tải dữ liệu vào ComboBox khi form được khởi tạo
            Loaddata();
            dgvShow.CellClick += dgvShow_CellClick;
        }

        private void LoaddataKhoa()
        {

            

            cmbKhoa.DataSource = db.Khoas.ToList(); // Gán danh sách khoa vào ComboBox
            cmbKhoa.DisplayMember = "tenkhoa"; // Hiển thị tên khoa
            cmbKhoa.ValueMember = "makhoa";    // Lấy mã khoa
        }



        private void Saveoff()
                {
                   
                    if (db == null)
                    {
                        MessageBox.Show("Database context is not initialized.");
                        return;
                    }

                    if (cmbKhoa.SelectedValue == null)
                    {
                        MessageBox.Show("Please choose a valid department.");
                        return;
                    }
                    
                    if (!decimal.TryParse(txtDiem.Text, out decimal diem))
                    {
                        MessageBox.Show("Score must be a valid number.");
                        return;
                    }

                    sinhvien sv = new sinhvien
                    {
                        ma = txtMssv.Text,
                        hoten = txtName.Text,
                        dtb = diem,
                        makhoa = (int)cmbKhoa.SelectedValue
                    };


                    db.sinhviens.Add(sv);
                    db.SaveChanges();
                    MessageBox.Show("Save successful");
                    Loaddata();
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

                dgvShow.DataSource = query.ToList();     
            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                if(string.IsNullOrWhiteSpace(txtMssv.Text) || string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtDiem.Text))
                {
                    MessageBox.Show("Please enter name and age");
                    return;
                }

                // kiem tra them cmbkhoa khong ko duoc phep ko chon
                if (cmbKhoa.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose a department");
                    return;
                }

                // kiem tra diem co phai la so ko
                if (!double.TryParse(txtDiem.Text, out double diem))
                {
                    MessageBox.Show("Score must be a number");
                    return;
                }

                // kiem tra diem co nam trong khoang 0-10 ko
                if (diem < 0 || diem > 10)
                {
                    MessageBox.Show("Score must be between 0 and 10");
                    return;
                }

                Saveoff();
                Loaddata();
                txtMssv.Clear();
                txtName.Clear();
                txtDiem.Clear();
                cmbKhoa.SelectedIndex = -1;
        }

        private void btnFix_Click(object sender, EventArgs e)
        {

            // chọn và cập nhật lại dữ liệu của sinh viên
            if (string.IsNullOrWhiteSpace(txtMssv.Text) || string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show("Please enter name and age");
                return;
            }
            // kiem tra them cmbkhoa khong duoc phep ko chon
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a department");
                return;
            }
            // kiem tra diem co phai la so ko
            if (!decimal.TryParse(txtDiem.Text, out decimal diem))
            {
                MessageBox.Show("Score must be a valid number");
                return;
            }

            // Kiểm tra điểm có nằm trong khoảng 0-10 không
            if (diem < 0 || diem > 10)
            {
                MessageBox.Show("Score must be between 0 and 10");
                return;
            }

            // Kiểm tra và cập nhật thông tin sinh vien nếu tồn tại
            
            var sv = db.sinhviens.Find(txtMssv.Text);
            if (sv != null)
            {
                // Cập nhật thông tin sinh viên
                sv.hoten = txtName.Text; // Cập nhật tên
                sv.dtb = diem; // Cập nhật điểm
                sv.makhoa = (int)cmbKhoa.SelectedValue; // Cập nhật khoa
                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                MessageBox.Show("Thông tin sinh viên đã được cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Sinh viên không tồn tại.");
            }

            Loaddata();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            // xóa sinh viên khỏi cơ sở dữ liệu
            sinhvien sv = db.sinhviens.Find(txtMssv.Text);
            if (sv != null)
            {
                db.sinhviens.Remove(sv);
                db.SaveChanges();
                MessageBox.Show("Delete successful");
                Loaddata();
            }
            else
            {
                MessageBox.Show("Student not found");
            }
        }

        private void btnBrk_Click(object sender, EventArgs e)
        {
            //thoát khỏi chương trình 
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có chọn phải hàng không
            if (e.RowIndex >= 0) // e.RowIndex < 0 sẽ không phải là một hàng
            {
                // Lấy thông tin từ hàng được chọn
                DataGridViewRow row = dgvShow.Rows[e.RowIndex];

                // Điền thông tin vào các ô nhập liệu
                txtMssv.Text = row.Cells[0].Value?.ToString(); // MSSV
                txtName.Text = row.Cells[1].Value?.ToString(); // Tên sinh viên
                txtDiem.Text = row.Cells[3].Value?.ToString(); // Điểm
                                                               // Lấy tenkhoa từ hàng được chọn
                string tenkhoa = row.Cells[2].Value?.ToString();

                // Truy vấn để lấy makhoa từ tenkhoa
                var khoa = db.Khoas.FirstOrDefault(k => k.tenkhoa == tenkhoa);
                if (khoa != null)
                {
                    cmbKhoa.SelectedValue = khoa.makhoa; // Gán giá trị makhoa vào ComboBox
                }// Khoa (giả định đã gán đúng SelectedValue)
            }
        }

        private void btnkhoa_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            // LOAD LOẠI DỮ LIỆU KHI FORM2 ĐÓNG LẠI
            form.FormClosed += (s, ev) =>
            {
                LoaddataKhoa();
            };

        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            // LOAD LOẠI DỮ LIỆU KHI FORM2 ĐÓNG LẠI
            form.FormClosed += (s, ev) =>
            {
                LoaddataKhoa();
            };
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            form3.FormClosed += (s, ev) =>
            {
                LoaddataKhoa();
            };
        }
    }
}
