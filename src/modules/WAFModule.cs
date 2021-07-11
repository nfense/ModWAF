using System.Net;

namespace Nfense.ModWAF.Modules
{
    public abstract class WAFModule
    {
        public abstract string GetName();
        public abstract bool Validate(HttpListenerContext ctx);
    }
}