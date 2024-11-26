using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Lambda;
using Lambda.Cloud;
using Lambda.Cloud.Regions;

namespace Lambda.Cloud.Filesystems
{
	/// <summary>
	/// 
	/// </summary>
	public class LambdaCloudFilesystem
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"id")]
		public LambdaCloudFilesystemId Id { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"name")]
		public string Name { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"created")]
		public DateTimeOffset CreatedOn { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"created_by")]
		public LambdaCloudFilesystemUser CreatedBy { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"mount_point")]
		public string MountPath { get; init; }

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
			"is_in_use")]
		public bool IsMounted { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"bytes_used")]
		public ulong SizeInBytes {  get; init; }
	}
}
