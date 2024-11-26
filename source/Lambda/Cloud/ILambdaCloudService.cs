using System;

using Lambda;
using Lambda.Cloud;
using Lambda.Cloud.Keys;
using Lambda.Cloud.Instances;
using Lambda.Cloud.Filesystems;

namespace Lambda.Cloud
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILambdaCloudService
	{
		/// <summary>
		/// 
		/// </summary>
		public ILambdaCloudKeyService Keys { get; }

		/// <summary>
		/// 
		/// </summary>
		public ILambdaCloudInstanceService Instances {  get; }

		/// <summary>
		/// 
		/// </summary>
		public ILambdaCloudFilesystemService Filesystems { get; }
	}
}
