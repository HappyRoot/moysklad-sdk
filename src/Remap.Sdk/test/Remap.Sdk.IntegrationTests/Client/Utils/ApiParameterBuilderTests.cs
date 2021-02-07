using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Client
{
    internal class TestMetaEntity
    {
        [Filter]
        [AllowOrder]
        [Parameter("stringproperty")]
        public string StringProperty { get; set; }

        [Filter]
        [AllowOrder]
        [Parameter("intproperty")]
        public int IntProperty { get; set; }

        [Filter]
        [Parameter("datetimeproperty")]
        public DateTime DateTimeProperty { get; set; }

        [Filter]
        [Parameter("booleanproperty")]
        public bool BooleanProperty { get; set; }

        [AllowExpand]
        [Parameter("nestedmetaentity")]
        public NestedMetaEntity NestedEntity { get; set; }

        [Filter]
        public int? NullableIntPropertyParameterName { get; set; }

        public class NestedMetaEntity
        {
            [Filter]
            [Parameter("stringproperty")]
            public string StringProperty { get; set; }

            [AllowExpand]
            public NestedMetaEntity2 NestedEntity2 { get; set; }

            public class NestedMetaEntity2
            {
                
            }
        }
    }

    public class ApiParameterBuilderTests
    {
        private ApiParameterBuilder<TestMetaEntity> _subject;

        [SetUp]
        public void Init()
        {
            _subject = new ApiParameterBuilder<TestMetaEntity>();
        }

        [Test]
        public void Build_should_return_empty_dictionary()
        {
            _subject.Build().Should().BeEmpty();
        }

        [Test]
        public void Build_should_return_dictionary_with_filters_expanders_orders_and_search_parameters()
        {
            var d1 = DateTime.Now;
            var d2 = DateTime.Now.AddHours(1);
            _subject.Parameter(p => p.StringProperty).Should().Be("test");
            _subject.Parameter(p => p.DateTimeProperty).Should().BeLessThan(d1, "yyyy-MM-dd_HH:mm:ss").And.BeGreaterOrEqualTo(d2, "yyyy-MM-dd_HH:mm:ss");
            _subject.Parameter(p => p.BooleanProperty).Should().Be(true);
            _subject.Parameter(p => p.IntProperty).Should().Be(5).Or.Be(10);
            _subject.Parameter(p => p.NullableIntPropertyParameterName).Should().BeNull();
            _subject.Parameter("customParameter").Should().BeGreaterThan("5");

            _subject.Expand().With(p => p.NestedEntity.NestedEntity2);

            _subject.Order().By(p => p.StringProperty).And.By(p => p.IntProperty, OrderBy.Desc);

            _subject.Search("query");

            _subject.Limit(100);

            _subject.Offset(50);

            var result = _subject.Build();
            
            result.Should().HaveCount(6);
            result["filter"].Should().Be(
                $@"
                    stringproperty=test;
                    datetimeproperty<{d1.ToString("yyyy-MM-dd_HH:mm:ss")};
                    datetimeproperty>={d2.ToString("yyyy-MM-dd_HH:mm:ss")};
                    booleanproperty=true;
                    intproperty=5;
                    intproperty=10;
                    NullableIntPropertyParameterName=;
                    customParameter>5
                ".Replace("\n", "").Replace(" ", ""));
            result["expand"].Should().Be("nestedmetaentity.NestedEntity2");
            result["order"].Should().Be("stringproperty,asc;intproperty,desc");
            result["search"].Should().Be("query");
            result["limit"].Should().Be("100");
            result["offset"].Should().Be("50");
        }

        [Test]
        public void Parameter_should_throw_api_exception_if_nesting_property_level_is_more_than_one()
        {
            Action action = () => _subject.Parameter(p => p.NestedEntity.StringProperty);
            action.Should().Throw<ApiException>();
        }

        [Test]
        public void Limit_with_invalid_range_should_throw_api_exception()
        {
            var limits = new Action[]
            {
                () => _subject.Limit(0),
                () => _subject.Limit(1001)
            };

            foreach (var limit in limits)
                limit.Should().Throw<ApiException>();
        }

        [Test]
        public void Offset_with_invalid_value_should_throw_api_exception()
        {
            Action offset = () => _subject.Offset(-1);
            offset.Should().Throw<ApiException>();
        }
    }
}