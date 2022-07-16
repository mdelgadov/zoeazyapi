using System.Collections.Generic;
using System;
using System.Linq;
using IdentityServer4;
using IdentityServer4.Models;

namespace ZoEazy.Api.Model
{
    public class ConsentViewModel : ConsentInputModel
    {
        public ConsentViewModel(ConsentInputModel model, Uri returnUrl, AuthorizationRequest request, Client client, IdentityServer4.Models.Resources resources)
        {
            RememberConsent = model?.RememberConsent ?? true;
            ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>();

            ReturnUrl = returnUrl;
            if (client == null) return;
            ClientName = client.ClientName;
            ClientUrl = new Uri( client.ClientUri);
            ClientLogoUrl = new Uri(client.LogoUri);
            AllowRememberConsent = client.AllowRememberConsent;
            if (resources != null)
            {
                IdentityScopes = resources.IdentityResources.Select(x => new ScopeViewModel(x, ScopesConsented.Contains(x.Name) || model == null)).ToArray();
                ResourceScopes = resources.ApiResources.SelectMany(x => x.Scopes).Select(x => new ScopeViewModel(x, ScopesConsented.Contains(x.Name) || model == null)).ToArray();
                if (resources.OfflineAccess)
                {
                    ResourceScopes = ResourceScopes.Union(new ScopeViewModel[] {
                    ScopeViewModel.GetOfflineAccess(ScopesConsented.Contains(IdentityServerConstants.StandardScopes.OfflineAccess) || model == null)
                });
                }
            }
        }

        public string ClientName { get; set; }
        public Uri ClientUrl { get; set; }
        public Uri ClientLogoUrl { get; set; }
        public bool AllowRememberConsent { get; set; }

        public IEnumerable<ScopeViewModel> IdentityScopes { get;  }
        public IEnumerable<ScopeViewModel> ResourceScopes { get;  }
    }

    public class ScopeViewModel
    {
        public static ScopeViewModel GetOfflineAccess(bool check)
        {
            return new ScopeViewModel
            {
                Name = IdentityServerConstants.StandardScopes.OfflineAccess,
                DisplayName = "Offline Access",
                Description = "Access to your applications and resources, even when you are offline",
                Emphasize = true,
                Checked = check
            };
        }

        private ScopeViewModel()
        {
        }

        public ScopeViewModel(IdentityResource identity, bool check)
        {
            if (identity != null)
            {
                Name = identity.Name;
                DisplayName = identity.DisplayName;
                Description = identity.Description;
                Emphasize = identity.Emphasize;
                Required = identity.Required;
                Checked = check || identity.Required;
            }
        }

        public ScopeViewModel(Scope scope, bool check)
        {
            if (scope != null)
            {
                Name = scope.Name;
                DisplayName = scope.DisplayName;
                Description = scope.Description;
                Emphasize = scope.Emphasize;
                Required = scope.Required;
                Checked = check || scope.Required;
            }
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Emphasize { get; set; }
        public bool Required { get; set; }
        public bool Checked { get; set; }
    }
}
