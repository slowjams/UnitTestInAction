//using ConsoleAppParameterizedTest;
//using FluentAssertions;
//using System;
//using System.Collections.Generic;
//using Xunit;
//using Moq;

//namespace ParameterizedTest {
//   public class UnitTest1 {
//      [Theory]
//      [MemberData(nameof(Data))]
//      public void Can_detect_an_invalid_delivery_date(DateTime deliveryDate, bool expected) {
//         var mock = new Mock<IEmailGateway>();
//         mock.Verify(x => x.SendGreetingsEmail(), Times.Once);

//         var stub = new Mock<IEmailGateway>();
//         stub.Setup(x => x.GetNumber()).Returns(3);
//      }

//      public static IEnumerable<object[]> Data() {
//         return new List<object[]>
//         {
//            new object[] { DateTime.Now.AddDays(-1), false },
//            new object[] { DateTime.Now, false },
//            new object[] { DateTime.Now.AddDays(1), false },
//            new object[] { DateTime.Now.AddDays(2), true }
//         };
//      }

//      [Fact]
//      public void Sum_of_two_numbers() {
//         var sut = new Calculator();

//         double result = sut.Sum(10, 20);

//         Assert.Equal(30, result);
//      }

//      [Fact]
//      public void Sum_of_two_numbers2() {
//         var sut = new Calculator();

//         double result = sut.Sum(10, 20);

//         result.Should().Be(30);
//      }

//      //   [Fact]
//      //   public void XXX() {
//      //       var mock = new Mock<MockedConverter>();
//      //      // var mock = new Mock<MyConverter> { CallBase = true };

//      //      var expected = 1;

//      //      var actual = mock.Convert();

//      //      Assert.Equal(expected, actual);
//      //   }
//      //}

//      public interface IEmailGateway {
//         void SendGreetingsEmail();
//         int GetNumber();
//      }

//      //public abstract class MyConverter  {
//      //   public abstract int Convert();

//      //   public virtual int ConvertBack() { return 1; }
//      //}

//      //public sealed class MockedConverter : MyConverter {
//      //   public override int Convert() {
//      //      return 0;
//      //   }

//      //   public override int ConvertBack() { return 2; }
//      //}
//   }
//}
