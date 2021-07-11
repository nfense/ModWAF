using Nfense.NProxy;

namespace Nfense.ModWAF
{
    internal class ModInit : Module
    {
        ModInit () {}

        public override void Init()
        {
            NProxy.NProxy.AddMiddleware(new WAFMiddleware());
        }

        public override string GetName()
        {
            return "ModWAF";
        }
    }
}
