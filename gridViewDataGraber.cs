using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrgPro
{
    [Serializable]
    class gridViewDataGraber
    {
        List<string> columnHeaderNames;
        List<List<string>> tableData;
        public gridViewDataGraber()
        {
            columnHeaderNames = new List<string>();
            tableData = new List<List<string>>();
        }
        public gridViewDataGraber(List<string> columnHeaderNames , List<List<string>> tableData)
        {
            this.columnHeaderNames = columnHeaderNames;
            this.tableData = tableData;
        }

        public List<string> ColumnsHeaderNames
        {
            get { return columnHeaderNames; }
            set { columnHeaderNames = value; }
        }

        public List<List<string>> TableData
        {
            get { return tableData; }
            set { tableData = value; }
        }
    }
}
