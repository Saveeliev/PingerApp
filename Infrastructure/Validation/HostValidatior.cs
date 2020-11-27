using DTO.Request;
using FluentValidation;
using Infrastructure.Options;

namespace Infrastructure.Validation
{
    public class HostValidatior : AbstractValidator<RequestDto>
    {
        public HostValidatior()
        {
            RuleFor(host => host.Host)
                .MinimumLength(5)
                .NotEmpty()
                .Matches(@"^([a-zA-Z0-9\-]+\.)+[a-z]+$");

            RuleFor(host => host.Port)
                .NotEmpty();

            RuleFor(host => host.Delay)
                .NotEmpty();
        }
    }
}