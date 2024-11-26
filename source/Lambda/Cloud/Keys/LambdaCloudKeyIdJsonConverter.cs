using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Keys
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class LambdaCloudKeyIdJsonConverter :
		JsonConverter<LambdaCloudKeyId>
	{
		/// <inheritdoc/>
		public override LambdaCloudKeyId Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options) =>
				new LambdaCloudKeyId(
					Guid.Parse(
						reader.GetString()));

		/// <inheritdoc/>
		public override void Write(
			Utf8JsonWriter writer,
			LambdaCloudKeyId value,
			JsonSerializerOptions options) =>
				writer.WriteStringValue(
					value.Value.ToString("N"));
	}
}
