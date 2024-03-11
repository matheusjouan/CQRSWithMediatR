using MediatR;

namespace CQRSWithMediatR.Application.Features.Member.Queries;
public record GetMemberByIdQuery(int Id) : IRequest<Domain.Entities.Member>
{
}
