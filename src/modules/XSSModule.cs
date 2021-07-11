using System.Net;

namespace Nfense.ModWAF.Modules
{
    public class XSSModule : WAFModule
    {
        public override string GetName()
        {
            return "XSS";
        }

        public override bool Validate(HttpListenerContext ctx)
        {
            if (ctx.Request.Url.PathAndQuery.StartsWith("/test"))
            {
                return false;
            }

            return true;
        }
    }
}