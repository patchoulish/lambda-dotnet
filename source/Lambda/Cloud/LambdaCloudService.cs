using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Immutable;

using Lambda;
using Lambda.Cloud;
using Lambda.Cloud.Keys;
using Lambda.Cloud.Instances;
using Lambda.Cloud.Filesystems;

namespace Lambda.Cloud
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class LambdaCloudService :
		ILambdaCloudFilesystemService,
		ILambdaCloudInstanceService,
		ILambdaCloudKeyService,
		ILambdaCloudService
	{
		/// <summary>
		/// Gets the default base URL for the Lambda Cloud API.
		/// </summary>
		public static Uri DefaultBaseUrl { get; } =
			new Uri(
				"https://cloud.lambdalabs.com/api/v1/");

		/// <summary>
		/// The JSON serializer options for serializing and deserializing JSON data.
		/// </summary>
		internal static JsonSerializerOptions JsonSerializerOptions { get; } =
			new JsonSerializerOptions()
			{
				DefaultIgnoreCondition =
					JsonIgnoreCondition.WhenWritingNull
			};

		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="apiKey"></param>
		/// <returns></returns>
		private static HttpClient CreateHttpClient(
			Uri baseUrl,
			string apiKey)
		{
			Guard.NotNull(
				baseUrl,
				nameof(baseUrl));

			Guard.NotNullOrEmpty(
				apiKey,
				nameof(apiKey));

			var httpClient =
				new HttpClient(
					new LambdaCloudDelegatingHandler()
					{
						InnerHandler = new HttpClientHandler()
					},
					disposeHandler: true);

			httpClient.BaseAddress =
				baseUrl;

			httpClient.DefaultRequestHeaders.Add(
				$"Authorization",
				$"Bearer {apiKey}");

			return httpClient;
		}

		private readonly HttpClient httpClient;

		/// <inheritdoc/>
		public ILambdaCloudKeyService Keys =>
			this;

		/// <inheritdoc/>
		public ILambdaCloudInstanceService Instances =>
			this;

		/// <inheritdoc/>
		public ILambdaCloudFilesystemService Filesystems =>
			this;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="apiKey"></param>
		public LambdaCloudService(
			string apiKey) :
				this(
					DefaultBaseUrl,
					apiKey)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="apiKey"></param>
		public LambdaCloudService(
			Uri baseUrl,
			string apiKey) :
				this(
					CreateHttpClient(
						baseUrl,
						apiKey))
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpClient"></param>
		public LambdaCloudService(
			HttpClient httpClient)
		{
			Guard.NotNull(
				httpClient,
				nameof(httpClient));

			this.httpClient = httpClient;
		}

		/// <inheritdoc/>
		async Task<ImmutableArray<LambdaCloudKey>> ILambdaCloudKeyService.GetAllAsync(
			CancellationToken cancellationToken)
		{
			var result =
				await this.httpClient
					.GetFromJsonAsync<LambdaCloudResult>(
						$"ssh-keys",
						JsonSerializerOptions,
						cancellationToken);

			return result.Data
				.Deserialize<LambdaCloudKey[]>(
					JsonSerializerOptions)
				.ToImmutableArray();
		}

		/// <inheritdoc/>
		async Task<LambdaCloudKey> ILambdaCloudKeyService.AddOrGenerateAsync(
			LambdaCloudKeyAddOrGenerateOptions options,
			CancellationToken cancellationToken)
		{
			Guard.NotNull(
				options,
				nameof(options));

			var httpResponseMessage =
				await this.httpClient
					.PostAsJsonAsync(
						$"ssh-keys",
						options,
						JsonSerializerOptions,
						cancellationToken);

			var result =
				await httpResponseMessage.Content
					.ReadFromJsonAsync<LambdaCloudResult>(
						JsonSerializerOptions,
						cancellationToken);

			return result.Data
				.Deserialize<LambdaCloudKey>(
					JsonSerializerOptions);
		}

		/// <inheritdoc/>
		async Task ILambdaCloudKeyService.DeleteAsync(
			LambdaCloudKeyId id,
			CancellationToken cancellationToken)
		{
			await this.httpClient
				.DeleteAsync(
					$"ssh-keys/{id.Value.ToString("N")}");
		}

		/// <inheritdoc/>
		async Task<ImmutableArray<LambdaCloudInstanceTypeAvailability>> ILambdaCloudInstanceService.GetAllTypeAvailabilityAsync(
			CancellationToken cancellationToken)
		{
			var result =
				await this.httpClient
					.GetFromJsonAsync<LambdaCloudResult>(
						$"instance-types",
						JsonSerializerOptions,
						cancellationToken);

			return result.Data
				.Deserialize<ImmutableDictionary<string, LambdaCloudInstanceTypeAvailability>>(
					JsonSerializerOptions)
				.Values
				.ToImmutableArray();
		}

		/// <inheritdoc/>
		async Task<ImmutableArray<LambdaCloudInstance>> ILambdaCloudInstanceService.GetAllAsync(
			CancellationToken cancellationToken)
		{
			var result =
				await this.httpClient
					.GetFromJsonAsync<LambdaCloudResult>(
						$"instances",
						JsonSerializerOptions,
						cancellationToken);

			return result.Data
				.Deserialize<LambdaCloudInstance[]>(
					JsonSerializerOptions)
				.ToImmutableArray();
		}

		/// <inheritdoc/>
		async Task<LambdaCloudInstance> ILambdaCloudInstanceService.GetAsync(
			LambdaCloudInstanceId id,
			CancellationToken cancellationToken)
		{
			var result =
				await this.httpClient
					.GetFromJsonAsync<LambdaCloudResult>(
						$"instances/{id.Value.ToString("N")}",
						JsonSerializerOptions,
						cancellationToken);

			return result.Data
				.Deserialize<LambdaCloudInstance>(
					JsonSerializerOptions);
		}

		/// <inheritdoc/>
		async Task<ImmutableArray<LambdaCloudInstanceId>> ILambdaCloudInstanceService.LaunchAsync(
			LambdaCloudInstanceLaunchOptions options,
			CancellationToken cancellationToken)
		{
			Guard.NotNull(
				options,
				nameof(options));

			var httpResponseMessage =
				await this.httpClient
					.PostAsJsonAsync(
						$"instance-operations/launch",
						options,
						JsonSerializerOptions,
						cancellationToken);

			var result =
				await httpResponseMessage.Content
					.ReadFromJsonAsync<LambdaCloudResult>(
						JsonSerializerOptions,
						cancellationToken);

			return result.Data
				.GetProperty(
					"instance_ids")
				.Deserialize<LambdaCloudInstanceId[]>(
					JsonSerializerOptions)
				.ToImmutableArray();
		}

		/// <inheritdoc/>
		async Task<ImmutableArray<LambdaCloudInstance>> ILambdaCloudInstanceService.RestartAsync(
			LambdaCloudInstanceRestartOptions options,
			CancellationToken cancellationToken)
		{
			Guard.NotNull(
				options,
				nameof(options));

			var httpResponseMessage =
				await this.httpClient
					.PostAsJsonAsync(
						$"instance-operations/restart",
						options,
						JsonSerializerOptions,
						cancellationToken);

			var result =
				await httpResponseMessage.Content
					.ReadFromJsonAsync<LambdaCloudResult>(
						JsonSerializerOptions,
						cancellationToken);

			return result.Data
				.GetProperty(
					"restarted_instances")
				.Deserialize<LambdaCloudInstance[]>(
					JsonSerializerOptions)
				.ToImmutableArray();
		}

		/// <inheritdoc/>
		async Task<ImmutableArray<LambdaCloudInstance>> ILambdaCloudInstanceService.TerminateAsync(
			LambdaCloudInstanceTerminateOptions options,
			CancellationToken cancellationToken)
		{
			Guard.NotNull(
				options,
				nameof(options));

			var httpResponseMessage =
				await this.httpClient
					.PostAsJsonAsync(
						$"instance-operations/terminate",
						options,
						JsonSerializerOptions,
						cancellationToken);

			var result =
				await httpResponseMessage.Content
					.ReadFromJsonAsync<LambdaCloudResult>(
						JsonSerializerOptions,
						cancellationToken);

			return result.Data
				.GetProperty(
					"terminated_instances")
				.Deserialize<LambdaCloudInstance[]>(
					JsonSerializerOptions)
				.ToImmutableArray();
		}

		/// <inheritdoc/>
		async Task<ImmutableArray<LambdaCloudFilesystem>> ILambdaCloudFilesystemService.GetAllAsync(
			CancellationToken cancellationToken)
		{
			var result =
				await this.httpClient
					.GetFromJsonAsync<LambdaCloudResult>(
						$"file-systems",
						JsonSerializerOptions,
						cancellationToken);

			return result.Data
				.Deserialize<LambdaCloudFilesystem[]>(
					JsonSerializerOptions)
				.ToImmutableArray();
		}
	}
}
