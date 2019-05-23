using AutoMapper;
using System;
using System.Linq;

namespace JK.Cube.Api._Autommaper
{
    public static class AutommapperBoostrapper
    {
        public static void RegisterProfiles()
        {
            var assembliesTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(an => an.GetTypes())
                .Where(p => typeof(Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract && !p.IsInterface)
                .Distinct();


            var autoMapperProfiles = assembliesTypes
                .Select(p => (Profile)Activator.CreateInstance(p)).ToList();
            Mapper.Initialize(cfg => {
                cfg.AddProfiles(autoMapperProfiles);
            });
        }
    }
}
