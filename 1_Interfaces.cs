using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqKoans.KoansHelpers;

namespace MoqKoans
{
	/// <summary>
	/// The tests in this class will make you familiar with creating Mock objects with Moq.
	/// </summary>
	[TestClass]
	public class Moq1_Interfaces : Koan
	{
		// This is an interface that we will be mocking.
		public interface IVolume
		{
			void Louder();
			void Quieter();
			string Current();
		}

		// This is a simple implementation of IVolume.
		private class Volume : IVolume
		{
			private int volume = 50;

			public void Louder() { volume++; }
			public void Quieter() { volume--; }
			public string Current() { return volume.ToString(); }
		}

		[TestMethod]
		public void VariablesStartAsNull()
		{
			IVolume volume = null;
			Assert.AreEqual(___, volume == null);
		}

		[TestMethod]
		public void AnInstanceOfVolumeIsAlsoAnIVolume()
		{
			var volume = new Volume();
			Assert.AreEqual(___, volume is IVolume);
		}

		[TestMethod]
		public void AMockOfIVolumeIsNotAnIVolume()
		{
			var volume = new Moq.Mock<IVolume>();
			Assert.AreEqual(___, volume is IVolume);
			Assert.IsTrue(volume is ___);
		}

		[TestMethod]
		public void TheObjectPropertyOfAMockReturnsAnInstanceThatImplementsTheMockedInterface()
		{
			var volume = new Moq.Mock<IVolume>();
			Assert.AreEqual(___, volume.Object is IVolume);
		}

		// IVolume was a public interface.
		// This one is private instead.
		private interface IPrivateInterface
		{
			string SomeMethod();
		}

		[TestMethod]
		public void CanNotMockAPrivateInterface()
		{

      var exceptionWasThrown = false;
      try
			{
				var mock = new Moq.Mock<IPrivateInterface>().Object;
			}
			catch (Exception ex)
			{
        exceptionWasThrown = true;
			}
      Assert.AreEqual(___, exceptionWasThrown);
		}

		[TestMethod]
		public void CreateANewMockOfIVolumeToMakeThisTestPass()
		{
			var mock = new ___();
			Assert.IsInstanceOfType(mock, typeof(Moq.Mock<IVolume>));
		}
	}
}
