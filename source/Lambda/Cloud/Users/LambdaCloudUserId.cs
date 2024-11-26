using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime;
using System.Runtime.CompilerServices;

namespace Lambda.Cloud.Users
{
	/// <summary>
	/// 
	/// </summary>
	[JsonConverter(
		typeof(LambdaCloudUserIdJsonConverter))]
	public readonly struct LambdaCloudUserId :
		IEquatable<LambdaCloudUserId>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueA"></param>
		/// <param name="valueB"></param>
		/// <returns></returns>
		public static bool Equals(
			LambdaCloudUserId valueA,
			LambdaCloudUserId valueB)
		{
			return (valueA.value == valueB.value);
		}

		private readonly Guid value;

		/// <summary>
		/// 
		/// </summary>
		public Guid Value =>
			this.value;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		public LambdaCloudUserId(
			Guid value)
		{
			this.value = value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(
			LambdaCloudUserId other) =>
				Equals(
					this,
					other);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(
			object obj)
		{
			if (obj is LambdaCloudUserId other)
			{
				return Equals(
					this,
					other);
			}

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() =>
			this.value.GetHashCode();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString() =>
			this.value.ToString();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		[MethodImpl(
			MethodImplOptions.AggressiveInlining)]
		public static implicit operator Guid(
			LambdaCloudUserId value) =>
				value.Value;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueLeft"></param>
		/// <param name="valueRight"></param>
		/// <returns></returns>
		[MethodImpl(
			MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(
			LambdaCloudUserId valueLeft,
			LambdaCloudUserId valueRight) =>
				Equals(
					valueLeft,
					valueRight);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueLeft"></param>
		/// <param name="valueRight"></param>
		/// <returns></returns>
		[MethodImpl(
			MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(
			LambdaCloudUserId valueLeft,
			LambdaCloudUserId valueRight) =>
				!Equals(
					valueLeft,
					valueRight);
	}
}
