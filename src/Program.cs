using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using static FunctionsSnippetTool.ToolsInformation;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// 1.0.0 API changes:
// - EnableMcpToolMetadata() has been removed and is no longer needed
//   https://github.com/Azure/azure-functions-mcp-extension/releases/tag/1.0.0
// - Changes to MCP property metadata registration
//   https://github.com/Azure/azure-functions-mcp-extension/pull/102
// builder.EnableMcpToolMetadata();

// ConfigureMcpTool().WithProperty() is still available in 1.0.0, but it's no longer necessary
// because properties can be defined directly using the [McpToolProperty] attribute in the function.
// This approach is now preferred and used in src/SnippetsTool.cs.
// See: https://github.com/Azure/azure-functions-mcp-extension/blob/cb25104788982e7ee31f537e5fcdb5c6e6f20595/src/Microsoft.Azure.Functions.Worker.Extensions.Mcp/DependencyInjection/McpToolBuilder.cs#L11
//
// Example of programmatic property definition (not used in this project):
// builder
//     .ConfigureMcpTool(GetSnippetToolName)
//     .WithProperty(SnippetNamePropertyName, PropertyType, SnippetNamePropertyDescription, required: true);

builder.Build().Run();
