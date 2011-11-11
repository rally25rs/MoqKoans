using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqKoans.KoansHelpers;

namespace MoqKoans
{
	[TestClass]
	public class Moq4_Virtual : Koan
	{
		// A concrete class to test Moq with.
		// Note that this class contains a virtual method.
		public class Vehicle
		{
			public int GetHorsepower() { return 1001; }
			public virtual int GetNumerOfWheels() { return 4; }
		}

		[TestMethod]
		public void MoqCanCreateMocksAroundConcreteClasses()
		{
			// note that Vehicle is not an interface.
			var mockVehicle = new Mock<Vehicle>();

			Assert.AreEqual(___, mockVehicle.Object is Vehicle);
		}
		
		[TestMethod]
		public void NonVirtualMethodsAreWrappered_TheBaseMethodIsStillCalled()
		{
			var mockVehicle = new Mock<Vehicle>();

			Assert.AreEqual(___, mockVehicle.Object.GetHorsepower());
		}
		
		[TestMethod]
		public void VirtualMethodsAreHandledByMoq()
		{
			var mockVehicle = new Mock<Vehicle>();

			Assert.AreEqual(___, mockVehicle.Object.GetNumerOfWheels());
		}

		[TestMethod]
		public void VirtualMethodsCanBeSetupTheSameAsInterfaces()
		{
			var mockVehicle = new Mock<Vehicle>();
			mockVehicle.Setup(m => m.GetNumerOfWheels()).Returns(18);

			Assert.AreEqual(___, mockVehicle.Object.GetNumerOfWheels());			
		}

		[TestMethod]
		public void NonVirtualMethodsCanNotBeSetup()
		{
			var mockVehicle = new Mock<Vehicle>();
			try
			{
				mockVehicle.Setup(m => m.GetHorsepower()).Returns(170);
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(___));
			}
		}

		// An abstract class to test Moq with.
		public abstract class Person
		{
			public abstract string GetFirstName();
			public abstract string GetLastName();
		}

		[TestMethod]
		public void MoqCanMockAbstractClasses()
		{
			var mock = new Mock<Person>();

			Assert.IsInstanceOfType(mock.Object, typeof(___));
		}

		[TestMethod]
		public void WithLooseBehaviorMockedAbstractMethodsReturnTheirDefaultValue()
		{
			var mock = new Mock<Person>(MockBehavior.Loose);

			Assert.AreEqual(___, mock.Object.GetFirstName());
		}

		[TestMethod]
		public void WithStrictBehaviorMockedAbstractMethodsThrowAnExceptionUnlessSetup()
		{
			var mock = new Mock<Person>(MockBehavior.Strict);
			mock.Setup(x => x.GetFirstName()).Returns("Fred");

			Assert.AreEqual(___, mock.Object.GetFirstName());
			try
			{
				mock.Object.GetLastName();
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(___));
			}
		}

		[TestMethod]
		public void SetupAMockPersonWithTheNameJohnDoe()
		{
			var mock = new Mock<Person>(MockBehavior.Strict);
			mock.___();
			mock.___();

			var person = mock.Object;
			Assert.AreEqual("John", person.GetFirstName());
			Assert.AreEqual("Doe", person.GetLastName());
		}
	}
}
