using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.ToDo;

public class ToDoListDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }

    public List<TaskItemDto> Tasks { get; set; } = new();
}