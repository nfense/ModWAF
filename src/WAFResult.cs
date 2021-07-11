using Nfense.ModWAF.Modules;

namespace Nfense.ModWAF
{
    public class WAFResult
    {
        public readonly WAFResultType Type;
        public readonly WAFModule Module;

        public WAFResult(WAFResultType type)
        {
            this.Type = type;
            this.Module = null;
        }

        public WAFResult(WAFResultType type, WAFModule module)
        {
            this.Type = type;
            this.Module = module;
        }
    }
}