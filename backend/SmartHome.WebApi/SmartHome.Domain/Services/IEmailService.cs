﻿using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface IEmailService
    {
        Task SendActivationEmail(User user, ActivationToken activationToken);

        Task SendApprovePropertyEmail(User user, Property property);
        Task SendSuperAdminCredentials(User superAdmin);
        Task SendRejectPropertyEmail(User user, Property property, string description);


    }
}
