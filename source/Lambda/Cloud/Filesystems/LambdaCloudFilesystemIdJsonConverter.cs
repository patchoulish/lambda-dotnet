using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Filesystems
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class LambdaCloudFilesystemIdJsonConverter :
		JsonConverter<LambdaCloudFilesystemId>
	{
		/// <inheritdoc/>
		public override LambdaCloudFilesystemId Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options) =>
				new LambdaCloudFilesystemId(
					reader.GetGuid());

		/// <inheritdoc/>
		public override void Write(
			Utf8JsonWriter writer,
			LambdaCloudFilesystemId value,
			JsonSerializerOptions options) =>
				writer.WriteStringValue(
					value.Value.ToString("N"));
	}
}
