using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tessnet2;

namespace Tessnet2CaptchaDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var image = new Bitmap(@"D:\github\Tessnet2CaptchaDemo\images.jpg");
                var ocr = new Tesseract();
                ocr.SetVariable("tessedit_char_whitelist", "0123456789"); // If digit only 
                //@"C:\OCRTest\tessdata" contains the language package, without this the method crash and app breaks 
                ocr.Init(null, "eng", true);
                var result = ocr.DoOCR(image, Rectangle.Empty);
                foreach (Word word in result)
                    MessageBox.Show(string.Format("{0} : {1}", word.Confidence, word.Text));
                //Console.WriteLine("{0} : {1}", word.Confidence, word.Text);

                
                
            }
            catch (Exception exception)
            {
                throw exception;
            } 
        }
    }
}
