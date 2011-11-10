using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoqKoans.KoansHelpers
{
	public class Koan
	{
		private const string EMPTY_ASSERT_MSG = "Replace the method call \"Assert___()\" with an appropriate Assert statement.";
		private const string EMPTY_ANSWER_MSG = "Replace \"___\" with your answer to make the test pass.";

		private static readonly object _obj = new object();

		protected static object ___
		{
			get { return _obj; /*throw new AssertFailedException(EMPTY_ANSWER_MSG);*/ }
		}

		protected static int ____
		{
			get { return 0; }
		}

		protected void Assert___(params object[] objs)
		{
			throw new AssertFailedException(EMPTY_ASSERT_MSG);
		}
	}
}
