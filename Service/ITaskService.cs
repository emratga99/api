using api.Model;
namespace api.Service
{
    public interface ITaskService
    {
        
        public List<TaskModel> GetAll();
        public TaskModel GetOne(int index);
        public TaskModel Create(TaskModel person);
        public TaskModel Update(string ID, TaskModel person);
        public TaskModel Delete(string ID, TaskModel person);
        public List<TaskModel> AddMultiple(List<TaskModel> persons);
        public List<TaskModel> DeleteMultiple(List<string> IDs);
    }
}