using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTool
{
    /// <summary>
    /// This is the class for all entries from either paramLists or paramTables.
    /// </summary>
    class Entry
    {
        //Same for list and table
        public string SetName { get; set; }
        //Container is either a List or a Table
        public string ContainerName { get; set; }
        //For lists this is called paramName, for tables paramColumnName
        public string ParamName { get; set; }
        //Same for list and table
        public string ConfigName { get; set; }
        //FileId is same for list and table; paramValue for list, paramColumnValue for table
        public List<ParamValue> Values { get; set; }
        //Only exists for tables where it is called paramRecordRow. Helps with sorting of the worksheet
        public string Position { get; set; }
        

        public Entry() { this.Values = new List<ParamValue>(); this.Position = ""; }
        public Entry(string setName, string containerName, string paramName,string configName)
        {
            this.SetName = setName;
            this.ContainerName = containerName;
            this.ParamName = paramName;
            this.ConfigName = configName;
            this.Values = new List<ParamValue>();
            this.Position = "";
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
            bool isSameEntry = (this.SetName == entry.SetName && this.ContainerName==entry.ContainerName && this.ParamName==entry.ParamName && this.ConfigName==entry.ConfigName && this.Position == entry.Position);

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
