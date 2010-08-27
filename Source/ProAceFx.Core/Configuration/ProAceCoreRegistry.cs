using StructureMap.Configuration.DSL;

namespace ProAceFx.Core.Configuration
{
    public class ProAceCoreRegistry : Registry
    {
        public ProAceCoreRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.IncludeNamespaceContainingType<ProAceCoreRegistry>();
                x.ExcludeType<ProAceCoreRegistry>();
                x.LookForRegistries();
            });
        }
    }
}