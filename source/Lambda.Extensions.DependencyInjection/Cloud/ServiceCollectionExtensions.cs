using System;
using System.Net;
using System.Net.Http;

using Microsoft;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lambda.Cloud
{
	/// <summary>
	/// Contains extension methods for
	/// <see cref="IServiceCollection"/>.
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// The name to use for the named client.
		/// </summary>
		private const string LambdaCloudHttpClientName =
			"lambda-cloud";

		/// <summary>
		/// Registers an instance of the <see cref="LambdaCloudService"/>
		/// class with an <see cref="IServiceCollection"/>
		/// using a named <see cref="HttpClient"/>.
		/// </summary>
		/// <param name="services">The service collection to register with.</param>
		/// <param name="optionsCallback">The callback to configure the options for the instance with.</param>
		/// <returns>An <see cref="IHttpClientBuilder"/> that can be used to configure the named client.</returns>
		public static IHttpClientBuilder AddLambdaCloudHttpClient(
			this IServiceCollection services,
			Action<LambdaCloudServiceOptions> optionsCallback = default)
		{
			Guard.NotNull(
				services,
				nameof(services));

			var options =
				new LambdaCloudServiceOptions();

			optionsCallback?
				.Invoke(
					options);

			return services
				.AddTransient<LambdaCloudDelegatingHandler>()
				.AddHttpClient<ILambdaCloudService, LambdaCloudService>(
					LambdaCloudHttpClientName,
					(httpClient) =>
					{
						// Configure the base URL for the client.
						httpClient.BaseAddress =
							options.BaseUrl;

						// Configure the default request headers for the client.
						httpClient.DefaultRequestHeaders.Add(
							$"Authorization",
							$"Bearer {options.ApiKey}");
					})
				.AddHttpMessageHandler<LambdaCloudDelegatingHandler>();
		}
	}
}
