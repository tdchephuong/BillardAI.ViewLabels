using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BillardAI.ViewLabels
{
    public class Utils
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
