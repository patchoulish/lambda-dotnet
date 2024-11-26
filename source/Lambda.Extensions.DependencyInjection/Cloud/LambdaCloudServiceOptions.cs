using System;

using Microsoft;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lambda.Cloud
{
	/// <summary>
	/// Represents the options when registering an instance of the <see cref="LambdaCloudService"/>
	/// class with an <see cref="IServiceCollection"/>.
	/// </summary>
	public sealed class LambdaCloudServiceOptions
	{
		/// <summary>
		/// Gets or sets the base URL to use.
		/// </summary>
		public Uri BaseUrl { get; set; } =
			LambdaCloudService.DefaultBaseUrl;

		/// <summary>
		/// Gets or sets the API key to use.
		/// </summary>
		public string ApiKey { get; set; }
	}
}
