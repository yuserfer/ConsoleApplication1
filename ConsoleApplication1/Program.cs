using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            /*
             There are two arrays of objects:
             
             List<Data> dataList - Id, Name, Desc:
             1 Name1 Desc1
             2 Name2 Desc2
             3 Name3 Desc3
             4 Name4 Desc4
             5 Name5 Desc5
              
             List<Event> eventList - (includes Data object, where RefId is reference to Data.Id):
             Delete 4
             Delete 5
             Delete 1
             Add 6  Name6 Desc6
             Update 1 1 Name7 Desc7
             Update 2 2 Name8 Desc8
             Update 3 3 Name9 Desc9

             Write the Method ChangeData, that update dataList array in order Add, Update, Delete.
                          
             The result should be:
             2 Name8 Desc8
             3 Name9 Desc9
             6 Name6 Desc6                           
             */
            List<Data> dataList = new List<Data>();
            InitializeData(dataList);

            foreach (Data data in dataList)
            {
                Console.WriteLine(data.Id + " " + data.Name + " " + data.Desc);
            }
            Console.WriteLine("--------------------");

            List<Event> eventList = new List<Event>();
            eventList.Add(new Event { action = Action.Delete, data = new Data { Id = null, Name = null, Desc = null }, RefId = 4 });
            eventList.Add(new Event { action = Action.Delete, data = new Data { Id = null, Name = null, Desc = null }, RefId = 5 });
            eventList.Add(new Event { action = Action.Delete, data = new Data { Id = null, Name = null, Desc = null }, RefId = 1 });
            eventList.Add(new Event { action = Action.Add, data = new Data { Id = null, Name = "Name6", Desc = "Desc6" }, RefId = 6 });
            eventList.Add(new Event { action = Action.Update, data = new Data { Id = 1, Name = "Name7", Desc = "Desc7" }, RefId = 1 });
            eventList.Add(new Event { action = Action.Update, data = new Data { Id = 2, Name = "Name8", Desc = "Desc8" }, RefId = 2 });
            eventList.Add(new Event { action = Action.Update, data = new Data { Id = 3, Name = "Name9", Desc = "Desc9" }, RefId = 3 });

            foreach (Event ev in eventList)
            {
                Console.WriteLine(ev.action + " " + ev.RefId + " " + ev.data.Id + " " + ev.data.Name + " " + ev.data.Desc);
            }
            Console.WriteLine("--------------------");

            //Sort eventList by action Add, Update, Delete - Do Not see comments:
            /*
            //Your code start:
            var orderMap = new Dictionary<Action, int>()
                        {
                        { Action.Add,0},
                        { Action.Update,1 },
                        { Action.Delete,2 },
                        };

            eventList = eventList.OrderBy(m => orderMap[m.action]).ToList<Event>();
            //Your code end.
            */

            foreach (Event event1 in eventList)
            {
                Console.WriteLine(event1.action);
            }
            Console.WriteLine("----------");


            eventList.ForEach(x => x.ChangeData(dataList));

            foreach (Data data in dataList)
            {
                Console.WriteLine(data.Id + " " + data.Name + " " + data.Desc);
            }
            Console.WriteLine("----------");
            Console.ReadLine();
        }

        static void InitializeData(List<Data> dataList)
        {
            dataList.Add(new Data { Id = 1, Name = "Name1", Desc = "Desc1" });
            dataList.Add(new Data { Id = 2, Name = "Name2", Desc = "Desc2" });
            dataList.Add(new Data { Id = 3, Name = "Name3", Desc = "Desc3" });
            dataList.Add(new Data { Id = 4, Name = "Name4", Desc = "Desc4" });
            dataList.Add(new Data { Id = 5, Name = "Name5", Desc = "Desc5" });
        }
    }
}
