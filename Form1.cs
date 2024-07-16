using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;
using System.Runtime.InteropServices;
using Image = System.Drawing.Image;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using ComboBox = System.Windows.Forms.ComboBox;
namespace MyWordPad
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public static Form1 instance2;
        public static string timeNow = "";
        public Image selectedImage;
        string copy = "";
        int sizeChu = 12;
        private int lastFoundIndex = 0;
        private bool matchWholeWord = false; //cờ chức năng khớp toàn bộ từ  "category".  "cat" 
        private bool matchCase = false; // cờ chức năng khớp chữ hoa/chữ thường

        public Form1()
        {
            InitializeComponent();
            instance = this;

        }
        Point p;
        private void Form1_Load(object sender, EventArgs e)
        {
            cbWrap.SelectedIndex = 0;
            tabControl1.SelectedTab = tabPage1;
            menuStrip1.BringToFront();
            LoadFontToComboBox();
            LoadSizeToComboBox();
            LoadFlowLayoutPanel();
            CursorsHand();
            LoadFlowLayoutPanel2();
            // giá trị thụt dòng cố định bên trái
            rtbText.SelectionIndent = 40;
            // bên phải
            rtbText.SelectionRightIndent = 40;
            int currentSelectionIndent = rtbText.SelectionIndent;

            rtbText.ScrollBars = RichTextBoxScrollBars.Vertical;
            p = rtbText.Location;
        }
        // biểu tượng bàn tay khi rê chuột 
        private void CursorsHand()
        {
            pnCopy.Cursor = Cursors.Hand;
            picCopy.Cursor = Cursors.Hand;
            lblCopy.Cursor = Cursors.Hand;

            pnPaste.Cursor = Cursors.Hand;
            picPaste.Cursor = Cursors.Hand;
            lblpaste.Cursor = Cursors.Hand;

            pnCut.Cursor = Cursors.Hand;
            picCut.Cursor = Cursors.Hand;
            lblCut.Cursor = Cursors.Hand;

            cbFont.Cursor = Cursors.Hand;
            cbSize.Cursor = Cursors.Hand;
            btnBold.Cursor = Cursors.Hand;
            btnItalic.Cursor = Cursors.Hand;
            btnUnderLine.Cursor = Cursors.Hand;

            picPicture.Cursor = Cursors.Hand;
            picDateTime.Cursor = Cursors.Hand;
            btDatetime.Cursor = Cursors.Hand;
            btnFind.Cursor = Cursors.Hand;
            picFind.Cursor = Cursors.Hand;
            btnReplace.Cursor = Cursors.Hand;
            picReplace.Cursor = Cursors.Hand;
            btnSelectAll.Cursor = Cursors.Hand;
            picSelectAll.Cursor = Cursors.Hand;
            picZoomIn.Cursor = Cursors.Hand;
            lbZoomIn.Cursor = Cursors.Hand;
            picZoomOut.Cursor = Cursors.Hand;
            lbZoomOut.Cursor = Cursors.Hand;
            picPercent.Cursor = Cursors.Hand;
            lbPercent.Cursor = Cursors.Hand;
            cbBar.Cursor = Cursors.Hand;
            cbWrap.Cursor = Cursors.Hand;
            btnPaint.Cursor = Cursors.Hand;
            picPaint.Cursor = Cursors.Hand;

            picZoomIn2.Cursor = Cursors.Hand;
            picZoomOut2.Cursor = Cursors.Hand;


            tsForeColor.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsForeColor.MouseLeave += ToolStripItem_MouseLeave_Default;

            tsBackColor.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsBackColor.MouseLeave += ToolStripItem_MouseLeave_Default;

            tsDecreaseIndent.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsDecreaseIndent.MouseLeave += ToolStripItem_MouseLeave_Default;

            tsIncreaseIndent.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsIncreaseIndent.MouseLeave += ToolStripItem_MouseLeave_Default;

            toolStripDropDownButton1.MouseEnter += ToolStripItem_MouseEnter_Hand;
            toolStripDropDownButton1.MouseLeave += ToolStripItem_MouseLeave_Default;

            tsLineSpacing.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsLineSpacing.MouseLeave += ToolStripItem_MouseLeave_Default;

            tsbtnAlignLeft.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsbtnAlignLeft.MouseLeave += ToolStripItem_MouseLeave_Default;

            tsbtnAlignRight.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsbtnAlignRight.MouseLeave += ToolStripItem_MouseLeave_Default;

            tsbtnCenter.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsbtnCenter.MouseLeave += ToolStripItem_MouseLeave_Default;

            tsbtnParagraph.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsbtnParagraph.MouseLeave += ToolStripItem_MouseLeave_Default;

            tsPicture.MouseEnter += ToolStripItem_MouseEnter_Hand;
            tsPicture.MouseLeave += ToolStripItem_MouseLeave_Default;

        }

        // sự kiện tự tạo để tạo bàn tay khi rê chuột vào
        private void ToolStripItem_MouseEnter_Hand(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        // sự kiện tự tạo để tắt bàn tay khi rê chuột ra
        private void ToolStripItem_MouseLeave_Default(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        // Mở word đã có sẵn
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtbText.Text = "";
            OpenFileDialog odlg = new OpenFileDialog();
            odlg.Filter = "All Files (*.*)|*.*|Text Files (*.txt)|*.txt|Word Files (*.docx)|*.docx";
            if (odlg.ShowDialog() == DialogResult.OK)
            {
                rtbText.Text = File.ReadAllText(odlg.FileName);
                CurrentAlignment();
            }
        }

        // tạo mới wordPad
        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtbText.Text = "";
        }

        // lưu file wordpad hiện tại 
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sdlg = new SaveFileDialog();
                sdlg.Filter = "Word (*.docx) | *.docx " +
                    "| PDF file (*.pdf) |*.pdf | NotePad File (*.txt) | *.txt";
                if (sdlg.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sdlg.FileName, rtbText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // in file wordpad
        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog pdlg = new PrintDialog();
                pdlg.Document = printDocument1;
                if (pdlg.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Tạo một đối tượng Graphics từ trang in
            using (Graphics g = e.Graphics)
            {
                // Xác định vùng in trên trang giấy
                RectangleF area = e.PageSettings.PrintableArea;

                // Tính kích thước của văn bản sẽ được vẽ
                SizeF textSize = g.MeasureString(rtbText.Text, rtbText.Font, (int)area.Width);

                // Vẽ nội dung của RichTextBox
                g.DrawString(rtbText.Text, rtbText.Font, Brushes.Black, area.Location);

                // Kiểm tra xem nội dung có còn trang nào không
                if (textSize.Height > area.Height)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
        }

        // in đậm text
        private void btnBold_Click(object sender, EventArgs e)
        {
            if (rtbText.SelectedText != null)
            {
                // Lấy font hiện tại của văn bản được chọn
                Font currentFont = rtbText.SelectionFont;
                // Xác định kiểu font mới bằng cách thực hiện XOR giữa FontStyle hiện tại và FontStyle.Italic
                FontStyle newFont = currentFont.Style ^ FontStyle.Bold; // ^ XOR
                rtbText.SelectionFont = new Font(currentFont, newFont);
                rtbText.Focus();
            }
        }
        // chữ dưới
        bool flag1 = false;
        private void btChuDuoi_Click(object sender, EventArgs e)
        {
            if (rtbText.SelectedText != null)
            {

                if (!flag1) //|| flag2
                {
                    btChuTren.BackColor = Color.LightGray;
                    btChuDuoi.BackColor = Color.LightBlue;
                    rtbText.SelectionCharOffset = -5; // Đặt lệch ký tự để chữ nhỏ dưới chân
                    rtbText.SelectionFont = new Font(rtbText.Font.FontFamily, int.Parse(cbSize.SelectedItem.ToString()) / 2); // Đặt font chữ

                }
                else
                {
                    btChuTren.BackColor = Color.LightGray;
                    btChuDuoi.BackColor = Color.LightGray;
                    rtbText.SelectionFont = new Font(rtbText.Font.FontFamily, int.Parse(cbSize.SelectedItem.ToString())); // Đặt font chữ
                    rtbText.SelectionCharOffset = 0;

                }
                rtbText.Focus();
                flag1 = !flag1;

            }
        }
        // chữ trên 
        bool flag2 = false;
        private void btChuTren_Click(object sender, EventArgs e)
        {
            if (rtbText.SelectedText != null)
            {
                if (!flag2) //|| flag1
                {
                    btChuDuoi.BackColor = Color.LightGray;
                    btChuTren.BackColor = Color.LightBlue;
                    rtbText.SelectionCharOffset = int.Parse(cbSize.SelectedItem.ToString()) / 2; // Đặt lệch ký tự để chữ nhỏ
                    rtbText.SelectionFont = new Font(rtbText.Font.FontFamily, int.Parse(cbSize.SelectedItem.ToString()) / 2); // Đặt font chữ
                }
                else
                {
                    btChuTren.BackColor = Color.LightGray;
                    btChuDuoi.BackColor = Color.LightGray;
                    rtbText.SelectionFont = new Font(rtbText.Font.FontFamily, int.Parse(cbSize.SelectedItem.ToString())); // Đặt font chữ
                    rtbText.SelectionCharOffset = 0;

                }
                rtbText.Focus();
                flag2 = !flag2;

            }
        }
        // gạch chữ
        bool flag = false;
        private void btGachChu_Click(object sender, EventArgs e)
        {
            if (rtbText.SelectedText != null)
            {
                btGachChu.BackColor = Color.LightBlue;
                // Lấy font hiện tại của văn bản được chọn
                if (!flag)
                    btGachChu.BackColor = Color.LightBlue;
                else
                    btGachChu.BackColor = Color.LightGray;
                Font currentFont = rtbText.SelectionFont;

                FontStyle newFont = currentFont.Style ^ FontStyle.Strikeout;
                rtbText.SelectionFont = new Font(currentFont, newFont);
                rtbText.Focus();
                flag = !flag;
            }
        }

        //in nghiêng text
        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (rtbText.SelectedText != null)
            {
                // Lấy font hiện tại của văn bản được chọn
                Font currentFont = rtbText.SelectionFont;

                // Xác định kiểu font mới bằng cách thực hiện XOR giữa FontStyle hiện tại và FontStyle.Italic
                FontStyle newFont = currentFont.Style ^ FontStyle.Italic;

                rtbText.SelectionFont = new Font(currentFont, newFont);
                rtbText.Focus();
            }
        }

        // gạch dươi text
        private void btnUnderLine_Click(object sender, EventArgs e)
        {
            if (rtbText.SelectedText != null)
            {
                // Lấy font hiện tại của văn bản được chọn
                Font currentFont = rtbText.SelectionFont;

                FontStyle newFont = currentFont.Style ^ FontStyle.Underline;
                rtbText.SelectionFont = new Font(currentFont, newFont);
                rtbText.Focus();
            }
        }

        // tạo danh sách các font chữ 
        private void LoadFontToComboBox()
        {
            // Lấy các font có sẵn trong hệ thống
            foreach (FontFamily font in FontFamily.Families)
                cbFont.Items.Add(font.Name);
            cbFont.SelectedItem = this.Font.Name;  // Đặt mục được chọn trong ComboBox là tên của font hiện tại của ứng dụng
        }

        // áp dụng font chữ đã lấy cho document
        //private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cbFont.SelectedItem != null)
        //        {
        //            string fontname = cbFont.SelectedItem.ToString();
        //            float fontsize = rtbText.SelectionFont.Size; // lấy kích thước hiện tại
        //            Font f = new Font(fontname, fontsize, rtbText.SelectionFont.Style);

        //            rtbText.SelectionFont = f;
        //            rtbText.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbFont.SelectedItem != null)
                {
                    string fontname = cbFont.SelectedItem.ToString();
                    float fontsize;

                    // Kiểm tra xem có vùng chọn hay không
                    if (rtbText.SelectionLength > 0)
                    {
                        // Lấy kích thước từ SelectionFont nếu có vùng chọn
                        fontsize = rtbText.SelectionFont.Size;
                    }
                    else
                    {
                        // Sử dụng kích thước mặc định nếu không có vùng chọn
                        fontsize = rtbText.Font.Size;
                    }

                    Font f = new Font(fontname, fontsize, rtbText.SelectionFont.Style);
                    rtbText.SelectionFont = f;
                    rtbText.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // khi nhập không đúng kiểu font, trả về font mặc đinh: times new roman
        private void cbFont_Validating(object sender, CancelEventArgs e)
        {
            string selectedFontName = cbFont.Text;

            try
            {
                // Kiểm tra xem font có tồn tại trong hệ thống không
                if (!IsFontAvailable(selectedFontName))
                {
                    cbFont.Text = "Times New Roman";
                    // Nếu không tồn tại, chuyển đổi thành font "Times New Roman"
                    string fontname = cbFont.Text;
                    float fontsize = rtbText.SelectionFont.Size; // lấy kích thước hiện tại
                    Font f = new Font(fontname, fontsize, rtbText.SelectionFont.Style);

                    rtbText.SelectionFont = f;
                    rtbText.Focus();
                }
            }
            catch (FormatException)
            {
                cbFont.Text = "Times New Roman";
                string fontname = cbFont.Text;
                float fontsize = rtbText.SelectionFont.Size; // lấy kích thước hiện tại
                Font f = new Font(fontname, fontsize, rtbText.SelectionFont.Style);
                rtbText.SelectionFont = f;
                rtbText.Focus();
            }
        }

        // kiểm tra xem font có tồn tại trong hệ thống không 
        private bool IsFontAvailable(string fontName)
        {
            // Kiểm tra xem font có tồn tại trong hệ thống không
            foreach (FontFamily fontFamily in FontFamily.Families)
                if (fontFamily.Name == fontName)
                    return true;
            return false;
        }

        // tạo danh sách các size chữ
        private void LoadSizeToComboBox()
        {
            int[] fontArr = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            foreach (int i in fontArr)
                cbSize.Items.Add(i.ToString());
            cbSize.SelectedIndex = 4;
        }

        // khi nhập không đúng kích thước, trả về kích thước mặc định: 12
        private void cbSize_Validating(object sender, CancelEventArgs e)
        {
            int[] fontArr = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            ComboBox comboBox = (ComboBox)sender;
            string userInput = comboBox.Text;
            try
            {
                int userInputInt = int.Parse(userInput);
                if (!fontArr.Contains(userInputInt))
                {
                    // Nếu không tồn tại, gán kích thước mặc định
                    cbSize.SelectedIndex = 4;
                }
            }
            catch (FormatException)
            {
                // Nếu định dạng không hợp lệ, gán kích thước mặc định
                cbSize.SelectedIndex = 4;
            }
        }

        // áp dụng kích thước chữ cho document 
        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                float fontSize = float.Parse(cbSize.SelectedItem.ToString());

                // Lấy vị trí con trỏ hiện tại
                int selectionStart = rtbText.SelectionStart;

                // Áp dụng kích thước mới cho SelectionFont
                Font currentFont = rtbText.SelectionFont;
                Font newFont = new Font(currentFont.FontFamily, fontSize, currentFont.Style);
                rtbText.SelectionFont = newFont;

                // Đặt lại vị trí con trỏ để text tiếp theo sử dụng font mới
                rtbText.SelectionStart = selectionStart;
                rtbText.SelectionLength = 0;

                rtbText.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // dán văn bản đã copy
        private void pnPaste_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Clipboard có chứa dữ liệu không
            if (Clipboard.ContainsText())
                rtbText.SelectedText = Clipboard.GetText();
            else return;
        }

        //copy văn bản đã chọn
        private void pnCopy_Click(object sender, EventArgs e)
        {
            copy = rtbText.SelectedText;
            Clipboard.SetText(copy);
        }

        // cắt văn bản đã chọn
        private void pnCut_Click(object sender, EventArgs e)
        {
            if (rtbText.SelectedText != "")
            {
                // Sao chép vào clipBoard, sau đó xoá text đi 
                Clipboard.SetText(rtbText.SelectedText);
                rtbText.SelectedText = "";
            }
            else return;
        }

        // căn lề trái
        private void tsbtnAlignLeft_Click(object sender, EventArgs e)
        {
            rtbText.SelectionAlignment = HorizontalAlignment.Left;
        }

        // căn lề phải 
        private void tsbtnAlignRight_Click(object sender, EventArgs e)
        {
            rtbText.SelectionAlignment = HorizontalAlignment.Right;
        }

        // căn giữa
        private void tsbtnCenter_Click(object sender, EventArgs e)
        {
            rtbText.SelectionAlignment = HorizontalAlignment.Center;
        }


        // tạo FlowLayout để chọn màu chữ cho text
        private void LoadFlowLayoutPanel()
        {
            try
            {

                // Tạo FlowLayoutPanel để chứa các TextBox
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.FlowDirection = FlowDirection.TopDown; // Hiển thị theo chiều dọc
                flowLayoutPanel.AutoSize = false;
                flowLayoutPanel.Width = 85;
                flowLayoutPanel.Height = 50;

                // Mảng hai chiều các màu
                Color[,] colors = new Color[5, 3]
                {
        { Color.Red, Color.Green, Color.Blue },
        { Color.Yellow, Color.Orange, Color.Purple },
        { Color.Gray, Color.Cyan, Color.Magenta },
        { Color.Pink, Color.Lime, Color.Silver },
        { Color.Tan, Color.Aqua, Color.DarkGoldenrod }
                };

                // Thêm các button vào FlowLayoutPanel từ mảng màu
                for (int i = 0; i < colors.GetLength(0); i++)
                {
                    FlowLayoutPanel rowPanel = new FlowLayoutPanel();
                    rowPanel.FlowDirection = FlowDirection.LeftToRight; // Hiển thị theo chiều ngang
                    rowPanel.AutoSize = true;

                    for (int j = 0; j < colors.GetLength(1); j++)
                    {
                        Button btn = CreatButton(colors[i, j]);
                        btn.Click += Button_Click;
                        rowPanel.Controls.Add(btn);
                    }

                    flowLayoutPanel.Controls.Add(rowPanel);
                }

                // Tạo ToolStripControlHost để chứa FlowLayoutPanel
                ToolStripControlHost host = new ToolStripControlHost(flowLayoutPanel);

                // Thêm ToolStripControlHost vào ToolStripDropDownButton
                tsForeColor.DropDownItems.Add(host);

                // Thêm ToolStripDropDownButton vào ToolStrip
                toolStrip2.Items.Add(tsForeColor);
            }
            catch { return; }
        }

        // tạo FlowLayout để chọn màu nền chữ cho text
        private void LoadFlowLayoutPanel2()
        {
            try
            {
                // Tạo FlowLayoutPanel để chứa các TextBox
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.FlowDirection = FlowDirection.TopDown; // Hiển thị theo chiều dọc
                flowLayoutPanel.AutoSize = false;
                flowLayoutPanel.Width = 150;
                flowLayoutPanel.Height = 30;

                // Mảng hai chiều các màu
                Color[,] colors = new Color[3, 5]
                {
{ Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange },
{ Color.Purple, Color.Gray, Color.White, Color.Magenta, Color.Brown },
{ Color.Lime, Color.Silver,  Color.Tan, Color.Aqua, Color.DarkGoldenrod }
                };

                // Thêm các button vào FlowLayoutPanel từ mảng màu
                for (int i = 0; i < colors.GetLength(0); i++)
                {
                    FlowLayoutPanel rowPanel = new FlowLayoutPanel();
                    rowPanel.FlowDirection = FlowDirection.LeftToRight; // Hiển thị theo chiều ngang
                    rowPanel.AutoSize = true;

                    for (int j = 0; j < colors.GetLength(1); j++)
                    {
                        Button btn = CreatButton(colors[i, j]);
                        btn.Click += BackColor_Click;
                        rowPanel.Controls.Add(btn);
                    }

                    flowLayoutPanel.Controls.Add(rowPanel);
                }

                // Tạo ToolStripControlHost để chứa FlowLayoutPanel
                ToolStripControlHost host = new ToolStripControlHost(flowLayoutPanel);

                // Thêm ToolStripControlHost vào ToolStripDropDownButton
                tsBackColor.DropDownItems.Add(host);

                // Thêm ToolStripDropDownButton vào ToolStrip
                toolStrip2.Items.Add(tsBackColor);
            }
            catch { return; }

        }

        // tạo button trong FlowLayout để chứa màu
        private Button CreatButton(Color color)
        {
            // tạo button và đặt thuộc tính 
            Button btn = new Button();
            btn.BackColor = color;
            btn.Size = new Size(23, 23);
            btn.Margin = new Padding(5, 0, 5, 0);
            return btn;
        }

        // sự kiện nhấn để chọn màu
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            rtbText.SelectionColor = btn.BackColor;
        }

        // sự kiện tô màu đen cho text được selected
        private void tsColorAutomatic_Click(object sender, EventArgs e)
        {
            rtbText.SelectionColor = Color.Black;
        }

        // sự kiện nhấn để chọn màu cho BackColor
        private void BackColor_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            rtbText.SelectionBackColor = btn.BackColor;
        }
        // sự kiện lựa full màu để tô (ColorDialog)
        private void tsMoreColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            if (dlg.ShowDialog() == DialogResult.OK)
                rtbText.SelectionColor = dlg.Color;
        }

        // thoát chương trình khi nhấn exit (đang comment để dễ chạy code)
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // thoát chương trình khi nhấn FormClossing (đang comment để dễ chạy code)
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình ? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                e.Cancel = true;
        }

        // Tạo đoạn văn bản mới 
        private void tsbtnParagraph_Click(object sender, EventArgs e)
        {
            // tạo một đoạn văn bản mới bằng Environment.NewLine để tạo một dòng mới.
            string paragraph = Environment.NewLine;
            // thêm đoạn văn bản mới vào cuối văn bản
            rtbText.AppendText(paragraph);
        }

        // giảm giá trị thụt dòng text selected
        private void tsDecreaseIndent_Click(object sender, EventArgs e)
        {
            // Giảm giá trị thụt của văn bản được chọn trong text
            rtbText.SelectionIndent -= 10;
        }

        // tăng giá trị thụt dòng text selected
        private void tsIncreaseIndent_Click(object sender, EventArgs e)
        {
            // Tăng giá trị thụt của văn bản được chọn trong text
            rtbText.SelectionIndent += 10;
        }

        private void tbZoom_ValueChanged(object sender, EventArgs e)
        {
            int curent = tbZoom.Value;

            lbPT.Text = tbZoom.Value.ToString() + '%';
            //    rtbText.Size = new System.Drawing.Size(1108 * curent / 100, rtbText.Size.Width);
            float fontSize = curent;
            try
            {
                rtbText.SelectAll();
                rtbText.SelectionFont = new Font(rtbText.Font.FontFamily, sizeChu * curent / 100);
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn đã thu nhỏ hết mức!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void picZoomOut2_Click(object sender, EventArgs e)
        {
            tbZoom.Value -= 5;
        }

        private void picZoomIn2_Click(object sender, EventArgs e)
        {
            tbZoom.Value += 5;
        }

        private void cbBar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBar.Checked == true)
                pnBar.Visible = true;
            else pnBar.Visible = false;
        }

        private void picZoomIn_Click(object sender, EventArgs e)
        {
            tbZoom.Value += 10;
        }

        private void picZoomOut_Click(object sender, EventArgs e)
        {
            tbZoom.Value -= 10;
        }

        private void picPercent_Click(object sender, EventArgs e)
        {
            int curent = tbZoom.Value;

            tbZoom.Value = 100;

            rtbText.SelectAll();
            rtbText.SelectionFont = new Font(rtbText.Font.FontFamily, sizeChu);
        }

        private void cbWrap_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbWrap.SelectedItem != null)
                {
                    if (cbWrap.SelectedIndex == 0)
                        rtbText.WordWrap = false;
                    else if (cbWrap.SelectedIndex == 1)
                        rtbText.WordWrap = true;
                    rtbText.ScrollBars = RichTextBoxScrollBars.Both;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bulletMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.SelectionBullet = true;
        }

        private void changePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertImage();
        }

        private void picPicture_Click(object sender, EventArgs e)
        {
            insertImage();
        }

        // hàm thêm ảnh
        private void insertImage()
        {
            OpenFileDialog pdlg = new OpenFileDialog();
            pdlg.Filter = "Tập tin ảnh (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif|Tất cả các tập tin (*.*)|*.*";
            pdlg.Multiselect = false; // Chỉ cho phép chọn một tập tin
            if (pdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string Path = pdlg.FileName; // đường dẫn tệp
                    Image anh = Image.FromFile(Path);
                    MemoryStream stream = new MemoryStream();
                    anh.Save(stream, anh.RawFormat);

                    Clipboard.SetDataObject(anh);

                    rtbText.Paste();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public static bool flagFind = false;
        public static bool flagReplace = false;
        Replace r;
        Find f;

        // Mở hộp thoại tìm kiếm
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!flagFind)
            {
                f = new Find();
                f.Show();
                flagFind = !flagFind;
            }
            if (flagReplace)
                r.Close();

        }

        // hàm tìm kiếm
        public void FindText(string searchText)
        {
            int index = -1;
            rtbText.SelectAll();
            rtbText.SelectionBackColor = rtbText.BackColor;

            if (matchWholeWord && matchCase)
                index = rtbText.Find(searchText, lastFoundIndex, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
            else if (matchWholeWord)
                index = rtbText.Find(searchText, lastFoundIndex, RichTextBoxFinds.WholeWord);
            else if (matchCase)
                index = rtbText.Find(searchText, lastFoundIndex, RichTextBoxFinds.None | RichTextBoxFinds.MatchCase);
            else
                index = rtbText.Find(searchText, lastFoundIndex, RichTextBoxFinds.None);

            if (index != -1)
            {
                // Đặt màu chữ về màu mặc định cho từ trước đó đã được tìm thấy
                if (lastFoundIndex > 0)
                {
                    rtbText.Select(lastFoundIndex - 1, searchText.Length);
                    rtbText.SelectionBackColor = rtbText.BackColor;
                }

                // Tìm thấy từ mới, di chuyển con trỏ tới vị trí đó và chọn từ đó
                rtbText.Select(index, searchText.Length);
                // Scroll đến vị trí con trỏ
                rtbText.ScrollToCaret();
                rtbText.SelectionBackColor = Color.Yellow;

                // Cập nhật vị trí của từ cuối cùng được tìm thấy
                lastFoundIndex = index + 1;
            }
            else
            {
                // Đặt lại vị trí của từ cuối cùng được tìm thấy về đầu văn bản
                lastFoundIndex = 0;
                MessageBox.Show("Không còn từ cần tìm.");
                rtbText.SelectionBackColor = rtbText.BackColor;
            }
        }

        public bool MatchWholeWord
        {
            get { return matchWholeWord; }
            set { matchWholeWord = value; }
        }

        public bool MatchCase
        {
            get { return matchCase; }
            set { matchCase = value; }
        }

        // khi nhấn cancel trong find thì huỷ tô màu các chữ đã chọn
        public void ResetTextColors()
        {
            // Đặt màu chữ của toàn bộ văn bản về màu gốc (black)
            rtbText.SelectAll();
            rtbText.SelectionBackColor = rtbText.BackColor;
        }

        // Mở hộp thoại thay thế
        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (!flagReplace)
            {
                r = new Replace();
                r.Show();
                flagReplace = !flagReplace;
            }
            if (flagFind)
                f.Close();
        }

        // chọn toàn bộ văn bản trong RichTextBox
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            rtbText.SelectAll();
            rtbText.Focus();
        }

        // thay thế 1 từ được chọn 
        public void ReplaceSelectedText(string newText)
        {
            if (rtbText.SelectionLength > 0)
                rtbText.SelectedText = newText;
        }

        // thay thế tất cả các từ trong txtFind
        public void ReplaceAllText(string findText, string replaceText)
        {
            if (rtbText == null)
                return;

            if (string.IsNullOrEmpty(findText))
            {
                MessageBox.Show("Vui lòng nhập từ cần tìm kiếm vào ô tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string text = rtbText.Text;
            string newText = ""; // Chuỗi mới sau khi thay thế
            int startIndex = 0; // Vị trí bắt đầu tìm kiếm từ

            while (true)
            {
                // Tìm vị trí của từ cần tìm kiếm trong văn bản
                //StringComparison.OrdinalIgnoreCase là một cách để so sánh chuỗi mà không phân biệt chữ hoa và chữ thường.
                int index = text.IndexOf(findText, startIndex, StringComparison.OrdinalIgnoreCase);

                // Nếu không tìm thấy từ cần tìm kiếm, kết thúc vòng lặp
                if (index == -1)
                {
                    // Thêm phần còn lại của văn bản vào chuỗi mới và kết thúc vòng lặp
                    newText += text.Substring(startIndex);
                    break;
                }
                // Thêm phần văn bản từ startIndex đến trước index vào chuỗi mới,
                // sau đó thêm từ thay thế vào chuỗi mới
                newText += text.Substring(startIndex, index - startIndex) + replaceText;
                // Cập nhật vị trí bắt đầu tìm kiếm tiếp theo
                startIndex = index + findText.Length;

            }
            // Đặt văn bản mới vào RichTextBox
            rtbText.Text = newText;
            rtbText.SelectAll();
            //rtbText.SelectionIndent = 40;

            // Đặt thụt vào lề cho văn bản đã chọn
            rtbText.SelectionIndent = trbLeft.Value;
            rtbText.SelectionRightIndent = trbRight.Value;
        }

        private void picDateTime_Click(object sender, EventArgs e)
        {
            DateAndTime d = new DateAndTime(this);
            d.Show();
        }

        public void insert_Time()
        {
            int position = rtbText.SelectionStart;
            // Chèn thời gian vào vị trí con trỏ hiện tại
            rtbText.SelectedText = timeNow;
            CurrentAlignment();
        }


        // dãn dòng văn bản được chọn
        private void tsLineSpacing_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                // Chuyển đổi văn bản của mục menu thành kích thước dãn dòng
                double lineSpacing = double.Parse(menuItem.Text);

                // Thiết lập kích thước dãn dòng cho RichTextBox
                rtbText.SelectionCharOffset = (int)(lineSpacing);
            }
        }
        // dãn dòng 1.0 khi click
        private void LineSpacing1_Click(object sender, EventArgs e)
        {
            tsLineSpacing_Click(sender, e);
            LineSpacing1.Checked = true;
            LineSpacing15.Checked = false;
            LineSpacing2.Checked = false;
        }
        // dãn dòng 1.5 khi click
        private void LineSpacing15_Click(object sender, EventArgs e)
        {
            tsLineSpacing_Click(sender, e);
            LineSpacing1.Checked = false;
            LineSpacing15.Checked = true;
            LineSpacing2.Checked = false;
        }
        // dãn dòng 2.0 khi click
        private void LineSpacing2_Click(object sender, EventArgs e)
        {
            tsLineSpacing_Click(sender, e);
            LineSpacing1.Checked = false;
            LineSpacing15.Checked = false;
            LineSpacing2.Checked = true;
        }

        // vẽ basic
        private void picPaint_Click(object sender, EventArgs e)
        {
            Paint p = new Paint(this);
            p.Show();
        }

        // lưu hình lại và vẽ paste ra rtbText
        public void ReceiveDrawing(Bitmap drawing)
        {
            if (drawing != null)
            {
                Clipboard.SetImage(drawing);
                rtbText.Paste();
            }
        }

        // thanh ngang căn chỉnh lề trái
        private void trbLeft_Scroll(object sender, EventArgs e)
        {
            rtbText.SelectAll();
            rtbText.SelectionIndent = trbLeft.Value;
        }
        // thanh ngang căn chỉnh lề phải
        private void trbRight_Scroll(object sender, EventArgs e)
        {
            rtbText.SelectAll();
            rtbText.SelectionRightIndent = trbRight.Value;
        }

        // hàm căn lề 2 bên theo giá trị hiện tại của trang
        public void CurrentAlignment ()
        {
            rtbText.SelectAll();
            rtbText.SelectionIndent = trbLeft.Value;
            rtbText.SelectionRightIndent = trbRight.Value;
        }
    }
}
