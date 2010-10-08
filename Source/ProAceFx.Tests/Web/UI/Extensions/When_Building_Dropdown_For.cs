using System.Collections.Generic;
using FubuMVC.Core.View;
using NUnit.Framework;
using ProAceFx.Core.Web.UI.Extensions;
using ProAceFx.Tests.Web.Models;

namespace ProAceFx.Tests.Web.UI.Extensions
{
    [TestFixture]
    public class When_Building_Dropdown_For
    {
        [Test]
        public void FubuPage_With_No_Model_And_No_Default()
        {
            var page = new FubuPage();
            var options = new Dictionary<int, string> {{1, "Test"}, {2, "Another"}};

            var result = page.DropDownFor<FakeInputModel>(m => m.FakeId, options, false);

            result.ShouldNotBeNull();
            result.Id().ShouldEqual("FakeId");
            result.Children.ShouldHaveCount(2);
            result.Children.ShouldNotHaveAny(i => i.HasAttr("selected") && i.Attr("selected") == "selected");
        }

        [Test]
        public void FubuPage_With_No_Model_And_Default()
        {
            var page = new FubuPage();
            var options = new Dictionary<int, string> { { 1, "Test" }, { 2, "Another" } };

            var result = page.DropDownFor<FakeInputModel>(m => m.FakeId, options, true);

            result.ShouldNotBeNull();
            result.Id().ShouldEqual("FakeId");
            result.Children.ShouldHaveCount(3);
            result.Children.ShouldHaveOne(i => i.HasAttr("selected") && i.Attr("selected") == "selected");
        }

        [Test]
        public void FubuPage_With_Model_And_No_Default()
        {
            var page = new FubuPage();
            var options = new Dictionary<int, string> { { 1, "Test" }, { 2, "Another" } };
            var inputModel = new FakeInputModel { FakeId = 1 };

            var result = page.DropDownFor(inputModel, m => m.FakeId, options, false);

            result.ShouldNotBeNull();
            result.Id().ShouldEqual("FakeId");
            result.Children.ShouldHaveCount(2);
            result.Children.ShouldHaveOne(i => i.HasAttr("selected") && i.Attr("selected") == "selected");
        }

        [Test]
        public void FubuPage_With_Model_And_Default()
        {
            var page = new FubuPage();
            var options = new Dictionary<int, string> { { 1, "Test" }, { 2, "Another" } };
            var inputModel = new FakeInputModel { FakeId = 1 };

            var result = page.DropDownFor(inputModel, m => m.FakeId, options, true);

            result.ShouldNotBeNull();
            result.Id().ShouldEqual("FakeId");
            result.Children.ShouldHaveCount(3);
            result.Children.ShouldHaveOne(i => i.HasAttr("selected") && i.Attr("selected") == "selected");
        }

        [Test]
        public void Typed_FubuPage_With_Model_And_No_Default()
        {
            var inputModel = new FakeInputModel { FakeId = 2 };
            var page = new FubuPage<FakeInputModel>();
            page.SetModel(inputModel);
            var options = new Dictionary<int, string> { { 1, "Test" }, { 2, "Another" } };

            var result = page.DropDownFor(m => m.FakeId, options, false);

            result.ShouldNotBeNull();
            result.Id().ShouldEqual("FakeId");
            result.Children.ShouldHaveCount(2);
            result.Children.ShouldHaveOne(i => i.HasAttr("selected") && i.Attr("selected") == "selected");
        }

        [Test]
        public void Typed_FubuPage_With_Model_And_Default()
        {
            var inputModel = new FakeInputModel { FakeId = 2 };
            var page = new FubuPage<FakeInputModel>();
            page.SetModel(inputModel);
            var options = new Dictionary<int, string> { { 1, "Test" }, { 2, "Another" } };

            var result = page.DropDownFor(m => m.FakeId, options, true);

            result.ShouldNotBeNull();
            result.Id().ShouldEqual("FakeId");
            result.Children.ShouldHaveCount(3);
            result.Children.ShouldHaveOne(i => i.HasAttr("selected") && i.Attr("selected") == "selected");
        }
    }
}