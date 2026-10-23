using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Dtos;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/tasks/{taskId:int}/comments")]
[Authorize]
public class CommentsController : ControllerBase
{
    private readonly AppDbContext _db;

    public CommentsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<CommentDto>>> GetComments(int taskId)
    {
        var task = await FindTask(taskId);

        if (task == null)
        {
            return NotFound(new { message = "Nie ma takiego zadania." });
        }

        var comments = await _db.Comments
            .Where(c => c.TaskId == taskId)
            .Include(c => c.User)
            .OrderBy(c => c.Id)
            .ToListAsync();

        return Ok(comments.Select(ToDto).ToList());
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> AddComment(int taskId, CreateCommentDto dto)
    {
        var task = await FindTask(taskId);

        if (task == null)
        {
            return NotFound(new { message = "Nie ma takiego zadania." });
        }

        var comment = new Comment
        {
            TaskId = taskId,
            UserId = CurrentUserId(),
            Content = dto.Content.Trim(),
            CreatedAt = DateTimeOffset.UtcNow
        };

        _db.Comments.Add(comment);
        await _db.SaveChangesAsync();

        var username = User.FindFirst(ClaimTypes.Name)?.Value
            ?? User.FindFirst("unique_name")?.Value
            ?? "?";

        return StatusCode(201, new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            Username = username,
            CreatedAt = comment.CreatedAt
        });
    }

    private int CurrentUserId()
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(value, out var id) ? id : 0;
    }

    private Task<TaskItem?> FindTask(int taskId)
    {
        var userId = CurrentUserId();
        return _db.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);
    }

    private static CommentDto ToDto(Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            Username = comment.User?.Username ?? "?",
            CreatedAt = comment.CreatedAt
        };
    }
}
