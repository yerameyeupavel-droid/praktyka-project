using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Api.Models;

[Table("tasks")]
public class TaskItem
{
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [Column("status")]
    public string Status { get; set; } = "todo";

    [Column("due_date")]
    public DateOnly? DueDate { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    [Column("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public User? User { get; set; }
    public List<Comment> Comments { get; set; } = new();
}
