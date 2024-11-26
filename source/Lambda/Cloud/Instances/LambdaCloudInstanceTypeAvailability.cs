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
	public class LambdaCloudInstanceTypeAvailability
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"instance_type")]
		public LambdaCloudInstanceType Type { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"regions_with_capacity_available")]
		public ImmutableArray<LambdaCloudRegion> RegionsWithCapacity { get; init; }
	}
}
