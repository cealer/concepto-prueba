// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    city = "Lima",
                    country = "Peru"
                };

                return new List<TestUser>
                {
                     new TestUser
                    {
                        SubjectId = "1",
                        Username = "piero",
                        Password = "piero",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Piero Storace"),
                            new Claim(JwtClaimTypes.GivenName, "Piero"),
                            new Claim(JwtClaimTypes.FamilyName, "Storace"),
                            new Claim(JwtClaimTypes.Email, "piero@lilab.pe"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "super-admin")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "2",
                        Username = "ramiro",
                        Password = "ramiro",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Ramiro Arivilca"),
                            new Claim(JwtClaimTypes.GivenName, "Ramiro"),
                            new Claim(JwtClaimTypes.FamilyName, "Arivilca"),
                            new Claim(JwtClaimTypes.Email, "ramiro@lilab.pe"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "app1")

                        }
                    },
                    new TestUser
                    {
                        SubjectId = "3",
                        Username = "luis",
                        Password = "luis",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Luis Atencio"),
                            new Claim(JwtClaimTypes.GivenName, "Luis"),
                            new Claim(JwtClaimTypes.FamilyName, "Atencio"),
                            new Claim(JwtClaimTypes.Email, "luis@lilab.pe"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "app2")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "4",
                        Username = "singara",
                        Password = "singara",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Singara Gonzales"),
                            new Claim(JwtClaimTypes.GivenName, "Singara"),
                            new Claim(JwtClaimTypes.FamilyName, "Gonzales"),
                            new Claim(JwtClaimTypes.Email, "Singara@lilab.pe"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "app3")
                        }
                    }
                };
            }
        }
    }
}