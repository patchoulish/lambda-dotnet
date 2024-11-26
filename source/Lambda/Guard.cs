using System;

namespace Lambda
{
	/// <summary>
	/// Contains guard clauses for throwing exceptions.
	/// </summary>
	internal static class Guard
	{
		/// <summary>
		/// Throws an exception if the specified argument is null.
		/// </summary>
		/// <param name="argument">The argument specified.</param>
		/// <param name="argumentName">The name of the argument specified.</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified argument is null.
		/// </exception>
		public static void NotNull(
			object argument,
			string argumentName)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(
					argumentName);
			}
		}

		/// <summary>
		/// Throws an exception if the specified argument is null or empty.
		/// </summary>
		/// <param name="argument">The argument specified.</param>
		/// <param name="argumentName">The name of the argument specified.</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified argument is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Thrown if the specified argument is empty.
		/// </exception>
		public static void NotNullOrEmpty(
			string argument,
			string argumentName)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(
					argumentName);
			}

			if (String.IsNullOrEmpty(argument))
			{
				throw new ArgumentException(
					argumentName);
			}
		}
	}
}
