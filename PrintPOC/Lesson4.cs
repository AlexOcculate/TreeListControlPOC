using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPOC
{
    public class Lesson4 : Lesson3
    {
        public Lesson4(PrintingSystem ps) : base(ps) { }

        // Change the brick font name to 'Tahoma', change the size to '16', and set bold and italic attributes. 
        protected override void CreateDetail(BrickGraphics graph)
        {
            graph.Font = new Font("Tahoma", 16, FontStyle.Bold | FontStyle.Italic);
            base.CreateDetail(graph);
        }
    }
}
