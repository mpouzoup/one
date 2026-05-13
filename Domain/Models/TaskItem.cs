using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models;

public class TaskItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public int ToDoListId { get; set; }

    [ForeignKey("ToDoListId")]
    public virtual ToDoList ToDoList { get; set; }
}