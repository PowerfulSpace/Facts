using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using PowerfulSpace.Facts.Web.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Calabonga.Microservices.Core.Exceptions;

namespace PowerfulSpace.Facts.Web.Data
{
    public static class DataInitializer
    {
        public static async Task InitializerAsync(IServiceProvider serviceProvider)
        {

            var scope = serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            //context! говорю что context не может быть Null, дальше проверяю что DatabaseCreator существует
            var isExists = context!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator &&
                await databaseCreator.ExistsAsync();

            //Если бд существует, то просто возвращаю, ни чем дополнительно не наполняю
            if (isExists)
            {
                return;
            }

            //Если бд не существует, Создать бд
            await context.Database.MigrateAsync();

            //Получаем все роли
            var roles = AppData.Roles.ToArray();

            //Получаем хранилище ролей
            var roleStore = new RoleStore<IdentityRole>(context);

            foreach (var role in roles)
            {
                if (context.Roles.Any(x => x.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role)
                    {
                        //Устанавливаем имя роли с Высокого регистра
                        NormalizedName = role.ToUpper()
                    });
                }
            }


            const string username = "powerful@space.com";

            if (context.Users.Any(x => x.Email == username))
            {
                return;
            }

            var user = new IdentityUser
            {
                Email = username,
                EmailConfirmed = true,
                NormalizedEmail = username.ToUpper(),
                PhoneNumber = "+375290000000",
                UserName = username,
                PhoneNumberConfirmed = true,
                NormalizedUserName = username.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user,"123qwe!@#");

            var userStore = new UserStore<IdentityUser>(context);
            var identityResult = await userStore.CreateAsync(user);

            if (identityResult.Succeeded)
            {
                var message = string.Join(", ", identityResult.Errors.Select(x => $"{x.Code}: {x.Description}"));
                throw new MicroserviceDatabaseException(message);
            }
        }
    }
}
