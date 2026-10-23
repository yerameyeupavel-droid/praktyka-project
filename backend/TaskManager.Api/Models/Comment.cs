using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Api.Models;

[Table("comment")]
public class Comment
{
    [Column("id")]
    public int Id { get; set; }

    [Column("task_id")]
    public int TaskId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("content")]
    public string Content { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public TaskItem? Task { get; set; }
    public User? User { get; set; }
}
