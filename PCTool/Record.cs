using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTool
{
    class Record
    {
        public string ConfigName { get; set; }

        public List<ParamValue> ParamValues { get; set; }

        public Record() { this.ParamValues = new List<ParamValue>(); }
        public Record(string configName)
        {
            this.ConfigName = configName;
            this.ParamValues = new List<ParamValue>();
        }
        public Record(string configName,ParamValue paramValue)
        {
            this.ConfigName = configName;
            this.ParamValues = new List<ParamValue>() { paramValue };
        }
        public Record(string configName,List<ParamValue> paramValues)
        {
            this.ConfigName = configName;
            this.ParamValues = paramValues;
        }

    }
}
