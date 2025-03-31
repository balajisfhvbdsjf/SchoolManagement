﻿using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Principal principal);
        bool ValidateToken(string token);
    }
}
