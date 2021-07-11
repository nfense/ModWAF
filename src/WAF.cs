using System.Collections.Generic;
using System.Net;
using Nfense.ModWAF.Modules;

namespace Nfense.ModWAF
{
    public class WAF
    {
        private List<WAFModule> modules;

        public WAF()
        {
            this.modules = new List<WAFModule>();
            this.modules.Add(new XSSModule());
        }

        public WAFResult EvaluateContext(HttpListenerContext ctx)
        {
            foreach (WAFModule module in this.modules)
            {
                if (!module.Validate(ctx))
                {
                    return new WAFResult(WAFResultType.TRIGGERED, module);
                }
            }

            return new WAFResult(WAFResultType.ACCEPTED);
        }
    }
}
