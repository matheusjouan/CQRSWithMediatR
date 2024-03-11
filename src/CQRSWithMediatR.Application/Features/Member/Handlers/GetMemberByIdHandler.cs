using CQRSWithMediatR.Application.Features.Member.Queries;
using CQRSWithMediatR.Domain.Interface;
using MediatR;

namespace CQRSWithMediatR.Application.Features.Member.Handlers;
public class GetMemberByIdHandler : IRequestHandler<GetMemberByIdQuery, Domain.Entities.Member>
{
    private readonly IMemberDapperRepository _memberDapperRepository;

    public GetMemberByIdHandler(IMemberDapperRepository memberDapperRepository)
    {
        _memberDapperRepository = memberDapperRepository;
    }

    public async Task<Domain.Entities.Member> Handle(GetMemberByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var member = await _memberDapperRepository.GetMemberById(request.Id);
        return member;
    }
}
