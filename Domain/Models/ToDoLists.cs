using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class ToDoList
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}