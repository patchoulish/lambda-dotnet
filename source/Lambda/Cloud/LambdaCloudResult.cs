using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace Lambda.Cloud
{
	/// <summary>
	/// 
	/// </summary>
	internal sealed class LambdaCloudResult
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"data")]
		public JsonElement Data { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"error")]
		public LambdaCloudError Error { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"field_errors")]
		public IDictionary<string, LambdaCloudError> PerPropertyErrors { get; init; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsSuccessful =>
			(Error == default) &&
			(PerPropertyErrors?.Count ?? 0) == 0;
	}
}
