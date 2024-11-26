# lambda-dotnet [![CI](https://github.com/patchoulish/lambda-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/patchoulish/lambda-dotnet/actions/workflows/ci.yml)
A .NET library for interacting with the [Lambda](https://lambdalabs.com/) API.


## Installation
Install the library via [NuGet](https://www.nuget.org/packages/lambda-dotnet):
```bash
dotnet add package lambda-dotnet
```

### Extensions
Install optional library extensions for more functionality, depending on your use case.
#### Dependency Injection
Integrate lambda-dotnet and your DI container of choice. Install the extension library via [NuGet](https://www.nuget.org/packages/lambda-dotnet-dependencyinjection):
```bash
dotnet add package lambda-dotnet-dependencyinjection
```


## Usage
1. Obtain an API key from the [Lambda Cloud Dashboard](https://cloud.lambdalabs.com/api-keys) (requires a Lambda account).
2. Pass the API key into a new instance of the `LambdaCloudService` class or use a configured `HttpClient` if advanced configuration (e.g., proxies) is required.
3. Use the methods available on `LambdaCloudService` to interact with the Lambda Cloud API.

### Initialization
The library can be initialized in three ways:
#### Basic Initialization
Pass in your API key directly:
```csharp
var lambdaCloud = new LambdaCloudService("YOUR_LAMBDA_API_KEY");
```
#### Advanced Initialization
Use an existing `HttpClient`, ensuring that `BaseAddress` and an `Authorization` header have been set:
```csharp
var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://cloud.lambdalabs.com/api/v1/"),
    Timeout = TimeSpan.FromSeconds(5)
};

httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", "YOUR_LAMBDA_API_KEY");

var lambdaCloud = new LambdaCloudService(httpClient);
```
#### Dependency Injection
If you've installed the appropriate extension library.
1. Register `LambdaCloudService` with your dependency container:
```csharp
services.AddLambdaCloudHttpClient(options =>
{
    options.BaseUrl = new Uri("https://cloud.lambdalabs.com/api/v1/");
    options.ApiKey = "YOUR_LAMBDA_API_KEY";
});
```
2. Inject `ILambdaCloudService` where needed:
```csharp
public class MyClass
{
    private readonly ILambdaCloudService lambdaCloud;

    public MyClass(ILambdaCloudService lambdaCloud)
    {
        this.lambdaCloud = lambdaCloud;
    }
}
```
### List Instances
To list your running instances:
```csharp
var instances = await lambdaCloud.Instances.GetAllAsync();
```
To retrieve the details of an instance:
```csharp
var instanceId = ...

var instance = await lambdaCloud.Instances.GetAsync(instanceId);
```

### List Instance Types
To list the instance types offered by Lambda Cloud and explore their specs as well as their region-specific availability:
```csharp
var instanceTypeAvailabilities = lambdaCloud.Instances.GetAllTypeAvailabilityAsync();

var instanceTypesToLaunch = instanceTypeAvailabilities
    .Where(x => x.Type.Specifications.GpuCount >= 4)
	.Where(x => x.RegionsWithCapacity.Any())
	.Select(x => x.Type)
```

### Launching Instances
You can launch an instance in the following way:
```csharp
var options = new LambdaCloudInstanceLaunchOptions()
{
    RegionName = "us-east-1",
    TypeName = "gpu_1x_a100_sxm4",
    KeyNames = [
        "my-ssh-key"
    ],
    Quantity = 1
}

var instance = await lambdaCloud.Instances.LaunchAsync(options);
```

### Restarting or Terminating Instances
To restart one or more running instances:
```csharp
var instances = ...

var options = new LambdaCloudInstanceRestartOptions()
{
    Ids = [ instances[0].Id, instances[1].Id, ... ]
}

var restartedInstances = await lambdaCloud.RestartAsync(options);
```
To terminate one or more running instances:
```csharp
var instances = ...

var options = new LambdaCloudInstanceTerminateOptions()
{
    Ids = [ instances[0].Id, instances[1].Id, ... ]
}

var terminatedInstances = await lambdaCloud.TerminateAsync(options);
```

### List SSH Keys
To list the SSH keys saved in your account:
```csharp
var keys = await lambdaCloud.Keys.GetAllAsync();
```

### Adding or Generating a SSH Key
To add an existing SSH key to your account:
```csharp
var options = new LambdaCloudKeyAddOrGenerateOptions()
{
    Name = "my-existing-key",
    PublicKey = "<YOUR_PUBLIC_KEY_HERE>"
}

var key = await lambdaCloud.Keys.AddOrGenerateAsync(options);
```
To generate a new SSH key pair:
```csharp
var options =
    new LambdaCloudKeyAddOrGenerateOptions()
    {
        Name = "my-generated-key",
        PublicKey = null // Omit the public key
    }

var key = await lambdaCloud.Keys.AddOrGenerateAsync(options);

// Make sure to save the private key returned to you.
await File.WriteAllTextAsync(
    "my-generated-key.pem",
    key.PrivateKey);
```

### Deleting an SSH Key
To delete an SSH key from your account:
```csharp
var key = ...

await lambdaCloud.Keys.DeleteAsync(key.Id);
```

### Listing Filesystems
To list your persistent storage filesystems:
```csharp
var filesystems = await lambdaCloud.Filesystems.GetAllAsync();
```

## Documentation
Refer to the [Usage](#usage) section above for a quick start, or consult the inline documentation while working in your IDE.
For detailed information about the underlying API endpoints, parameters, and expected responses, refer to Lambda's [Cloud API documentation](https://docs.lambdalabs.com/public-cloud/cloud-api/) as well as their [Cloud API reference](https://cloud.lambdalabs.com/api/v1/docs).


## Contributing
Contributions are welcome! To contribute, fork the repository, create a new branch, and submit a pull request with your changes. Please make sure all tests pass before submitting.


## License
This project is licensed under the MIT license. See `license.txt` for full details.
