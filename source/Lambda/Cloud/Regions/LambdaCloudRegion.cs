using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Regions
{
	/// <summary>
	/// Represents a region within Lambda Cloud.
	/// </summary>
	public class LambdaCloudRegion
	{
		/// <summary>
		/// Gets the short name for the region.
		/// </summary>
		[JsonPropertyName(
			"name")]
		public string Name { get; init; }

		/// <summary>
		/// Gets the long name for the region.
		/// </summary>
		[JsonPropertyName(
			"description")]
		public string Description { get; init; }
	}
}
