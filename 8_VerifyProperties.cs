using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqKoans.KoansHelpers;

namespace MoqKoans
{
	[TestClass]
	public class Moq8_VerifyProperties : Koan
	{
		// This is an Interface with some properties.
		public interface IPerson
		{
			string Name { get; set; }
			int Age { get; set; }
		}

		[TestMethod]
		public void VerifySetCanBeUsedToEnsureAPropertyIsSetToASpecificValue()
		{
			var mock = new Mock<IPerson>();
			mock.SetupAllProperties();

			mock.Object.Name = "John";

			mock.VerifySet(x => x.Name = "___");
		}

		[TestMethod]
		public void VerifyGetCanBeUsedToEnsureAPropertyValueIsRead()
		{
			var mock = new Mock<IPerson>();
			mock.SetupProperty(x => x.Age, 24);

			var exceptionWasThrown = false;
			try
			{
				mock.VerifyGet(x => x.Age, "The user's age was never checked.");
			}
			catch (Exception ex)
			{
				exceptionWasThrown = true;
			}
			Assert.AreEqual(___, exceptionWasThrown);
		}

		public static object BuyBeer(IPerson buyer)
		{
			return buyer.Age >= 21 ? new object() : null;
		}

		[TestMethod]
		public void WriteATestToEnsureTheBuyBeerMethodChecksThePersonsAge()
		{
			var mock = new ___();

			BuyBeer(mock.Object);

			mock.___(); // verify the user's age was checked.
		}
	}
}
