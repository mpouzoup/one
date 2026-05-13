using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.ToDo;

public class TaskItemDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int ToDoListId { get; set; }
}