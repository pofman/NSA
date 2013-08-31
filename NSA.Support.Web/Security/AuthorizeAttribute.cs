using System.Linq;
using NSA.Support.Extensions;

namespace NSA.Support.Web.Security
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        public AuthorizeAttribute(params Roles[] roles)
        {
            if (roles.Any())
                Roles = roles.Join(",");
        }
    }
}