using DTO.Request;
using FluentValidation;
using System;
using System.Net;

namespace Infrastructure.Validation
{
    public class HostValidator : AbstractValidator<RequestDto>
    {
        public HostValidator()
        {
            RuleFor(host => host.Host)
                .MinimumLength(5)
                .NotEmpty()
                .Matches(@"^([a-zA-Z0-9\-]+\.)+[a-z]+$");

            RuleFor(host => host.Port)
                .NotEmpty()
                .GreaterThan(0)
                .LessThan(65535);

            RuleFor(host => host.DelayInMilliseconds)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(host => host.ValidStatusCode)
                .Must(statusCode => statusCode == 0 || Enum.IsDefined(typeof(HttpStatusCode), statusCode));
        }
    }
}