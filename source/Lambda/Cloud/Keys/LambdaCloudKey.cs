using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lambda.Cloud.Keys
{
	/// <summary>
	/// Represents an SSH key pair on Lambda Cloud.
	/// </summary>
	public class LambdaCloudKey
	{
		/// <summary>
		/// Gets the unique identifier for the SSH key pair.
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"id")]
		public LambdaCloudKeyId Id { get; init; }

		/// <summary>
		/// Gets the name for the SSH key pair.
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"name")]
		public string Name { get; init; }

		/// <summary>
		/// Gets the public key for the SSH key pair.
		/// </summary>
		[JsonRequired]
		[JsonPropertyName(
			"public_key")]
		public string PublicKey { get; init; }

		/// <summary>
		/// Gets the private key for the SSH key pair.
		/// </summary>
		/// <remarks>
		/// Only populated when generating a new key pair.
		/// </remarks>
		[JsonPropertyName(
			"private_key")]
		public string PrivateKey { get; init; }
	}
}
