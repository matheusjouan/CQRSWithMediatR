using MediatR;

namespace CQRSWithMediatR.Application.Features.Member.Commands;
public class DeleteMemberCommand : IRequest
{
    public int Id { get; set; }
}
