using System;
using System.Collections.Generic;

namespace GraphQLBusiness
{
    public class ColumnMetadata
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
    }

    public class TableMetadata
    {
        public string TableName { get; set; }
        public string AssemblyFullName { get; set; }
        public List<ColumnMetadata> Columns { get; set; }
    }
}
