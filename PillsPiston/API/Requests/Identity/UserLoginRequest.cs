﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PillsPiston.API.Requests.Identity
{
    public class UserLoginRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        [NotNull]
        public string Password { get; set; }
    }
}
