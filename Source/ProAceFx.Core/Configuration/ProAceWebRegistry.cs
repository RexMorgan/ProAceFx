using ProAceFx.Core.Web;
using ProAceFx.Web;
using StructureMap.Configuration.DSL;

namespace ProAceFx.Core.Configuration
{
    public class ProAceWebRegistry : Registry
    {
        public ProAceWebRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.AssemblyContainingType<WebMarker>();
                         x.IncludeNamespaceContainingType<WebMarker>();
                         x.IncludeNamespaceContainingType<CoreWebMarker>();
                         x.WithDefaultConventions();
                     });
        }
    }
}