using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyApi.Tests.V1
{
    [TestFixture]
    public class HttpHeadersExtensionsTests
    {
        private const string Key = "someHeaderKey";
        private const string Value = "some value";
        private readonly Mock<IHeaderDictionary> _mockHeaders = new Mock<IHeaderDictionary>();
        delegate void SubmitCallback(string x, out StringValues y);

        [Test]
        public void GetHeaderValueThrowsNullHeaders()
        {
            Func<string> func = () => HttpHeadersExtensions.GetHeaderValue(null, Key);
            func.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void GetHeaderValueKeyNotFoundReturnsNull()
        {
            StringValues outVal;
            _mockHeaders.Setup(x => x.TryGetValue(Key, out outVal)).Returns(false);
            _mockHeaders.Object.GetHeaderValue(Key).Should().BeNull();
        }

        [Test]
        public void GetHeaderValueFounddNullKeyValue()
        {
            StringValues outVal;
            _mockHeaders.Setup(x => x.TryGetValue(Key, out outVal)).Returns(true);
            _mockHeaders.Object.GetHeaderValue(Key).Should().BeNull();
        }

        [Test]
        public void GetHeaderValueFoundEmptyKeyValue()
        {
            StringValues outVal = new StringValues("");
            _mockHeaders.Setup(x => x.TryGetValue(Key, out outVal)).Returns(true);
            _mockHeaders.Object.GetHeaderValue(Key).Should().Be(string.Empty);
        }

        [Test]
        public void GetHeaderValueFoundSingleKeyValue()
        {
            StringValues outVal;
            _mockHeaders.Setup(x => x.TryGetValue(Key, out outVal))
                .Callback(new SubmitCallback((string x, out StringValues y) => y = new StringValues(Value)))
                .Returns(true);
            _mockHeaders.Object.GetHeaderValue(Key).Should().Be(Value);
        }

        [Test]
        public void GetHeaderValueFoundManyKeyValuesReturnsFirst()
        {
            StringValues outVal;
            _mockHeaders.Setup(x => x.TryGetValue(Key, out outVal))
                .Callback(new SubmitCallback((string x, out StringValues y) => y = new StringValues(new[] { Value, "val 2", "val 3" })))
                .Returns(true);
            _mockHeaders.Object.GetHeaderValue(Key).Should().Be(Value);
        }

    }
}
