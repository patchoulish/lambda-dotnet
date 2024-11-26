using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Instances
{
	/// <summary>
	/// 
	/// </summary>
	[JsonConverter(
		typeof(JsonStringEnumConverter<LambdaCloudInstanceStatus>))]
	public enum LambdaCloudInstanceStatus
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"active")]
		Active,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"booting")]
		Booting,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"unhealthy")]
		Unhealthy,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"terminating")]
		Terminating,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"terminated")]
		Terminated
	}
}
