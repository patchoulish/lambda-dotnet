using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud
{
	/// <summary>
	/// 
	/// </summary>
	[JsonConverter(
		typeof(JsonStringEnumConverter<LambdaCloudErrorCode>))]
	public enum LambdaCloudErrorCode
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"global/unknown")]
		Unknown,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"global/invalid-api-key")]
		InvalidApiKey,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"global/account-inactive")]
		AccountInactive,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"global/invalid-address")]
		InvalidAddress,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"global/invalid-parameters")]
		InvalidParameters,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"global/object-does-not-exist")]
		ObjectDoesNotExist,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"global/quota-exceeded")]
		QuotaExceeded,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"instance-operations/launch/insufficient-capacity")]
		InsufficientCapacity,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"instance-operations/launch/file-system-in-wrong-region")]
		FileSystemInWrongRegion,

		/// <summary>
		/// 
		/// </summary>
		[JsonStringEnumMemberName(
			"ssh-keys/key-in-use")]
		KeyInUse
	}
}
