using CQRSWithMediatR.Application.Features.Member.Commands;
using CQRSWithMediatR.Domain.Interface;
using MediatR;

namespace CQRSWithMediatR.Application.Features.Member.Handlers;
public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand>
{
    private readonly IUnitOfWork _uow;

    public UpdateMemberCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _uow.MemberRepository.GetMemberById(request.Id);

        if (member is null)
            throw new InvalidOperationException("Member not found");

        member.Update(request.FirstName, request.LastName, request.Gender, 
            request.Email, request.IsActive);
        
        _uow.MemberRepository.UpdateMember(member);

        await _uow.CommitAsync();
    }
}
