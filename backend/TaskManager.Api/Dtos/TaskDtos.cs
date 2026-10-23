using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Dtos;

public class CreateTaskDto
{
    [Required(ErrorMessage = "Tytuł jest wymagany.")]
    [StringLength(200, ErrorMessage = "Tytuł może mieć max. 200 znaków.")]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = "todo";

    public DateOnly? DueDate { get; set; }
}

public class UpdateTaskDto : CreateTaskDto
{
}

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateOnly? DueDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
