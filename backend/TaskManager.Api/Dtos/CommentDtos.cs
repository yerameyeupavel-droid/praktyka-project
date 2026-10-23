using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Dtos;

public class CreateCommentDto
{
    [Required(ErrorMessage = "Komentarz nie może być pusty.")]
    [StringLength(1000, MinimumLength = 1, ErrorMessage = "Komentarz może mieć max. 1000 znaków.")]
    public string Content { get; set; } = string.Empty;
}

public class CommentDto
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
}
