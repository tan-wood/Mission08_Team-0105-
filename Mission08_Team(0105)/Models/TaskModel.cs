using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Team_0105_.Models
{
    public class TaskModel
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string TaskText { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        //foreign key
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public bool Completed { get; set; }
    }
}
