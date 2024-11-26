using System;

using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lambda.Cloud
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public sealed partial class LambdaCloudServiceTests
	{
		private ILambdaCloudService lambdaCloud;

		/// <summary>
		/// 
		/// </summary>
		[TestInitialize]
		public void Initialize()
		{
			this.lambdaCloud =
				new LambdaCloudService(
					Environment.GetEnvironmentVariable(
						"LAMBDA_API_KEY"));
		}
	}
}
