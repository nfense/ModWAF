using System.Net;

namespace ModWAF.Modules
{
    public abstract class WAFModule
    {
        public abstract string GetName();
        public abstract bool Validate(HttpListenerContext ctx);
    }
}