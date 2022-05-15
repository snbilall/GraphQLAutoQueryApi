using Model;
using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class UsualQueryModels
    {
        public class Request
        {
            public int? IntProp { get; set; }
            public DateTime? DateTimeProp { get; set; }
        }

        public class Response
        {
            public List<Table1> Table { get; set; }
        }
    }
}
