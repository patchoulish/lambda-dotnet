using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Instances
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class LambdaCloudInstanceIdJsonConverter :
		JsonConverter<LambdaCloudInstanceId>
	{
		/// <inheritdoc/>
		public override LambdaCloudInstanceId Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options) =>
				new LambdaCloudInstanceId(
					Guid.Parse(
						reader.GetString()));

		/// <inheritdoc/>
		public override void Write(
			Utf8JsonWriter writer,
			LambdaCloudInstanceId value,
			JsonSerializerOptions options) =>
				writer.WriteStringValue(
					value.Value.ToString("N"));
	}
}
