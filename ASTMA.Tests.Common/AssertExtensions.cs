using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace ASTMA.Tests.Unit.Application;

[ExcludeFromCodeCoverage]
public static class AssertExtensions
{
    public static void Equivalent<T>(T expected, T actual)
    {
        if (expected == null && actual == null) Assert.Pass("Both objects null");

        if (expected == null || actual == null) Assert.Fail("One of the objects were null");

        var expectedJson = expected.ToJson<T>();
        var actualJson = actual.ToJson<T>();
        AreJsonObjectsEquivalent(expectedJson, actualJson);
    }

    private static void AreJsonObjectsEquivalent(string expected, string actual)
    {
        var settings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.DateTime, // Parse dates as DateTime
            FloatParseHandling = FloatParseHandling.Decimal // Parse floating-point numbers as decimals
        };
        
        JToken expectedToken = JsonConvert.SerializeObject(expected, settings);
        JToken actualToken = JsonConvert.SerializeObject(actual, settings);

        if (!JToken.DeepEquals(expectedToken, actualToken)) Assert.Fail("Objects are not equivalent!");
    }
}
