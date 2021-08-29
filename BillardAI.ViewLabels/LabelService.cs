using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace BillardAI.ViewLabels
{
    public class LabelService
    {
        public void DrawLine(Image image, List<LabelItem> _labels)
        {
            foreach (var item in _labels)
            {
                using Graphics g = Graphics.FromImage(image);
                g.DrawLine(new Pen(Utils.ToColor(item.Class), 2f), item.P1, item.P2);
            }
        }

        public void DrawMidpoint(Image image, List<LabelItem> _labels)
        {
            foreach (var item in _labels)
            {
                using Graphics g = Graphics.FromImage(image);
                var radius = 2;
                g.DrawEllipse(Pens.Blue, item.Midpoint.X - radius, item.Midpoint.Y - radius,
                      radius + radius, radius + radius);
                g.FillEllipse(Brushes.Blue, item.Midpoint.X - radius, item.Midpoint.Y - radius,
                      radius + radius, radius + radius);
            }
        }

        public Bitmap[] LoadImages(string path, ref string imageName)
        {
            var results = new List<Bitmap>();
            var directory = new DirectoryInfo(path);
            var imageFrameFolder = directory.GetDirectories().FirstOrDefault(x => x.Name.ToLower().Contains("frame"));
            if (imageFrameFolder == null)
            {
                Utils.ShowError("Cant find Frame Folder.");
                return results.ToArray();
            }

            var imgPaths = LoadFileInfor(imageFrameFolder.FullName, "*.jpg");

            FileInfo file = new FileInfo(imageFrameFolder.FullName);
            imageName = "Image : " + file.Name;
            foreach (var item in imgPaths)
            {
                results.Add(new Bitmap(item.Value.FullName));
            }
            return results.ToArray();
        }

        public Dictionary<int, FileInfo> GetLabels(string path)
        {
            var directory = new DirectoryInfo(path);
            var labelFolder = directory.GetDirectories().FirstOrDefault(x => x.Name.ToLower().Contains("label"));

            if (labelFolder == null)
            {
                Utils.ShowError("Cant find Labels Folder.");
                return null;
            }
            return LoadFileInfor(labelFolder.FullName, "*.txt");
        }

        public List<LabelItem> LoadLabel(FileInfo file)
        {
            var results = new List<LabelItem>();
            var datas = File.ReadAllLines(file.FullName);
           
            foreach (var line in datas)
            {
                var label = ParseLabel(line);
                results.Add(label);
            }

            return results;
        }

        public Dictionary<int, FileInfo> LoadFileInfor(string path, string fileExtention)
        {
            var results = new Dictionary<int, FileInfo>();
            var files = new DirectoryInfo(path).GetFiles(fileExtention).ToList();
            foreach (var item in files)
            {
                var dataSplit = item.FullName.Split('_').Last();
                int.TryParse(dataSplit.Replace(item.Extension, ""), out var index);
                results.Add(index - 1, item);
            }
            return results.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        private LabelItem ParseLabel(string line)
        {
            var datas = line.Split(' ');
            return new LabelItem()
            {
                Class = datas.ToClass(),
                P1 = new Point(datas.ToX(), datas.ToY()),
                P2 = new Point(datas.ToW(), datas.ToH())
            };
        }

    }
}
