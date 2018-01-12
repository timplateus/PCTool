using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTool
{
    class ParamColumn
    {
        public string ColumnName { get; set; }
        public List<Record> Records { get; set; }

        public ParamColumn()
        {
            this.Records = new List<Record>();
        }
        public ParamColumn(string columnName)
        {
            this.ColumnName = columnName;
            this.Records = new List<Record>();
        }
        public ParamColumn(string columnName, Record record)
        {
            this.ColumnName = columnName;
            this.Records = new List<Record>() { record };
        }
        public ParamColumn(string columnName,List<Record> records)
        {
            this.ColumnName = columnName;
            this.Records = records;
        }
    }
}
