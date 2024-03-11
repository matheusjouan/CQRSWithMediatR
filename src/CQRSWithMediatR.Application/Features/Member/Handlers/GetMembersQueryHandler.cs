using CQRSWithMediatR.Application.Features.Member.Queries;
using CQRSWithMediatR.Domain.Interface;
using MediatR;

namespace CQRSWithMediatR.Application.Features.Member.Handlers;
public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<Domain.Entities.Member>>
{
    private readonly IMemberDapperRepository _memberDapperRepository;

    public GetMembersQueryHandler(IMemberDapperRepository memberDapperRepository)
    {
        _memberDapperRepository = memberDapperRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Member>> Handle(GetMembersQuery request, 
        CancellationToken cancellationToken)
    {
        var members = await _memberDapperRepository.GetMembers();
        return members;
    }
}
