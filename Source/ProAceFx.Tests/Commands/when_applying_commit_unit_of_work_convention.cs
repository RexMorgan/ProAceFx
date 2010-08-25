using NUnit.Framework;
using ProAceFx.Commander;
using ProAceFx.Commander.Conventions;

namespace ProAceFx.Tests.Commands
{
    [TestFixture]
    public class when_applying_commit_unit_of_work_convention
        : CommanderConventionContext<CommitUnitOfWorkConvention, CommitUnitOfWorkCommand>
    {
    }
}