using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace NotTwitter.Configurations
{
    public class StartUp
    {
        private static readonly ServiceCollection _serviceCollection = new ServiceCollection();

        public static void Configure()
        {
            ServiceLocator.Configure(_serviceCollection);
        }

    }
}
