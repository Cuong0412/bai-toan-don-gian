using System;
using System.Windows.Forms;
using MyLibrary; // Tham chiếu đến DLL

namespace YourNamespace
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tạo và hiển thị form chính
            Form1 form = new Form1();
            Application.Run(form);
        }
    }

    public class Form1 : Form
    {
        private TextBox txtNum1;
        private TextBox txtNum2;
        private Button btnCalculate;
        private Label lblResult;

        public Form1()
        {
            // Khởi tạo các điều khiển
            txtNum1 = new TextBox { Location = new System.Drawing.Point(20, 20) };
            txtNum2 = new TextBox { Location = new System.Drawing.Point(20, 60) };
            btnCalculate = new Button
            {
                Text = "Tính Tổng",
                Location = new System.Drawing.Point(20, 100)
            };
            lblResult = new Label { Location = new System.Drawing.Point(20, 140), AutoSize = true };

            // Thêm các điều khiển vào form
            this.Controls.Add(txtNum1);
            this.Controls.Add(txtNum2);
            this.Controls.Add(btnCalculate);
            this.Controls.Add(lblResult);

            // Gán sự kiện click cho nút
            btnCalculate.Click += BtnCalculate_Click;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            int num1, num2;
            bool isNum1Valid = int.TryParse(txtNum1.Text, out num1);
            bool isNum2Valid = int.TryParse(txtNum2.Text, out num2);

            if (isNum1Valid && isNum2Valid)
            {
                try
                {
                    // Tạo đối tượng Calculator từ DLL và tính tổng
                    Calculator calculator = new Calculator();
                    int sum = calculator.Add(num1, num2);

                    // Hiển thị kết quả trong Label
                    lblResult.Text = "Tổng của hai số là: " + sum;

                    // Thay đổi thuộc tính của Label
                    lblResult.ForeColor = System.Drawing.Color.Blue; // Đổi màu chữ
                    lblResult.Font = new System.Drawing.Font(lblResult.Font.FontFamily, 16, System.Drawing.FontStyle.Bold); // Làm đậm và đổi kích thước chữ
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi bất kỳ khác (nếu có)
                    lblResult.Text = "Đã xảy ra lỗi: " + ex.Message;
                    lblResult.ForeColor = System.Drawing.Color.Red; // Đổi màu chữ lỗi
                    lblResult.Font = new System.Drawing.Font(lblResult.Font.FontFamily, 16, System.Drawing.FontStyle.Bold); // Làm đậm và đổi kích thước chữ lỗi
                }
            }
            else
            {
                // Xử lý lỗi khi người dùng nhập giá trị không hợp lệ
                lblResult.Text = "Vui lòng nhập số hợp lệ.";
                lblResult.ForeColor = System.Drawing.Color.Red; // Đổi màu chữ lỗi
                lblResult.Font = new System.Drawing.Font(lblResult.Font.FontFamily, 16, System.Drawing.FontStyle.Bold); // Làm đậm và đổi kích thước chữ lỗi
            }
        }
    }
}
