using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Keys
{
	/// <summary>
	/// Represents the options for a request to add a new SSH key pair on Lambda Cloud.
	/// </summary>
	public class LambdaCloudKeyAddOrGenerateOptions
	{
		/// <summary>
		/// Gets or sets the name for the SSH key pair.
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"name")]
		public string Name { get; init; }

		/// <summary>
		/// Gets or sets the public key for the SSH key pair, if any.
		/// </summary>
		/// <remarks>
		/// To generate a new key pair, leave this property <b>null</b>.
		/// Save the private key from the resulting SSH key pair somewhere secure.
		/// </remarks>
		[JsonPropertyName(
			"public_key")]
		public string PublicKey { get; init; }
	}
}
