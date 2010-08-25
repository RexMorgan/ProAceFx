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
                .Each(chain =>
                          {
                              graph.Observer.RecordCallStatus(chain.Placeholder(), "Adding InsertEntityCommand directly after placeholder");
                              chain.Placeholder().AddAfter(
                                  new Wrapper(typeof (InsertEntityCommand<>).MakeGenericType(chain.EntityType)));
                          });
        }
    }
}