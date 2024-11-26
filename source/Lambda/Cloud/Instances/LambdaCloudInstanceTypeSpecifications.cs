using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Instances
{
	/// <summary>
	/// 
	/// </summary>
	public class LambdaCloudInstanceTypeSpecifications
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"vcpus")]
		public int VirtualCpuCount { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"memory_gib")]
		public int MemoryInGibibytes { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"storage_gib")]
		public int StorageInGibibytes { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"gpus")]
		public int GpuCount { get; init; }
	}
}
