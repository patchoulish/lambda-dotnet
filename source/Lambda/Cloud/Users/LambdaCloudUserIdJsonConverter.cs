using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Users
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class LambdaCloudUserIdJsonConverter :
		JsonConverter<LambdaCloudUserId>
	{
		/// <inheritdoc/>
		public override LambdaCloudUserId Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options) =>
				new LambdaCloudUserId(
					reader.GetGuid());

		/// <inheritdoc/>
		public override void Write(
			Utf8JsonWriter writer,
			LambdaCloudUserId value,
			JsonSerializerOptions options) =>
				writer.WriteStringValue(
					value.Value.ToString("N"));
	}
}
