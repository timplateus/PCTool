using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTool
{
    class ParamTable
    {
        public string SetName { get; set; }
        public string TableName { get; set; }
        public List<ParamColumn> Columns { get; set; }

        public ParamTable(string setName,string tableName,List<ParamColumn> columns)
        {
            this.SetName = setName;
            this.TableName = tableName;
            this.Columns = columns;
        }
    }
}
