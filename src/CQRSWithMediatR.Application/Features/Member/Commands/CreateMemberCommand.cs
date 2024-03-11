﻿using MediatR;

namespace CQRSWithMediatR.Application.Features.Member.Commands;
public class CreateMemberCommand : IRequest<Domain.Entities.Member>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
}
