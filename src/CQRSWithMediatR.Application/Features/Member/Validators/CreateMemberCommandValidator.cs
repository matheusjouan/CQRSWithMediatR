using CQRSWithMediatR.Application.Features.Member.Commands;
using FluentValidation;

namespace CQRSWithMediatR.Application.Features.Member.Validators;
public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
	public CreateMemberCommandValidator()
	{
		RuleFor(c => c.FirstName)
			.NotEmpty().WithMessage("This field is required")
			.Length(4, 100).WithMessage("Must have betwwen 4 and 100 characters");

        RuleFor(c => c.LastName)
			.NotEmpty().WithMessage("This field is required")
			.Length(4, 100).WithMessage("Must have betwwen 4 and 100 characters");

		RuleFor(c => c.Email)
			.NotEmpty()
			.EmailAddress();

		RuleFor(c => c.Gender)
			.NotEmpty()
			.MinimumLength(4).WithMessage("Must be a valida information");
    }
}
