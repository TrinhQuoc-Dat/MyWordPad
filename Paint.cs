using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.AxHost;
namespace MyWordPad
{
    public partial class Paint : Form
    {
        private Form1 f; // Tham chiếu đến form chính (Form1)

        public Paint()
        {
            InitializeComponent();
        }

        public Paint(Form1 form1)
        {
            InitializeComponent();
            f = form1; // Khởi tạo tham chiếu đến form chính
        }

        Color color;
        int penWidth;
        Point POld;
        Bitmap bmp; // vẽ trên đó trước khi vẽ lên form

        private void Paint_Load(object sender, EventArgs e)
        {

            color = Color.Black;
            penWidth = 1;
            bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White); // Xóa màu nền bằng màu trắng
            }
            CreatebtnColor();
            lbPenWidth.Text = String.Format("Kích thước bút: {0}", penWidth);

        }

        // lưu vị trí con trỏ chuột khi nhấn xuống 
        private void Paint_MouseDown(object sender, MouseEventArgs e)
        {
            POld = e.Location;
        }

        // di chuyển chuột (vẽ)
        private void Paint_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Pen pen = new Pen(color, penWidth);
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                // lấy Graphics từ bitmap để vẽ
                Graphics g = Graphics.FromImage(bmp);
                // vẽ đường thẳng từ vị trí cũ đến vị trí mới 
                g.DrawLine(pen, POld, e.Location);
                // lưu vị trí mới là vị trí cũ để chuột di chuyển tiếp 
                POld = e.Location;
                // yêu cầu form vẽ lại 
                Invalidate();
            }
        }

        // chuyển hình ảnh từ bitmap lên form 
        private void Paint_Paint(object sender, PaintEventArgs e)
        {
            // vẽ bitmap lên Form 
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        // sử dụng các phím tắt để tuỳ chỉnh màu sắc, kích thước 
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.R: color = Color.Red; break;
                case Keys.G: color = Color.Green; break;
                case Keys.B: color = Color.Blue; break;
                case Keys.Up:
                    {
                        penWidth++;
                        lbPenWidth.Text = String.Format("Kích thước bút: {0}", penWidth);
                    }
                    break;
                case Keys.Down:
                    {
                        penWidth--;
                        if (penWidth <= 1) penWidth = 1;
                        lbPenWidth.Text = String.Format("Kích thước bút: {0}", penWidth);
                    }
                    break;
            }
            return true;
        }

        public Bitmap GetDrawing()
        {
            return bmp;
        }

        // khi form đóng, thực hiện chuyển hình ảnh sang form1
        private void Paint_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.ReceiveDrawing(bmp);
        }

        // tạo nhiều button để tuỳ chỉnh màu sắc pen 
        private void CreatebtnColor()
        {
            // tạo mảng chứa màu sắc 
            Color[] colors = {
    Color.Red, Color.Blue, Color.Green, Color.Black, Color.White,
    Color.Yellow, Color.Orange, Color.Purple, Color.Gray, Color.Brown, Color.Pink,
    Color.Cyan, Color.Magenta, Color.Turquoise, Color.Gold, Color.Silver,
    Color.Maroon, Color.Navy, Color.Teal, Color.Olive, Color.Indigo,
    Color.DarkRed, Color.DarkGreen, Color.DarkBlue
};

            int btnWidth = 25;
            int btnHeight = 25;
            int startX = 70;
            int startY = 10;
            int maxRow = 12; // Số lượng button trên mỗi hàng
            int currentRow = 0; // Số lượng button đã được thêm vào hàng hiện tại
            
            foreach (Color color in colors)
            {
                Button btnColor = new Button();
                btnColor.BackColor = color;
                btnColor.Size = new Size(btnWidth, btnHeight);
                btnColor.Location = new Point(startX, startY);
                btnColor.Click += btnColor_Click; // Gán sự kiện click cho mỗi ô màu
                this.Controls.Add(btnColor);

                // Di chuyển sang phải để tạo ô màu tiếp theo
                startX += btnWidth + 2;

                currentRow++; // Tăng số lượng button trong hàng hiện tại

                // Nếu đã đạt đến số lượng button trên mỗi hàng, di chuyển xuống hàng mới
                if (currentRow >= maxRow)
                {
                    startY += btnHeight + 2; // Tăng khoảng cách startY
                    startX = 70; // Reset startX về vị trí ban đầu
                    currentRow = 0; // Reset số lượng button trong hàng hiện tại
                }
            }

           
        }
        // gán sự kiện click cho button
        private void btnColor_Click(object sender, EventArgs e)
        {
            Button btnColor = (Button)sender;
            if (btnColor != null)
            {
                color = btnColor.BackColor; // Thiết lập màu bút thành màu của ô màu đã chọn
                lbColorPen.BackColor = color;
            }
        }

        // tăng kích thước penWidth
        private void picIncrease_Click(object sender, EventArgs e)
        {
            penWidth++;
            lbPenWidth.Text = String.Format("Kích thước bút: {0}", penWidth);
        }

        // giảm kích thước penWidth
        private void picDecrease_Click(object sender, EventArgs e)
        {
            penWidth--;
            if (penWidth <= 1) penWidth = 1;
            lbPenWidth.Text = String.Format("Kích thước bút: {0}", penWidth);
        }
    }

}
