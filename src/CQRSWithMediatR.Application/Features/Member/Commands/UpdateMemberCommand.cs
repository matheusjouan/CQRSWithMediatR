using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSWithMediatR.Application.Features.Member.Commands;
public class UpdateMemberCommand : IRequest
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public bool? IsActive { get; set; }
}
