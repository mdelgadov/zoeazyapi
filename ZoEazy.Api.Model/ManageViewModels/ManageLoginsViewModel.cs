using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ZoEazy.Api.Model.ManageViewModels
{
    public class ManageLoginsViewModel
    {
        public IEnumerable<UserLoginInfo> CurrentLogins { get; set; }

        public IEnumerable<AuthenticationDescription> OtherLogins { get; set; }
    }
}
