using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqKoans.KoansHelpers;

namespace MoqKoans
{
	[TestClass]
	public class Moq5_Properties : Koan
	{
		// This is an Interface with some properties.
		public interface IPerson
		{
			string Name { get; set; }
			int Age { get; set; }
		}

		[TestMethod]
		public void WithLooseBehaviorMethodsWillNotSaveAValueAndAlwaysReturnTheirDefault()
		{
			var person = new Mock<IPerson>(MockBehavior.Loose).Object;

			Assert.AreEqual(___, person.Name);
			Assert.AreEqual(___, person.Age);

			person.Name = "Joe";
			person.Age = 36;

			Assert.AreEqual(___, person.Name);
			Assert.AreEqual(___, person.Age);
		}

		[TestMethod]
		public void WithStrictBehaviorGettingOrSettingAPropertyThatHasNotBeenSetupThrowsException()
		{
			var person = new Mock<IPerson>(MockBehavior.Strict).Object;

			var exceptionWasThrown = false;
			try
			{
				var name = person.Name;
			}
			catch (Exception)
			{
				exceptionWasThrown = true;
			}
			Assert.AreEqual(___, exceptionWasThrown);

			exceptionWasThrown = false;
			try
			{
				person.Name = "John";
			}
			catch (Exception)
			{
				exceptionWasThrown = true;
			}
			Assert.AreEqual(___, exceptionWasThrown);
		}

		[TestMethod]
		public void SetupPropertyCausesAPropertyToRetainValuesAsExpected()
		{
			var mock = new Mock<IPerson>();
			var person = mock.Object;

			mock.SetupProperty(x => x.Name);
			mock.SetupProperty(x => x.Age);

			Assert.AreEqual(___, person.Name);
			Assert.AreEqual(___, person.Age);

			person.Name = "Joe";
			person.Age = 36;

			Assert.AreEqual(___, person.Name);
			Assert.AreEqual(___, person.Age);
		}

		[TestMethod]
		public void SetupPropertyCanSpecifyAnInitialValue()
		{
			var mock = new Mock<IPerson>();
			var person = mock.Object;

			mock.SetupProperty(x => x.Name, "Fred");
			mock.SetupProperty(x => x.Age, 21);

			Assert.AreEqual(___, person.Name);
			Assert.AreEqual(___, person.Age);

			person.Name = "Joe";
			person.Age = 36;

			Assert.AreEqual(___, person.Name);
			Assert.AreEqual(___, person.Age);
		}

		[TestMethod]
		public void SetupAllPropertiesCanBeUsedToSimulateCallingSetupPropertyForEachIndividualProperty()
		{
			var mock = new Mock<IPerson>(MockBehavior.Strict);
			var person = mock.Object;

			mock.SetupAllProperties();

			person.Name = "Joe";
			person.Age = 36;

			Assert.AreEqual(___, person.Name);
			Assert.AreEqual(___, person.Age);
		}
	}
}
