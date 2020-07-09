using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Test;
using IdentityServerHost.Quickstart.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly TestUserStore _users;

        #region Métodos

        public ProfileService(TestUserStore users = null)
        {
            _users = users ?? new TestUserStore(TestUsers.Users);
        }

        //Obtener datos del usuario (Claims)
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject ??
                throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.Claims.Where(x => x.Type == "sub")
                .FirstOrDefault().Value;

            var user = _users.FindBySubjectId(subjectId);

            var claims = user.Claims;

            if (user == null)
            {
                throw new ArgumentException("Invalid subject identifier");
            }

            var claimsReturn = GetClaimsFromUser(user, claims);

            context.IssuedClaims = claimsReturn.ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject ??
                throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.Claims.Where(x => x.Type == "sub")
                .FirstOrDefault().Value;

            var user = _users.FindBySubjectId(subjectId);
            context.IsActive = false;
            context.IsActive = user.IsActive;
        }


        private IEnumerable<Claim> GetClaimsFromUser(TestUser user, ICollection<Claim> claimList)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.SubjectId),
                new Claim(JwtClaimTypes.PreferredUserName, user.Username),
                new Claim(JwtClaimTypes.Name,claimList.Where(x=>x.Type.Contains("name"))
                .Select(x=>x.Value).FirstOrDefault()),
                 new Claim(JwtClaimTypes.GivenName,claimList.Where(x=>x.Type.Contains("given_name"))
                .Select(x=>x.Value).FirstOrDefault()),
                 new Claim(JwtClaimTypes.FamilyName,claimList.Where(x=>x.Type.Contains("family_name"))
                .Select(x=>x.Value).FirstOrDefault()),
                 new Claim(JwtClaimTypes.Email,claimList.Where(x=>x.Type.Contains("email"))
                .Select(x=>x.Value).FirstOrDefault()),
                 new Claim(JwtClaimTypes.EmailVerified,claimList.Where(x=>x.Type.Contains("email_verified"))
                .Select(x=>x.Value).FirstOrDefault()),
            };

            var roles = claimList.Where(x => x.Type.Contains("role")).Select(x => x.Value).FirstOrDefault();
            claims.Add(new Claim(JwtClaimTypes.Role, roles));

            return claims;
        }

        #endregion


    }
    public class ClaimsComparer : IEqualityComparer<Claim>
    {
        public bool Equals(Claim x, Claim y)
        {
            return x.Value == y.Value;
        }
        public int GetHashCode(Claim claim)
        {
            var claimValue = claim.Value?.GetHashCode() ?? 0;
            return claimValue;
        }
    }
}