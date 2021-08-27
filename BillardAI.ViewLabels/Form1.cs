using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillardAI.ViewLabels
{
    public partial class Form1 : Form
    {
        private int _viewImageIndex = 0;
        private Image[] _images;
        private List<LabelItem> _labels = new List<LabelItem>();

        private Dictionary<int, FileInfo> _labelPaths = new Dictionary<int, FileInfo>();

        public Form1()
        {
            InitializeComponent();
            CreateControl();
            
        }

        private void CreateControl()
        {
            this.picViewer.Location = new System.Drawing.Point(0, 0);
            this.picViewer.Padding = new System.Windows.Forms.Padding(5);
            this.picViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picViewer.TabIndex = 0;
            this.picViewer.TabStop = false;
            this.picViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            SetupDataGridView();
        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                ShowError("Please choose image folder.");
                return;
            }

            _images = LoadImages(txtPath.Text).ToArray();
            imgs.Images.AddRange(_images);

            if (_images.Length > 0)
                picViewer.Image = _images.First();
            SetupLabel(txtPath.Text);
            LoadLabel();
        }
        private void SetupLabel(string path)
        {
            var directory = new DirectoryInfo(path);
            var labelFolder = directory.GetDirectories().FirstOrDefault(x => x.Name.ToLower().Contains("label"));

            if (labelFolder == null)
            {
                ShowError("Cant find Labels Folder.");
                return;
            }
            _labelPaths = LoadFileInfor(labelFolder.FullName, "*.txt");
        }

        private List<Image> LoadImages(string path)
        {
            var results = new List<Image>();
            var directory = new DirectoryInfo(path);
            var imageFrameFolder = directory.GetDirectories().FirstOrDefault(x =>x.Name.ToLower().Contains("frame"));
            if (imageFrameFolder == null)
            {
                ShowError("Cant find Frame Folder.");
                return results;
            }

            var imgPaths = LoadFileInfor(imageFrameFolder.FullName, "*.jpg");

            FileInfo file = new FileInfo(imageFrameFolder.FullName);
            lblImageName.Text = "Image : " + file.Name;
            foreach (var item in imgPaths)
            {
                results.Add(Image.FromFile(item.Value.FullName));
            }
            return results;
        }
         
        private void SetupDataGridView()
        { 
            datagrd.ColumnCount = 5;
            datagrd.Dock = DockStyle.Fill;
            datagrd.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            datagrd.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            datagrd.ColumnHeadersDefaultCellStyle.Font =
                new Font(datagrd.Font, FontStyle.Bold);

            datagrd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            datagrd.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            datagrd.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            datagrd.GridColor = Color.Black;

            datagrd.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            datagrd.MultiSelect = false;

        }

        

        private void LoadLabel()
        {
            var results = new List<LabelItem>();
            var file = _labelPaths[_viewImageIndex];
            var datas = File.ReadAllLines(file.FullName);
            lblLabelName.Text = "Label : " + file.Name;
            foreach (var line in datas)
            {
                var label = GetLabel(line);
                results.Add(label);
            }

            //foreach (var item in results)
            //{
            //    Drawball(new Point(item.X, item.Y), new Point(item.W, item.H), item.Class);
            //}

            _labels = results;
            datagrd.Columns.Clear();
            datagrd.DataSource = results.OrderBy(x => x.Class).ToList();
        }

        private LabelItem GetLabel(string line)
        {
            var datas = line.Split(' ');
            return new LabelItem() { 
                Class = datas.ToClass(),
                X = datas.ToX(),
                Y = datas.ToY(),
                W = datas.ToW(),
                H = datas.ToH()
            };
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ////handle your keys here
            //if(txtPath.Focused)
            //    return true;
            
            if (keyData == Keys.Left)
            {
                _viewImageIndex--;
                if (_viewImageIndex < 0)
                    _viewImageIndex = _images.Length - 1;
            }

            if (keyData == Keys.Right)
            {
                _viewImageIndex++;
                if (_viewImageIndex >= _images.Length)
                    _viewImageIndex = 0;
            }

            LoadLabel();
            picViewer.Image = _images[_viewImageIndex];
            Drawball(_images[_viewImageIndex]);
            txtHidden.Focus();

            return true;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            txtHidden.Focus();

        }

        private void splitter2_ClientSizeChanged(object sender, EventArgs e)
        {
            picViewer.Refresh();
        }

        private Dictionary<int, FileInfo> LoadFileInfor(string path, string fileExtention)
        {
            var results = new Dictionary<int, FileInfo>();
            var files = new DirectoryInfo(path).GetFiles(fileExtention)
                                    .ToList();
            foreach (var item in files)
            {
                var dataSplit = item.FullName.Split('_').Last();
                int.TryParse(dataSplit.Replace(item.Extension, ""), out var index);
                results.Add(index - 1, item);
            }
            return results.OrderBy(x => x.Key).ToDictionary(x => x.Key, x=> x.Value);
        }

        private void Drawball(Image image)
        {
            //var graphic = this.CreateGraphics();
            //graphic.DrawLine( new Pen(ToColor(colorNumber), 2f), point1, point2);
            foreach (var item in _labels)
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawLine(new Pen(ToColor(item.Class), 2f), new Point(item.X, item.Y), new Point(item.W, item.H));
                }
            }
           
        }

        public static Color ToColor(int colorNumber) => colorNumber switch
        {
            0 => Color.Red,
            1 => Color.Black,
            2 => Color.Yellow,
            _ => throw new NotImplementedException(),
        };

    }
}
