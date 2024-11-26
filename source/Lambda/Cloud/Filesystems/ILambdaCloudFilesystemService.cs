using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Immutable;

namespace Lambda.Cloud.Filesystems
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILambdaCloudFilesystemService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<ImmutableArray<LambdaCloudFilesystem>> GetAllAsync(
			CancellationToken cancellationToken = default);
	}
}
