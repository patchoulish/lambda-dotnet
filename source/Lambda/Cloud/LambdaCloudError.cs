using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud
{
	/// <summary>
	/// 
	/// </summary>
	public class LambdaCloudError
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"code")]
		public LambdaCloudErrorCode Code { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"message")]
		public string Message { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"suggestion")]
		public string? Suggestion { get; init; }
	}
}
