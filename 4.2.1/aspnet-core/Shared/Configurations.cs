﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;

namespace Shared
{
    public static class Configurations
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> ConfigurationCache;

        static Configurations()
        {
            ConfigurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfigurationRoot Get(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var cacheKey = path + "#" + environmentName + "#" + addUserSecrets;
            return ConfigurationCache.GetOrAdd(
                cacheKey,
                _ => BuildConfiguration(path, environmentName, addUserSecrets)
            );
        }

        private static IConfigurationRoot BuildConfiguration(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!environmentName.IsNullOrWhiteSpace())
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();

            if (addUserSecrets)
            {
                builder.AddUserSecrets(typeof(Configurations).GetAssembly());
            }

            return builder.Build();
        }
    }

}
