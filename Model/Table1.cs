using System;
using System.Collections.Generic;

namespace Model
{
    public class Table1 : BaseEntity
    {
        public int Tbl1Prp1 { get; set; }
        public string Tbl1Prp2 { get; set; }
        public DateTime Tbl1Prp3 { get; set; }
        public List<Table2> Table2Properties { get; set; }
    }
}
