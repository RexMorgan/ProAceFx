using System.Collections.Generic;
using Commander.Registration;
using Commander.Registration.Nodes;

namespace ProAceFx.Commander.Conventions
{
    public class InitializeUnitOfWorkConvention : IConfigurationAction
    {
        public void Configure(CommandGraph graph)
        {
            graph
                .ChainsForNew
                .Each(call => AddCommandNode(graph, call));

            graph
                .ChainsForExisting
                .Each(call => AddCommandNode(graph, call));
        }

        private static void AddCommandNode(CommandGraph graph, CommandChain chain)
        {
            graph.Observer.RecordCallStatus(chain, "Prepending chain with InitializeUnitOfWorkCommand.");
            chain.Prepend(new Wrapper(typeof (InitializeUnitOfWorkCommand)));
        }
    }
}