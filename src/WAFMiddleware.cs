using System;
using System.Net;
using System.Text;
using System.IO;
using Nfense.NProxy;

namespace Nfense.ModWAF
{
    public class WAFMiddleware : Middleware
    {

        private void SendError(HttpListenerContext ctx)
        {
            ctx.Response.Headers.Add("Content-Type", "text/html");
            byte[] buffer = Encoding.ASCII.GetBytes("<h1>Security Warning</h1><p>Tu solicitud para ser maliciosa, si esto es un error contacta al administrador.</p>");
            ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
            ctx.Response.Close();
        }

        private bool IsMaliciosus(string input, Node node)
        {
            bool xss = (bool)node.GetBool("waf-trigger-xss", false);

            if (xss && XSSTrigger.IsTrigger(input))
            {
                Logger.Debug("[WAF] XSS Module triggered. Input: " + input);
                return true;
            }

            return false;
        }

        private string GetBody(HttpListenerContext ctx, string def)
        {
            if (ctx.Request.HasEntityBody)
            {
                StreamReader streamReader = new StreamReader(ctx.Request.InputStream);
                return streamReader.ReadToEnd();
            }
            else
            {
                return def;
            }
        }

        public override bool OnStartRequest(HttpListenerContext ctx, Node node)
        {
            bool hookBody = (bool)node.GetBool("waf_hook_body", false);
            bool hookUrl = (bool)node.GetBool("waf_hook_url", false);
            bool hookQuery = (bool)node.GetBool("waf_hook_query", false);

            string body = GetBody(ctx, "");
            string url = ctx.Request.Url.LocalPath;
            string query = ctx.Request.QueryString.ToString();

            if (hookUrl && this.IsMaliciosus(url, node))
            {
                this.SendError(ctx);
            }
            else if (hookQuery && this.IsMaliciosus(query, node))
            {
                this.SendError(ctx);
            }
            else if (hookBody && this.IsMaliciosus(body, node))
            {
                this.SendError(ctx);
            }
            else {
                return true;
            }

            return false;
        }
    }
}