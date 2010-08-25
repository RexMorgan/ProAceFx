using NUnit.Framework;
using ProAceFx.Commander;
using ProAceFx.Commander.Conventions;

namespace ProAceFx.Tests.Commands
{
    [TestFixture]
    public class when_applying_initialize_unit_of_work_convention 
        : CommanderConventionContext<InitializeUnitOfWorkConvention, InitializeUnitOfWorkCommand>
    {
    }
}