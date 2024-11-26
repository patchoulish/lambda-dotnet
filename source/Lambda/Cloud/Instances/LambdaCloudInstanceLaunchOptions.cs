using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;

namespace Lambda.Cloud.Instances
{
	/// <summary>
	/// 
	/// </summary>
	public class LambdaCloudInstanceLaunchOptions
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"region_name")]
		public string RegionName { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"instance_type_name")]
		public string TypeName { get; init; }

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
		[JsonPropertyName(
			"file_system_names")]
		public ImmutableArray<string>? FilesystemNames { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"quantity")]
		public int? Quantity { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"name")]
		public string? Name { get; init; }
	}
}
