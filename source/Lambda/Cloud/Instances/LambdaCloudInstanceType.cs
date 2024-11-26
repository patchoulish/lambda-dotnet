using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Instances
{
	/// <summary>
	/// 
	/// </summary>
	public class LambdaCloudInstanceType
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"name")]
		public string Name { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"description")]
		public string Description { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"gpu_description")]
		public string GpuDescription { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"price_cents_per_hour")]
		public int PricePerHourInCents { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"specs")]
		public LambdaCloudInstanceTypeSpecifications Specifications { get; init; }
	}
}
