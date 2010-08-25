using System.Collections.Generic;
using Commander.Registration;
using Commander.Registration.Nodes;

namespace ProAceFx.Commander.Conventions
{
    public class CommitUnitOfWorkConvention : IConfigurationAction
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
            chain
                .Placeholder()
                .AddAfter(new Wrapper(typeof (CommitUnitOfWorkCommand)));
        }
    }
}