using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace ZoEazy.Api.Model.AccountViewModels
{
    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get;  }

        public Uri ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
