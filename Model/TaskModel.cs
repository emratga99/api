using System.ComponentModel.DataAnnotations;

namespace api.Model
{
    public class TaskModel
    {
        public string ID { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Title { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}