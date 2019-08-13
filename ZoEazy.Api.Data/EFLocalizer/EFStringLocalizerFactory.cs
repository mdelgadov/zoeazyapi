﻿using System;
using Microsoft.Extensions.Localization;

namespace ZoEazy.Api.Data
{
    public class EFStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly ZoeazyDbContext _context;

        public EFStringLocalizerFactory(ZoeazyDbContext context)
        {
            _context = context;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new EFStringLocalizer(_context);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new EFStringLocalizer(_context);
        }
    }
}
