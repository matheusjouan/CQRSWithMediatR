using CQRSWithMediatR.Application.Features.Member.Commands;
using CQRSWithMediatR.Domain.Interface;
using MediatR;

namespace CQRSWithMediatR.Application.Features.Member.Handlers;
public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand>
{
    private readonly IUnitOfWork _uow;

    public DeleteMemberCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var deletedMember = await _uow.MemberRepository.DeleteMember(request.Id);

        if (deletedMember is null)
            throw new InvalidOperationException("Member not found");

        await _uow.CommitAsync();
    }
}
