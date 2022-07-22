using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Infrastructure.Mappers.Base
{
    public static class MapperRegistration
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = GetProfiles();
            return new MapperConfiguration(config =>
            {
                foreach (var profile in profiles.Select(profile => (Profile)Activator.CreateInstance(profile)!))
                {
                    config.AddProfile(profile);
                };
            });
        }

        private static List<Type> GetProfiles()
        {
            //Получаем список всех наследников от IAutomapper, но не абстрактные классы которые
            //приводяться к интерфейсу IAutomapper
            return (from t in typeof(Startup).GetTypeInfo().Assembly.GetTypes()
                    where typeof(IAutomapper).IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract
                    select t).ToList();
        }
    }
}
