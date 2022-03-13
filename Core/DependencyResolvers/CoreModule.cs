using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection collection)
        {
           
        }
    }
}