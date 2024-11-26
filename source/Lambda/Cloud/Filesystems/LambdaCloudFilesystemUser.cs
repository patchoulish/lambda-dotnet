using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Lambda;
using Lambda.Cloud;
using Lambda.Cloud.Users;

namespace Lambda.Cloud.Filesystems
{
	/// <summary>
	/// 
	/// </summary>
	public class LambdaCloudFilesystemUser
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"id")]
		public LambdaCloudUserId Id { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"email")]
		public string EmailAddress { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"status")]
		public LambdaCloudUserStatus Status { get; init; }
	}
}
