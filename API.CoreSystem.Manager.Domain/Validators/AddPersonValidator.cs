using API.CoreSystem.Manager.Domain.ViewModel;
using FluentValidation;

namespace API.CoreSystem.Manager.Domain.Validators
{
    public class AddPersonValidator : AbstractValidator<AddPerson>
    {
        public AddPersonValidator()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.LastName).NotNull();
            RuleFor(c => c.Address).NotNull();
            RuleFor(c => c.Email).NotNull();
            RuleFor(c => c.City).NotNull();
            RuleFor(c => c.State).NotNull();
            RuleFor(c => c.Nationality).NotNull();
            RuleFor(c => c.Phone).NotNull();
            RuleFor(c => c.ZipCode).NotNull();
            RuleFor(c => c.FederalId).NotNull();
        }
    }
}
