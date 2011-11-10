using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MoqKoans.KoansHelpers
{
	public static class ObjectExtensions
	{
		private const string REPLACE_METHOD_MSG = "Replace the method call \".___()\" with the appropriate method to make the test pass.";

		public static object ___(this object obj, params object[] inputs)
		{
			throw new AssertFailedException(REPLACE_METHOD_MSG);
		}
	}
}
