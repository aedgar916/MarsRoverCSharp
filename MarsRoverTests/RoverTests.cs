using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 500) };

        Rover newRover = new Rover(77777);


        // TEST #8
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {

            Assert.AreEqual(77777, newRover.Position);
        }

        // TEST #9
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {

            Assert.AreEqual("NORMAL", newRover.Mode);

        }

        // TEST #10
        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {

            Assert.AreEqual(110, newRover.GeneratorWatts);
        }

        // TEST #11
        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {

            Message newMessage = new Message("HELLO", commands);

            newRover.ReceiveMessage(newMessage);

            Assert.AreEqual("LOW_POWER", newRover.Mode);

        }

        // TEST #12
        [TestMethod]
        public void DoesNotMoveInLowPower()
        {

            Message newMessage = new Message("HELLO", commands);

            newRover.ReceiveMessage(newMessage);

            Assert.AreEqual(77777, newRover.Position);
        }

        // TEST #13
        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Command[] commands1 = { new Command("MOVE", 500) };

            Message newMessage = new Message("HELLO", commands1);

            newRover.ReceiveMessage(newMessage);

            Assert.AreEqual(500, newRover.Position);
        }

        // TEST #14
        [TestMethod]
        public void RoverReturnsAMessageForAnUnknownCommand()
        {
            Command[] commands2 = { new Command("HOLD_UP", 500) };

            Message newMessage = new Message("HELLO", commands2);

            try
            {
                newRover.ReceiveMessage(newMessage);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Unknown Command. Message not sent.", ex.Message);
            }


            //AreEqual("Unknown Command. Message not sent.", newRover.ReceiveMessage(newMessage));
        }
    }
}
