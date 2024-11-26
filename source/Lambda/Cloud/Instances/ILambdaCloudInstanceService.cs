using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Immutable;

namespace Lambda.Cloud.Instances
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILambdaCloudInstanceService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<ImmutableArray<LambdaCloudInstanceTypeAvailability>> GetAllTypeAvailabilityAsync(
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<ImmutableArray<LambdaCloudInstance>> GetAllAsync(
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<LambdaCloudInstance> GetAsync(
			LambdaCloudInstanceId id,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<ImmutableArray<LambdaCloudInstanceId>> LaunchAsync(
			LambdaCloudInstanceLaunchOptions options,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<ImmutableArray<LambdaCloudInstance>> RestartAsync(
			LambdaCloudInstanceRestartOptions options,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<ImmutableArray<LambdaCloudInstance>> TerminateAsync(
			LambdaCloudInstanceTerminateOptions options,
			CancellationToken cancellationToken = default);
	}
}
