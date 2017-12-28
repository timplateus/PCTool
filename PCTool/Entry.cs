using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTool
{
    class Entry
    {
        public string SetName { get; set; }
        public string ListName { get; set; }
        public string ParamName { get; set; }
        public string ConfigName { get; set; }
        public List<ParamValue> Values { get; set; }
        

        public Entry() { this.Values = new List<ParamValue>(); }
        public Entry(string SetName, string ListName, string ParamName,string ConfigName)
        {
            this.SetName = SetName;
            this.ListName = ListName;
            this.ParamName = ParamName;
            this.ConfigName = ConfigName;
            this.Values = new List<ParamValue>();
        }

        public void AddValue(ParamValue Value)
        {
            try
            {
                ParamValue existingValue = this.Values.Find(v => v.FileId == Value.FileId);
                if (existingValue == null)
                {
                    Values.Add(new ParamValue(Value.FileId, Value.Value));
                }
                else
                {
                    throw new InvalidOperationException("Cannot add duplicates to Values property");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error caught while trying to use Entry.AddValue method: {0}", e.Message);
            }
        }
        public void AddValue(string FileId,string paramValue)
        {
            try
            {
                ParamValue existingValue = this.Values.Find(v => v.FileId == FileId);
                if (existingValue == null)
                {
                    Values.Add(new ParamValue(FileId, paramValue));
                }
                else
                {
                    throw new InvalidOperationException("Cannot add duplicates to Values property");
                }
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Error caught while trying to use Entry.AddValue method: {0}", e.Message);
            }
        }
        /// <summary>
        /// Merge second entry. Returns null if both entries are not equal.
        /// </summary>
        /// <param name="entry">The entry you want to have merged.</param>
        public Entry Merge(Entry entry)
        {
            bool isSameEntry = (this.SetName == entry.SetName && this.ListName==entry.ListName && this.ParamName==entry.ParamName && this.ConfigName==entry.ConfigName);

            if (isSameEntry)
            {
                foreach (ParamValue val in entry.Values)
                {
                    this.AddValue(val);
                   
                }
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
