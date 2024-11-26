using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Immutable;

namespace Lambda.Cloud.Keys
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILambdaCloudKeyService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<ImmutableArray<LambdaCloudKey>> GetAllAsync(
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<LambdaCloudKey> AddOrGenerateAsync(
			LambdaCloudKeyAddOrGenerateOptions options,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task DeleteAsync(
			LambdaCloudKeyId id,
			CancellationToken cancellationToken = default);
	}
}
