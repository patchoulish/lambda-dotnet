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
	public class LambdaCloudInstanceTerminateOptions
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"instance_ids")]
		public ImmutableArray<LambdaCloudInstanceId> Ids { get; init; }
	}
}
