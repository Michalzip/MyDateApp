using Microsoft.AspNetCore.Http;

namespace Shared.Abstraction.Extensions
{
    public class ContextAccessorExtension
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ContextAccessorExtension(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;

        }

        public void SetSession(string key, string value)
        {

            _contextAccessor.HttpContext.Session.SetString(key, value);

        }


        public string GetSession(string key)
        {

            return _contextAccessor.HttpContext.Session.GetString(key);


        }
    }
}