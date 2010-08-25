using System.Collections.Generic;
using Commander.Registration;
using Commander.Registration.Nodes;

namespace ProAceFx.Commander.Conventions
{
    public class InsertNewEntitiesConvention : IConfigurationAction
    {
        public void Configure(CommandGraph graph)
        {
            graph
                .ChainsForNew
                .Each(chain => chain.Placeholder().AddAfter(new Wrapper(typeof(InsertEntityCommand<>).MakeGenericType(chain.EntityType))));
        }
    }
}