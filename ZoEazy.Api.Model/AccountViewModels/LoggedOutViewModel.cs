﻿using System;

namespace ZoEazy.Api.Model.AccountViewModels
{
    public class LoggedOutViewModel
    {
        public Uri PostLogoutRedirectUri { get; set; }
        public string ClientName { get; set; }
        public Uri SignOutIframeUrl { get; set; }

        public bool AutomaticRedirectAfterSignOut { get; set; }

        public string LogoutId { get; set; }
        public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;
        public string ExternalAuthenticationScheme { get; set; }
    }
}