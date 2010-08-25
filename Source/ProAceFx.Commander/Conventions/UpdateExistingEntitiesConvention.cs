using System.Collections.Generic;
using Commander.Registration;
using Commander.Registration.Nodes;

namespace ProAceFx.Commander.Conventions
{
    public class UpdateExistingEntitiesConvention : IConfigurationAction
    {
        public void Configure(CommandGraph graph)
        {
            graph
                .ChainsForExisting
                .Each(chain => chain.AddAfter(new Wrapper(typeof(UpdateEntityCommand<>).MakeGenericType(chain.EntityType))));
        }
    }
}