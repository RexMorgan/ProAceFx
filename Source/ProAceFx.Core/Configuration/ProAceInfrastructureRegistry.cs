using ProAceFx.Core.Infrastructure;
using ProAceFx.Infrastructure;
using StructureMap.Configuration.DSL;

namespace ProAceFx.Core.Configuration
{
    public class ProAceInfrastructureRegistry : Registry
    {
        public ProAceInfrastructureRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.AssemblyContainingType<InfrastructureMarker>();
                         x.IncludeNamespaceContainingType<InfrastructureMarker>();
                         x.IncludeNamespaceContainingType<CoreInfrastructureMarker>();
                         x.WithDefaultConventions();
                     });

            For<IStateProvider>().Use<SessionStateProvider>();
        }
    }
}