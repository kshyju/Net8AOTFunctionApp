using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureGeneratedFunctionMetadataProvider()
    .ConfigureGeneratedFunctionExecutor()
    .Build();

host.Run();
