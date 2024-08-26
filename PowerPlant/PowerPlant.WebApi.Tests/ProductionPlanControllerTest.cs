using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using PowerPlant.WebApi.Models;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using FluentAssertions;

namespace PowerPlant.WebApi.Tests;

public class ProductionPlanControllerTest : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public ProductionPlanControllerTest()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [Theory]
    [InlineData("payload1.json", "response1.json")]
    [InlineData("payload2.json", "response2.json")]
    [InlineData("payload3.json", "response3.json")]
    public async Task Calculate_Production_Plan_Returns_200(string inputRequestFile, string expectedResponseFile)
    {
        // Arrange
        var request = new StringContent(
            File.ReadAllText($"Scenarios/{inputRequestFile}", Encoding.UTF8),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var expectedResponse = JsonConvert.DeserializeObject<List<ProductionPlanResponse>>(
            File.ReadAllText($"Scenarios/{expectedResponseFile}",
            Encoding.UTF8));

        // Act
        var actualResponseApi = await _client.PostAsync("/productionplan", request);
        var actualResponse = await actualResponseApi.Content.ReadFromJsonAsync<List<ProductionPlanResponse>>();

        // Assert
        actualResponseApi.StatusCode.Should().Be(HttpStatusCode.OK);
        actualResponse.Should().BeEquivalentTo(expectedResponse, options => options.WithStrictOrdering());
    }

    public void Dispose()
    {
        _factory?.Dispose();
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}