using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Service
{
    public class TaskService : ITaskService
    {
        private static List<TaskModel> _people = new List<TaskModel>(){
            new TaskModel(){
                ID = Guid.NewGuid().ToString(),
                Title = "asdb sdasf",
                IsCompleted = true,
            },
            new TaskModel(){
                ID = Guid.NewGuid().ToString(),
                Title = "Cuong",
                IsCompleted = true,
            },
            new TaskModel(){
                ID = Guid.NewGuid().ToString(),
                Title = "Tran",
                IsCompleted = true,
            },
            new TaskModel(){
                ID = Guid.NewGuid().ToString(),
                Title = "Binalsdn",
                IsCompleted = true,
            },
            new TaskModel(){
                ID = Guid.NewGuid().ToString(),
                Title = "Torampu",
                IsCompleted = true,
            },
            new TaskModel(){
                ID = Guid.NewGuid().ToString(),
                Title = "Gigi",
                IsCompleted = true,
            },
            new TaskModel(){
                ID = Guid.NewGuid().ToString(),
                Title = "Rina Tsukino",
                IsCompleted = true,
            },
        };
        public List<TaskModel> GetAll(){
            return _people;
        }
        public TaskModel GetOne(int index){
            if(index >-1 && index < _people.Count())
                return _people[index];
            return null;
        }
        public TaskModel Create(TaskModel person){
            if (person != null)
                _people.Add(person);
                return person;
        }
        public TaskModel Update(string ID, TaskModel person){
            if (_people.Any(o=>o.ID == ID))
                _people.All(o=> {o = person; return true;});
                return person;
        }
        public TaskModel Delete(string ID, TaskModel person){
            if (_people.Any(o=>o.ID == ID))
                _people.All(o=> {o = person; return true;});
                return person;
        }
        public List<TaskModel> AddMultiple(List<TaskModel> persons){
            _people.AddRange(persons);
            return persons;
        }
        public List<TaskModel> DeleteMultiple(List<string> IDs){
            var removeList = _people.Where(o=>IDs.Contains(o.ID)).ToList();
            _people.RemoveAll(o=>IDs.Contains(o.ID));
            return removeList;
        }
    }
}