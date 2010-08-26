using System.Collections.Generic;
using System.Linq;
using Commander;
using Commander.Commands;
using Commander.Registration;
using Commander.Registration.Dsl;
using Commander.Registration.Nodes;
using Commander.StructureMap;
using NUnit.Framework;

namespace ProAceFx.Tests.Commands
{
    public class CommanderConventionContext<TConvention, TCommand> : InteractionContext<TConvention>
        where TConvention : class, IConfigurationAction, new()
        where TCommand : ICommand
    {
        protected override void  BeforeEach()
        {
            CommanderFactory.Initialize(new StructureMapContainerFacility(Container), new ConventionContextCommandRegistry());
        }

        [Test]
        public void graph_is_valid_after_convention_is_applied()
        {
            var graph = CommanderFactory.Graph;

            if (should_validate_existing_chains())
            {
                graph
                    .ChainsForExisting
                    .Each(
                        chain =>
                        chain.OfType<Wrapper>().Any(wrapper => wrapper.CommandType == typeof (TCommand)).ShouldBeTrue());
            }

            if (should_validate_new_chains())
            {
                graph
                    .ChainsForNew
                    .Each(
                        chain =>
                        chain.OfType<Wrapper>().Any(wrapper => wrapper.CommandType == typeof (TCommand)).ShouldBeTrue());
            }
        }

        protected virtual bool should_validate_new_chains()
        {
            return true;
        }

        protected virtual bool should_validate_existing_chains()
        {
            return true;
        }

        #region Nested Type: ConventionContextCommandRegistry
        private class ConventionContextCommandRegistry : CommandRegistry
        {
            public ConventionContextCommandRegistry()
            {
                Applies
                    .ToThisAssembly();

                Entities
                    .IncludeType<DummyEntity>();

                ApplyConvention<TConvention>();
            }
        }
        #endregion
    }
}