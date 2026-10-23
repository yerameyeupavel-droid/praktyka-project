using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Dtos;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/tasks")]
[Authorize]
public class TasksController : ControllerBase
{
    private static readonly string[] Statuses = { "todo", "in_progress", "done" };

    private readonly AppDbContext _db;

    public TasksController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskDto>>> GetTasks([FromQuery] string? status)
    {
        var userId = CurrentUserId();
        var query = _db.Tasks.Where(t => t.UserId == userId);

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(t => t.Status == status);
        }

        var tasks = await query.OrderBy(t => t.Id).ToListAsync();
        return Ok(tasks.Select(ToDto).ToList());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaskDto>> GetTask(int id)
    {
        var task = await FindTask(id);

        if (task == null)
        {
            return NotFound(new { message = "Nie ma takiego zadania." });
        }

        return Ok(ToDto(task));
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask(CreateTaskDto dto)
    {
        var status = (dto.Status ?? "todo").Trim().ToLowerInvariant();

        if (!Statuses.Contains(status))
        {
            return BadRequest(new { message = "Status musi być: todo, in_progress albo done." });
        }

        var task = new TaskItem
        {
            UserId = CurrentUserId(),
            Title = dto.Title.Trim(),
            Description = string.IsNullOrWhiteSpace(dto.Description) ? null : dto.Description.Trim(),
            Status = status,
            DueDate = dto.DueDate,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };

        _db.Tasks.Add(task);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, ToDto(task));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TaskDto>> UpdateTask(int id, UpdateTaskDto dto)
    {
        var task = await FindTask(id);

        if (task == null)
        {
            return NotFound(new { message = "Nie ma takiego zadania." });
        }

        var status = (dto.Status ?? "todo").Trim().ToLowerInvariant();

        if (!Statuses.Contains(status))
        {
            return BadRequest(new { message = "Status musi być: todo, in_progress albo done." });
        }

        task.Title = dto.Title.Trim();
        task.Description = string.IsNullOrWhiteSpace(dto.Description) ? null : dto.Description.Trim();
        task.Status = status;
        task.DueDate = dto.DueDate;
        task.UpdatedAt = DateTimeOffset.UtcNow;

        await _db.SaveChangesAsync();

        return Ok(ToDto(task));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await FindTask(id);

        if (task == null)
        {
            return NotFound(new { message = "Nie ma takiego zadania." });
        }

        _db.Tasks.Remove(task);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    private int CurrentUserId()
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(value, out var id) ? id : 0;
    }

    private Task<TaskItem?> FindTask(int id)
    {
        var userId = CurrentUserId();
        return _db.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
    }

    private static TaskDto ToDto(TaskItem task)
    {
        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            DueDate = task.DueDate,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt
        };
    }
}
