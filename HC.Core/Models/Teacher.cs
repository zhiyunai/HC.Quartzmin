using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Core.Models
{
    public class Teacher
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true,IsIdentity = true)]
        public int tid { get; set; }
        public string tname { get; set; }
    }
}
