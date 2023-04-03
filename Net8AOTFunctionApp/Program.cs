using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Core.FunctionMetadata;
using Microsoft.Azure.Functions.Worker.Invocation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
   // .ConfigureGeneratedFunctionMetadataProvider()
    .ConfigureGeneratedFunctionExecutor()
    .ConfigureServices(s=>
    {
        s.AddSingleton<IFunctionMetadataProvider, GeneratedFunctionMetadataProvider2>();
    })
    .Build();

host.Run();
