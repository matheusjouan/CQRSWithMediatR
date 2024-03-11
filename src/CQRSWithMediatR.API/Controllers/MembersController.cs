using CQRSWithMediatR.Application.Features.Member.Commands;
using CQRSWithMediatR.Application.Features.Member.Queries;
using CQRSWithMediatR.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithMediatR.API.Controllers;

[Route("[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMembersAsync()
    {
        var request = new GetMembersQuery();
        var members = await _mediator.Send(request);

        return Ok(members);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMember(int id)
    {
        var request = new GetMemberByIdQuery(id);
        var member = await _mediator.Send(request);

        return member != null ? Ok(member) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateMemberAsync(CreateMemberCommand command)
    {
        var createdMember = await _mediator.Send(command);
        await _mediator.Publish(createdMember);

        return CreatedAtAction(nameof(GetMember), new { id = createdMember.Id }, createdMember);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMemberAsync(int id, UpdateMemberCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        command.Id = id;

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMemberAsync(int id)
    {
        var command = new DeleteMemberCommand { Id = id };
        await _mediator.Send(command);

        return NoContent();
    }
}
