using Microsoft.Azure.Functions.Worker.Context.Features;
using Microsoft.Azure.Functions.Worker.Core.FunctionMetadata;
using Microsoft.Azure.Functions.Worker.Invocation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Net8AOTFunctionApp;
using System.Collections.Immutable;

namespace Microsoft.Azure.Functions.Worker
{
    public class GeneratedFunctionMetadataProvider2 : IFunctionMetadataProvider
    {
        ILogger<GeneratedFunctionMetadataProvider2> logger;
        public GeneratedFunctionMetadataProvider2(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<GeneratedFunctionMetadataProvider2>();
        }

        public Task<ImmutableArray<IFunctionMetadata>> GetFunctionMetadataAsync(string directory)
        {
            logger.LogInformation("GeneratedFunctionMetadataProvider2 GetFunctionMetadataAsync invoked");

            var metadataList = new List<IFunctionMetadata>();
            var Function0RawBindings = new List<string>();
            Function0RawBindings.Add(@"{""name"":""req"",""type"":""HttpTrigger"",""direction"":""In"",""authLevel"":""Anonymous"",""methods"":[""get"",""post""]}");
            Function0RawBindings.Add(@"{""name"":""$return"",""type"":""http"",""direction"":""Out""}");

            var Function0 = new DefaultFunctionMetadata
            {
                Language = "dotnet-isolated",
                Name = "Function1",
                EntryPoint = "Net8AOTFunctionApp.Function1.Run",
                RawBindings = Function0RawBindings,
                ScriptFile = "Net8AOTFunctionApp.dll"
            };
            metadataList.Add(Function0);

            return Task.FromResult(metadataList.ToImmutableArray());
        }
    }

    internal class DirectFunctionExecutor : IFunctionExecutor
    {
        private readonly IFunctionActivator _functionActivator;
        private readonly Dictionary<string, Type> types = new()
        {
            { "Net8AOTFunctionApp.Function1", Type.GetType("Net8AOTFunctionApp.Function1")! },
        };

        public DirectFunctionExecutor(IFunctionActivator functionActivator)
        {
            _functionActivator = functionActivator ?? throw new ArgumentNullException(nameof(functionActivator));
        }

        public async ValueTask ExecuteAsync(FunctionContext context)
        {
            var inputBindingFeature = context.Features.Get<IFunctionInputBindingFeature>()!;
            var inputBindingResult = await inputBindingFeature.BindFunctionInputAsync(context)!;
            var inputArguments = inputBindingResult.Values;

            if (string.Equals(context.FunctionDefinition.EntryPoint, "Net8AOTFunctionApp.Function1.Run", StringComparison.OrdinalIgnoreCase))
            {
                var instanceType = types["Net8AOTFunctionApp.Function1"];
                //var i2 = _functionActivator.CreateInstance(instanceType, context) as Net8AOTApp.Function1;
                var ilogger = context.InstanceServices.GetService<ILogger<Function1>>();
                var i = new Net8AOTFunctionApp.Function1(ilogger);
                context.GetInvocationResult().Value = i.Run((Http.HttpRequestData)inputArguments[0]!);
            }
        }
    }
    public static class FunctionExecutorHostBuilderExtensions
    {
        ///<summary>
        /// Configures an optimized function executor to the invocation pipeline.
        ///</summary>
        public static IHostBuilder ConfigureGeneratedFunctionExecutor(this IHostBuilder builder)
        {
            return builder.ConfigureServices(s =>
            {
                s.AddSingleton<IFunctionExecutor, DirectFunctionExecutor>();
            });
        }
    }
}
