using System;

namespace Model
{
    public class Table3 : BaseEntity
    {
        public int Tbl3Prp1 { get; set; }
        public string Tbl3Prp2 { get; set; }
        public DateTime Tbl3Prp3 { get; set; }
        public Table2 Table2 { get; set; }
    }
}
