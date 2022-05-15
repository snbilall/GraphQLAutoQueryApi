using System;
using System.Collections.Generic;

namespace Model
{
    public class Table2 : BaseEntity
    {
        public int Tbl2Prp1 { get; set; }
        public string Tbl2Prp2 { get; set; }
        public DateTime Tbl2Prp3 { get; set; }
        public Table1 Table1 { get; set; }
        public List<Table3> Table3Properties { get; set; }
    }
}
