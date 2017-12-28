using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTool
{
    class ParamList
    {
        public List<Entry> Entries;
        
        public ParamList()
        {
            this.Entries = new List<Entry>();
        }
        public ParamList(Entry Entry)
        {
            this.Entries = new List<Entry>();
            Entries.Add(Entry);
        }
        public ParamList(List<Entry> Entries)
        {
            this.Entries = Entries;
        }

        public void AddEntry(Entry entry)
        {
            Entry fndEntry = this.Entries.Find(e => ((e.SetName == entry.SetName) && (e.ListName==entry.ListName) && (e.ParamName==entry.ParamName) && (e.ConfigName==entry.ConfigName)) );
            if (fndEntry == null)
            {
                Entries.Add(entry);
            }
        }
    }
}
