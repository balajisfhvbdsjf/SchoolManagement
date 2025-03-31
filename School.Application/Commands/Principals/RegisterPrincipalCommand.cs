using MediatR;
using School.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Commands.Principals
{
    public class RegisterPrincipalCommand : IRequest<bool>
    {
        public PrincipalDto Principal { get; set; }

        public RegisterPrincipalCommand(PrincipalDto principal)
        {
            Principal = principal;
        }
    }

}
