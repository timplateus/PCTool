using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTool
{
    class ParamValue
    {
        public string FileId { get; set; }
        public string Value { get; set; }
        public ParamValue(string FileId,string Value)
        {
            this.FileId = FileId;
            this.Value = Value;
        }
    }
}
