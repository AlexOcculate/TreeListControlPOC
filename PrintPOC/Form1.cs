using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrintPOC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Lesson1 lesson = new Lesson1(printingSystem1);
            //Lesson2 lesson = new Lesson2(printingSystem1);
            //Lesson3 lesson = new Lesson3(printingSystem1);
            //Lesson4 lesson = new Lesson4(printingSystem1);
            //Lesson5 lesson = new Lesson5(printingSystem1);
            //Lesson6 lesson = new Lesson6(printingSystem1);
            //{
            //    Bitmap img = PrintPOC.Properties.Resources.fish;
            //    img.MakeTransparent();
            //    Lesson7 lesson = new Lesson7(printingSystem1, img);
            //}
            //{
            //    Bitmap img = PrintPOC.Properties.Resources.fish;
            //    img.MakeTransparent();
            //    Lesson8 lesson = new Lesson8(printingSystem1, img);
            //}
            {
                Bitmap img = PrintPOC.Properties.Resources.fish;
                img.MakeTransparent();
                Lesson9 lesson = new Lesson9(printingSystem1, img);
            }
        }
    }
}
