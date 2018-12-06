using Microsoft.AspNetCore.Antiforgery;
using JsonIssue.Controllers;

namespace JsonIssue.Web.Host.Controllers
{
    public class AntiForgeryController : JsonIssueControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
