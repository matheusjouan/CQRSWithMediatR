using CQRSWithMediatR.Application.Features.Member.Commands;
using CQRSWithMediatR.Domain.Interface;
using FluentValidation;
using MediatR;

namespace CQRSWithMediatR.Application.Features.Member.Handlers;
public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Domain.Entities.Member>
{
    private readonly IUnitOfWork _uow;

    public CreateMemberCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    //private readonly IValidator<CreateMemberCommand> _validator;

    //public CreateMemberCommandHandler(IUnitOfWork uow, IValidator<CreateMemberCommand> validator)
    //{
    //    _uow = uow;
    //    _validator = validator;
    //}

    public async Task<Domain.Entities.Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {

        //_validator.ValidateAndThrow(request);

        var member = new Domain.Entities.Member(request.FirstName, request.LastName, request.Gender,
            request.Email, true);

        var createdMember = await _uow.MemberRepository.AddMember(member);

        await _uow.CommitAsync();

        return createdMember;
    }
}
