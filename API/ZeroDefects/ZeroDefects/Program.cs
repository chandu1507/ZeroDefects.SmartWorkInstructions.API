using ZeroDefects.API;

await WebApplication
    .CreateBuilder(args)
    .ConfigureServices()
    .Build()
    .Configure()
    .RunAsync();