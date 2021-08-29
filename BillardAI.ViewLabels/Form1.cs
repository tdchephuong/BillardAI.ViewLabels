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
        private Bitmap[] _images;
        private List<LabelItem> _labels = new List<LabelItem>();

        private Dictionary<int, FileInfo> _labelPaths = new Dictionary<int, FileInfo>();
        private LabelService _labelService = new LabelService();

        public Form1()
        {
            InitializeComponent();
            CreateControls();
        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                Utils.ShowError("Please choose image folder.");
                return;
            }

            var imgName = "";
            _images = _labelService.LoadImages(txtPath.Text, ref imgName).ToArray();
            lblImageName.Text = imgName;

            imgs.Images.AddRange(_images);

            if (_images.Length > 0)
                picViewer.Image = _images.First();

            LoadLabels();
        }

        private void LoadLabels()
        {
            _labelPaths = _labelService.GetLabels(txtPath.Text);
            var file = _labelPaths[_viewImageIndex];
            lblLabelName.Text = "Label : " + file.Name;
            var labels = _labelService.LoadLabel(file);
            _labels = labels;
            datagrd.Columns.Clear();
            datagrd.DataSource = labels.OrderBy(x => x.Class).ToList();
        }

        private void ViewImage()
        {
            var imgData = _images[_viewImageIndex];
            var cloneRect = new RectangleF(0, 0, imgData.Width, imgData.Height);
            var img = imgData.Clone(cloneRect, imgData.PixelFormat);
           
            picViewer.Refresh();

            if (ckShowLine.Checked)
                _labelService.DrawLine(img, _labels);

            if (ckShowMidpoint.Checked)
            {
                _labelService.DrawMidpoint(img, _labels);
            }
            picViewer.Image = img;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
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

            LoadLabels();
            ViewImage();

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

        private void ckShowLine_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShowLine.Checked)
                _labelService.DrawLine(_images[_viewImageIndex], _labels);
        }

        private void CreateControls()
        {
            this.picViewer.Location = new System.Drawing.Point(0, 0);
            this.picViewer.Padding = new System.Windows.Forms.Padding(5);
            this.picViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picViewer.TabIndex = 0;
            this.picViewer.TabStop = false;
            this.picViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
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

        private void ckShowMidpoint_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShowMidpoint.Checked)
            {
                _labelService.DrawMidpoint(_images[_viewImageIndex], _labels);
            }
        }
    }
}
