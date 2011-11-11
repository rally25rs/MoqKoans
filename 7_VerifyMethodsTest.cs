using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoqKoans
{
	[TestClass]
	public class Moq7_VerifyMethodsTest
	{
		// This is an interface that we will be mocking.
		public interface IVolume
		{
			int Louder(int amount);
			int Quieter(int amount);
			string CurrentVolume();
		}

		// a method to test
		private static void Mute(IVolume volume)
		{
			var timesTried = 0;
			while (volume.CurrentVolume() != "0")
			{
				timesTried++;
				if(timesTried > 10)
					return;
				volume.Quieter(10);
			}
		}

		/* *** Instructions *** */
		//
		// some documentation states that when Mute() is called,
		// it will call .Quieter() on the passed in IVolume instance.
		// It should turn down the volume 10 notches at a time until
		// the current volume reaches 0.
		//
		// As a failsafe incase the volume knob breaks, the Mute()
		// method will only try to call .Quieter() at most 10 times.
		//
		// Verify that the Mute() function works as expected.
		//
		// For example, if the IVolume passed to Mute has its volume
		// set to 50 initially, then Mute() should call the Quieter
		// method exactly how many times?
		//
		// How many times is Quieter called if CurrentVolume already
		// returns "0"?
		//
		// Fill in these existing tests, and add more if you want.

		[TestMethod]
		public void Mute_DoesNotCallQuieter_WhenCurrentVolumeIsAlreadyZero()
		{
			throw new NotImplementedException(); // <-- replace this with your test code.
		}

		[TestMethod]
		public void Mute_CallsQuieterRepeatedly_UntilCurrentVolumeReturnsZero()
		{
			throw new NotImplementedException(); // <-- replace this with your test code.
		}

		[TestMethod]
		public void Mute_CallsQuieterNoMoreThanTenTimes_WhenCurrentVolumeNeverReturnsZero()
		{
			throw new NotImplementedException(); // <-- replace this with your test code.
		}
	}
}
