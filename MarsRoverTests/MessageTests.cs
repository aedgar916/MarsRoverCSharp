using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        // TEST #5
        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("HELLO", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Name is required", ex.Message);
            }

        }

        // TEST #6
        [TestMethod]
        public void ConstructorSetsName()
        {
            Message newMessage = new Message("HELLO", commands);

            Assert.AreEqual("HELLO", newMessage.Name);
        }

        // TEST #7
        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message newMessage = new Message("HELLO", commands);

            Assert.AreEqual(commands, newMessage.Commands);
        }
    }
}
