using NUnit.Framework;
using ProAceFx.Commander;
using ProAceFx.Commander.Conventions;

namespace ProAceFx.Tests.Commands
{
    [TestFixture]
    public class when_applying_update_existing_entities_convention
        : CommanderConventionContext<UpdateExistingEntitiesConvention, UpdateEntityCommand<DummyEntity>>
    {
        protected override bool should_validate_new_chains()
        {
            return false;
        }
    }
}