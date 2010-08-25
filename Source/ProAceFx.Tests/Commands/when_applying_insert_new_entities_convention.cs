using NUnit.Framework;
using ProAceFx.Commander;
using ProAceFx.Commander.Conventions;

namespace ProAceFx.Tests.Commands
{
    [TestFixture]
    public class when_applying_insert_new_entities_convention
        : CommanderConventionContext<InsertNewEntitiesConvention, InsertEntityCommand<DummyEntity>>
    {
        protected override bool should_validate_existing_chains()
        {
            return false;
        }
    }
}