using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.ToDo;

public class CreateToDoListDto
{
    public string Title { get; set; }
    public int UserId { get; set; }
}