using System;
using System.Net;
using System.Net.Http;

namespace Lambda.Cloud
{
	/// <summary>
	/// 
	/// </summary>
	public class LambdaCloudException :
		HttpRequestException
	{
#if NETSTANDARD

		/// <summary>
		/// Gets the HTTP status code for this exception, if any.
		/// </summary>
		public HttpStatusCode? StatusCode { get; private init; }

#endif

		/// <summary>
		/// Gets the LambdaCloud error for this exception, if any.
		/// </summary>
		public LambdaCloudError Error { get; private init; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LambdaCloudException"/>
		/// class.
		/// </summary>
		public LambdaCloudException() :
			this(
				default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="LambdaCloudException"/>
		/// class with a specific message that describes the current exception.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		public LambdaCloudException(
			string message) :
				this(
					message,
					default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="LambdaCloudException"/>
		/// class with a specific message that describes the current exception
		/// and an inner exception.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		public LambdaCloudException(
			string message,
			Exception innerException) :
				this(
					message,
					innerException,
					default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="LambdaCloudException"/>
		/// class with a specific message that describes the current exception,
		/// an inner exception, and an HTTP status code.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		/// <param name="statusCode">
		/// The HTTP status code.
		/// </param>
		public LambdaCloudException(
			string message,
			Exception innerException,
			HttpStatusCode? statusCode) :
				this(
					message,
					innerException,
					statusCode,
					default)
		{ }

#if NETSTANDARD

		/// <summary>
		/// Initializes a new instance of the <see cref="LambdaCloudException"/>
		/// class with a specific message that describes the current exception,
		/// an inner exception, an HTTP status code, and Lambda Cloud error.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		/// <param name="statusCode">
		/// The HTTP status code.
		/// </param>
		/// <param name="error">
		/// The Lambda Cloud error.
		/// </param>
		public LambdaCloudException(
			string message,
			Exception innerException,
			HttpStatusCode? statusCode,
			LambdaCloudError error) :
				base(
					message,
					innerException)
		{
			StatusCode = statusCode;
			Error = error;
		}

#endif

#if NET

		/// <summary>
		/// Initializes a new instance of the <see cref="LambdaCloudException"/>
		/// class with a specific message that describes the current exception,
		/// an inner exception, an HTTP status code, and Lambda Cloud error.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		/// <param name="statusCode">
		/// The HTTP status code.
		/// </param>
		/// <param name="error">
		/// The Lambda Cloud error.
		/// </param>
		public LambdaCloudException(
			string message,
			Exception innerException,
			HttpStatusCode? statusCode,
			LambdaCloudError error) :
				base(
					message,
					innerException,
					statusCode)
		{
			Error = error;
		}

#endif
	}
}
