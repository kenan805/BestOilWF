using BestOilWF.Extension;
using System.Linq;
using System.Windows.Forms;

namespace BestOilWF
{
    static class TextBoxExtension
    {
        static string oldText = string.Empty;

        public static string OnlyDecimalNumberTextBox(this TextBox textBox)
        {
            if (textBox.Text.All(chr => chr.IsComma() || char.IsDigit(chr)))
            {
                oldText = textBox.Text;
                textBox.Text = oldText;
            }
            else
            {
                textBox.Text = oldText;
            }
            textBox.SelectionStart = textBox.Text.Length;
            return textBox.Text;
        }
    }
}
