using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;

using Lambda;
using Lambda.Cloud;
using Lambda.Cloud.Regions;

namespace Lambda.Cloud.Instances
{
	/// <summary>
	/// 
	/// </summary>
	public class LambdaCloudInstance
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"id")]
		public LambdaCloudInstanceId Id { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"name")]
		public string? Name { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"ip")]
		public string? IPAddress { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"private_ip")]
		public string? PrivateIPAddress { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"status")]
		public LambdaCloudInstanceStatus Status { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"ssh_key_names")]
		public ImmutableArray<string> KeyNames { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"file_system_names")]
		public ImmutableArray<string> FilesystemNames { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"region")]
		public LambdaCloudRegion Region { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"instance_type")]
		public LambdaCloudInstanceType Type { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"hostname")]
		public string? Host { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"jupyter_token")]
		public string? JupyterToken { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"jupyter_url")]
		public Uri? JupyterUrl { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"is_reserved")]
		public bool IsReserved { get; init; }
	}
}
