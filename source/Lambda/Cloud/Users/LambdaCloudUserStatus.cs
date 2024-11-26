using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Users
{
	/// <summary>
	/// 
	/// </summary>
	[JsonConverter(
		typeof(JsonStringEnumConverter<LambdaCloudUserStatus>))]
	public enum LambdaCloudUserStatus
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
			"deactivated")]
		Deactivated
	}
}
