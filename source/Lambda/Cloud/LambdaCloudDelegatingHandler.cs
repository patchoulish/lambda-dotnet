using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Lambda.Cloud
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class LambdaCloudDelegatingHandler :
		DelegatingHandler
	{
		/// <summary>
		/// 
		/// </summary>
		public LambdaCloudDelegatingHandler() :
			base()
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		protected override async Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			var httpClientResponse =
				default(HttpResponseMessage);

			try
			{
				httpClientResponse =
					await base.SendAsync(
						request,
						cancellationToken);
			}
			catch (Exception ex)
			{
				throw new LambdaCloudException(
					"The operation was not successful.",
					ex);
			}

			if (httpClientResponse.StatusCode != HttpStatusCode.OK)
			{
				var result =
					await httpClientResponse.Content
						.ReadFromJsonAsync<LambdaCloudResult>(
							LambdaCloudService.JsonSerializerOptions,
							cancellationToken);

				throw new LambdaCloudException(
					"The operation was not successful.",
					default,
					httpClientResponse.StatusCode,
					result.Error);
			}

			return httpClientResponse;
		}
	}
}
