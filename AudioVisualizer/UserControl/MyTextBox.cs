using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVisualizer.UserControl
{
    class MyTextBox : TextBox
    {
        public StringBuilder StringBuilder { get; } = new StringBuilder();
        public override string Text
        {
            get => StringBuilder.ToString(); set
            {
                StringBuilder.Clear();
                StringBuilder.Append(value);
            }
        }
    }
}
