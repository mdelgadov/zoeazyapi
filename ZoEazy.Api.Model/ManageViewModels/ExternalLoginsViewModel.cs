using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ZoEazy.Api.Model.ManageViewModels
{
    public class ExternalLoginsViewModel
    {
        public IEnumerable<UserLoginInfo> CurrentLogins { get; set; }

        public IEnumerable<AuthenticationScheme> OtherLogins { get; set; }

        public bool ShowRemoveButton { get; set; }

        public string StatusMessage { get; set; }
    }
}
