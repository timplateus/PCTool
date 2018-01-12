using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTool
{
    class ColumnRecord
    {
        public string ConfigName { get; set; }
        public string ColumnName { get; set; }

        public List<ParamValue> ParamValues { get; set; }

        public ColumnRecord(string configName,string columnName,ParamValue paramValue)
        {
            this.ConfigName = configName;
            this.ColumnName = columnName;

            this.ParamValues = new List<ParamValue>() { paramValue };
        }
        public ColumnRecord(string configName,string columnName,List<ParamValue> paramValues)
        {
            this.ConfigName = configName;
            this.ColumnName = columnName;

            this.ParamValues = paramValues;
        }
    }
}
