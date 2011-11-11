using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqKoans.KoansHelpers;

namespace MoqKoans
{
	[TestClass]
	public class Moq6_VerifyMethods : Koan
	{
		// This is an interface that we will be mocking.
		public interface IVolume
		{
			int Louder(int amount);
			int Quieter(int amount);
			string CurrentVolume();
		}

		[TestMethod]
		public void MethodsSetUpWithVerifiableCanBeCheckedToSeeIfTheyWereCalled()
		{
			var mock = new Mock<IVolume>();
			mock.Setup(x => x.Louder(It.IsAny<int>()))
				.Returns(0)
				.Verifiable();

      var exceptionWasThrown = false;
      try
			{
				mock.Verify(); // the call to Verify tells Moq to ensure that all .Verifiable() setup methods have been called.
			}
			catch (Exception ex)
			{
        exceptionWasThrown = true;
			}
      Assert.AreEqual(___, exceptionWasThrown);
		}

		[TestMethod]
		public void ACustomErrorMessageCanBeSpecifiedInVerifiable()
		{
			var mock = new Mock<IVolume>();
			mock.Setup(x => x.Louder(It.IsAny<int>()))
				.Returns(0)
				.Verifiable("This message will be in the Exception if the method is not called.");

      var exceptionWasThrown = false;
      try
			{
				mock.Verify();
			}
			catch (Exception ex)
			{
        exceptionWasThrown = true;
				Assert.IsTrue(ex.Message.Contains("___"));
			}
      Assert.AreEqual(___, exceptionWasThrown);
		}

		[TestMethod]
		public void IfAMethodIsSetupVerifiableButVerifyIsNotCalledLaterThenNoExceptionIsThrown()
		{
			var mock = new Mock<IVolume>();
			mock.Setup(x => x.Louder(It.IsAny<int>()))
				.Returns(0)
				.Verifiable("Louder was not called.");

			//mock.Object.Louder(0);  <-- intentionally NOT calling .Louder. Don't uncomment this to solve the test.

			try
			{
				mock.___();

				Assert.Fail(".Louder() was not called on the Mock, but no exception was thrown.");
			}
			catch (MockException)
			{
				// we expect an exception to be thrown, sicne we are not calling .Louder(), but it is setup to be verifiable.
			}
		}

		[TestMethod]
		public void VerifyChecksAllMethodsThatAreVerifiable_AllMustHaveBeenCalled()
		{
			var mock = new Mock<IVolume>();

			mock.Setup(x => x.Louder(It.IsAny<int>()))
				.Returns(0)
				.Verifiable("I can barely hear that thing. Crank it up!");

			mock.Setup(x => x.Quieter(It.IsAny<int>()))
				.Returns(0)
				.Verifiable("Its too loud in here. Turn it down!");

			var volume = mock.Object;
			volume.Quieter(100);
			volume.____();

			mock.Verify();
		}

		[TestMethod]
		public void VerifiablePassesAsLongAsMethodIsCalledOneOrMoreTimes()
		{
			var mock = new Mock<IVolume>();
			mock.Setup(x => x.CurrentVolume()).Verifiable();

			var volume = mock.Object;
			volume.CurrentVolume();
			volume.CurrentVolume();
			volume.CurrentVolume();
			volume.CurrentVolume();

			var wasAnExceptionThrown = false;
			try
			{
				mock.Verify();
			}
			catch (Exception)
			{
				wasAnExceptionThrown = true;
			}

			Assert.AreEqual(___, wasAnExceptionThrown);
		}

		[TestMethod]
		public void MethodCallsCanAlsoBeVerifiedWithTheVerifyMethodInsteadOfInSetup()
		{
			var mock = new Mock<IVolume>();

			try
			{
				// the syntax for .Verify() is the same as .Setup() in that it is given a Lambda expression
				// that indicates what method and parameters to verify.
				mock.Verify(x => x.CurrentVolume());
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(___));
			}
		}

		[TestMethod]
		public void VerifyCanFilterByInputParameters()
		{
			var mock = new Mock<IVolume>();

			mock.Object.Louder(20);

			var wasAnExceptionThrown = false;
			try
			{
				mock.Verify(x => x.Louder(10));
			}
			catch (Exception)
			{
				wasAnExceptionThrown = true;
			}

			Assert.AreEqual(___, wasAnExceptionThrown);	
		}

		[TestMethod]
		public void VerifyCanBeUsedMoreThanOnceOnTheSameMethodWithDifferentConditions()
		{
			var mock = new Mock<IVolume>();
			var volume = mock.Object;

			volume.____();
			volume.____();

			mock.Verify(x => x.Quieter(10), "Quieter should have been called with the value 10.");
			mock.Verify(x => x.Quieter(It.Is<int>(p => p > 20 && p < 30)), "Quieter should have been called with a value between 20 and 30.");
		}

		[TestMethod]
		public void VerifyTimesCanBeUsedToEnsureAMethodIsCalledAnExactNumberOfTimes()
		{
			var mock = new Mock<IVolume>();
			var volume = mock.Object;

			volume.CurrentVolume();
			volume.CurrentVolume();

			var wasAnExceptionThrown = false;
			try
			{
				mock.Verify(x => x.CurrentVolume(), Times.Once());
			}
			catch (Exception)
			{
				wasAnExceptionThrown = true;
			}

			Assert.AreEqual(___, wasAnExceptionThrown);
		}

		[TestMethod]
		public void VerifyCurrentVolumeWasCalledExactlyThreeTimes()
		{
			var mock = new Mock<IVolume>();
			var volume = mock.Object;

			volume.____();

			mock.Verify(x => x.CurrentVolume(), Times.Exactly(3));
		}

		[TestMethod]
		public void SetupAndVerifyCanBeUsedTogether()
		{
			var mock = new Mock<IVolume>();
			var volume = mock.Object;

			mock.Setup(x => x.Louder(It.IsAny<int>())).Returns<int>(p => p);

			Assert.AreEqual(___, volume.Louder(22));

			mock.Verify(x => x.Louder(____), Times.AtLeastOnce());
		}
	}
}
