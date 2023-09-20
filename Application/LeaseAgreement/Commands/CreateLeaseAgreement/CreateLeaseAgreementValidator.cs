using FluentValidation;

namespace Application.LeaseAgreement.Commands.CreateLeaseAgreement;

public class CreateLeaseAgreementValidator: AbstractValidator<CreateLeaseAgreementCommand>
{
    public CreateLeaseAgreementValidator()
    {
        RuleFor(p => p.ShelfCount)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .GreaterThan(0)
            .LessThan(6);
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} Email address is required")
            .EmailAddress().WithMessage("{PropertyName} A valid email is required");
        RuleFor(p => p.RentDuration)                                 
            .NotEmpty().WithMessage("{PropertyName} is required") 
            .NotNull()                                            
            .GreaterThan(0)                                       
            .LessThan(100);






    }
}