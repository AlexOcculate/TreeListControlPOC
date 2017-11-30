using DevExpress.XtraPrinting;
using System;
using System.Linq;

namespace PrintPOC
{
    public class Lesson1 : Link
    {
        public Lesson1(PrintingSystem ps)
        {
            CreateDocument(ps);
        }
    }
}
