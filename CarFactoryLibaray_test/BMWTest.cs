using CarFactoryLibrary;

namespace CarFactoryLibaray_test
{
    public class BMWTest
    {
        [Fact]
        public void Equal_velocityAndMode_true()
        {
            // arrange
            BMW bmw1 = new BMW { velocity = 0, drivingMode = DrivingMode.Forward };
            BMW bmw2 = new BMW { velocity = 0, drivingMode = DrivingMode.Forward };

            // act
            bool result = bmw1.Equals(bmw2);

            // assert
            Assert.True(result);
        }


        [Fact]
        public void InRange_velocity_distance_true()
        {
            // arrange
            BMW bmw = new BMW { velocity = 10 };

            // act
            double time = bmw.TimeToCoverDistance(100);

            // assert
            Assert.InRange(time, 5, 15);
        }


        [Fact]
        public void OutRange_velocity_distance_true()
        {
            // arrange
            BMW bmw = new BMW { velocity = 10 };

            // act
            double time = bmw.TimeToCoverDistance(100);

            // assert
            Assert.NotInRange(time, 5, 6);
        }


        [Fact]
        public void TestStringStop_Direction_Stop()
        {
            // arrange
            BMW bmw = new BMW { drivingMode = DrivingMode.Stopped };

            // act
            string result = bmw.GetDirection();

            // assert
            Assert.StartsWith("S", result);
            Assert.Matches("^S.*", result);
        }


        [Fact]
        public void TestStringBackward_Direction_Backward()
        {
            // arrange
            BMW bmw = new BMW { drivingMode = DrivingMode.Backward };

            // act
            string result = bmw.GetDirection();

            // assert
            Assert.Equal(DrivingMode.Backward.ToString(), result);
            Assert.EndsWith("rd", result);
            Assert.Contains("wa", result);
            Assert.DoesNotContain("mm", result);
        }


        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            // arrange
            BMW bmw = new BMW();
            BMW t2 = new BMW();

            // act
            Car car = bmw.GetMyCar();

            // assert
            Assert.Same(bmw, car);
            Assert.NotSame(t2, car);
        }

        [Fact]
        public void NewCar_CarTypeBMW_ReturnsBMWInstance()
        {
            // act
            Car? car = CarFactory.NewCar(CarTypes.BMW);

            // assert
            Assert.IsType<BMW>(car);
            Assert.IsAssignableFrom<Car>(new BMW());
        }


        [Fact]
        public void NewCar_CarTypeHonda_ThrowsNotImplementedException()
        {
            // assert & act
            Assert.Throws<NotImplementedException>(() =>
            {
                // act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}

