using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum Action
    {
        Add,
        Delete,
        Update
    }

    class Event
    {
        public Data data { get; set; }
        public Action action { get; set; }
        public int? RefId { get; set; }

        public void ChangeData(List<Data> dataList)
        {
            //Write the code to update dataList array - Do Not see comments:
            
            //Your code start:            
            switch (action)
            {
                case Action.Add:
                    data.Id = RefId;
                    dataList.Add(data);
                    break;
                case Action.Update:
                    Data d1 = dataList.Find(x => x.Id == RefId);
                    d1.Desc = data.Desc;
                    d1.Name = data.Name;
                    break;
                case Action.Delete:
                    Data d2 = dataList.Find(x => x.Id == RefId);
                    dataList.Remove(d2);
                    break;
            }
            //Your code start:
        }
    }

    class Data
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
