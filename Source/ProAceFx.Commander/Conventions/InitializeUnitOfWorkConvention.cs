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
                .Each(AddCommandNode);

            graph
                .ChainsForExisting
                .Each(AddCommandNode);
        }

        private static void AddCommandNode(CommandChain chain)
        {
            chain.Prepend(new Wrapper(typeof (InitializeUnitOfWorkCommand)));
        }
    }
}