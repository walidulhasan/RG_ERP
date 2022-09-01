﻿using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.HangfireActive
{
    public class HangfireActivator : JobActivator
    {
        private readonly IServiceProvider _serviceProvider;

        public HangfireActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override object ActivateJob(Type type)
        {
            return _serviceProvider.GetService(type);
        }
    }
}
