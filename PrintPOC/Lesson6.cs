using DevExpress.XtraPrinting;
using System.Drawing;

namespace PrintPOC
{
    public class Lesson6 : Lesson5
    {
        public Lesson6(PrintingSystem ps) : base(ps) { }

        protected override void CreateDetail(BrickGraphics graph)
        {
            // Center the text string. 
            graph.StringFormat = graph.StringFormat.ChangeLineAlignment(StringAlignment.Center);

            // Add an unchecked check box brick with all borders displayed 
            // to a specific location using the Light Sky Blue background color. 
            graph.DrawCheckBox(new Rectangle(150, 0, 50, 50),
               BorderSide.All, Color.LightSkyBlue, false);

            // Add an empty rectangle with all borders displayed 
            // to a specific location using the Light Lavender background color. 
            graph.DrawRect(new Rectangle(200, 0, 50, 50),
                BorderSide.All, Color.Lavender, graph.BorderColor);

            base.CreateDetail(graph);
        }

        protected override void CreateRow(BrickGraphics graph)
        {
            base.CreateRow(graph);

            // Add a checked check box brick with all borders displayed 
            // to a specific location using the Light Sky Blue background color. 
            graph.DrawCheckBox(new Rectangle(150, top, 50, 50),
                BorderSide.All, Color.LightSkyBlue, true);
        }
    }

}
