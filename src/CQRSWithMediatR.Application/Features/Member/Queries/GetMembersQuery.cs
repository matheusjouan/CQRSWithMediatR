using CQRSWithMediatR.Domain.Interface;
using MediatR;

namespace CQRSWithMediatR.Application.Features.Member.Queries;
public class GetMembersQuery : IRequest<IEnumerable<Domain.Entities.Member>>
{ }
