using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebAPI.Configurations
{
    public static class RoleString
    {
        public const string Client = "client";
        public const string Salon = "salon";
        public const string Worker = "worker";
    }
    public static class HairDresserRoles
    {
        private static readonly string[] _roles = new[] {
        RoleString.Client,
        RoleString.Salon,
        RoleString.Worker
        };
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in _roles)
            {

                if (!await roleManager.RoleExistsAsync(role))
                {
                    var create = await roleManager.CreateAsync(new IdentityRole(role));

                    if (!create.Succeeded)
                    {

                        throw new Exception("Failed to create role");

                    }
                }

            }

        }
    }
}
