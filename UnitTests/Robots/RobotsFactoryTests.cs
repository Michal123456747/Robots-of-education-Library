using System;
using Xunit;
using ROELibrary;
using Moq;


namespace UnitTests.Robots
{
    public class RobotsFactoryTests
    {
        [Theory]
        [InlineData((int)ERobotsSymbols.car)] //TODO: add more tests
        public void getDeviceCreator_CorrectRobotType_GetCorrectCreator(int deviceType)
        {
            //arrange
            var device = new Mock<IRobotDevice>();
            Func<VRobotModel, IRobotDevice> deviceCreator = (VRobotModel robotModel) => { return device.Object; };

            //update creators
            RobotsFactory.updateDeviceCreators((ERobotsSymbols)deviceType, deviceCreator);


            //act && assert
            Assert.Equal(device.Object, RobotsFactory.getDeviceCreator((ERobotsSymbols)deviceType)(new CarModel()));
        }

        [Fact]
        public void getDeviceCreator_IncorrectRobotType_throwException()
        {
            //act & assert
            var ex = Assert.Throws<ArgumentException>(() => RobotsFactory.getDeviceCreator(ERobotsSymbols.nothingToDo));
            Assert.Equal("Creator for a robot type doesn't exist", ex.Message);
            Assert.Equal(ERobotsSymbols.nothingToDo, ex.Data["deviceType"]);
        }
    }
}
