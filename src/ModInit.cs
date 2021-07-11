using System.Net;
using System.Text;
using NProxy.Modules;
using NProxy.Nodes;

namespace Nfense.ModWAF {
    internal class ModInit : Module {
        private WAF waf;

        ModInit () {
            this.waf = new WAF();
        }

        public override bool OnStartRequest(HttpListenerContext ctx, Node node)
        {
            WAFResult result = this.waf.EvaluateContext(ctx);

            if (result.Type == WAFResultType.ACCEPTED) {
                return true;
            } else {
                ctx.Response.Headers.Add("Content-Type", "text/html");
                byte[] buffer = Encoding.ASCII.GetBytes("<h1>WAF Security Triggered</h1><p>Your request is suspected of being malicious. If not, contact the site administrator. (Module: " + result.Module.GetName() + ")</p></i>");
                ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
                ctx.Response.Close();
                return false;
            }
        }

        public override string GetName()
        {
            return "ModWAF";
        }
    }
}