using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using FluentAssertions;

namespace ParameterizedTest {
   public interface IFoo {
      Bar Bar { get; set; }
      string Name { get; set; }
      int Value { get; set; }
      bool DoSomething(string value);
      bool DoSomething(int number, string value);
      Task<bool> DoSomethingAsync();
      string DoSomethingStringy(string value);
      bool TryParse(string value, out string outputValue);
      bool Submit(ref Bar bar);
      int GetCount();
      bool Add(int value);
   }

   public class Bar {
      public virtual Baz Baz { get; set; }
      public virtual bool Submit() { return false; }
   }

   public class Baz {
      public virtual string Name { get; set; }
   }

   public class UnitTest {
      [Fact]
      public void AAAVerifyPropertyIsSet_WithSpecificValue_WithSetupSet() {
         var mock = new Mock<IPropertyManager>();
         var nameUser = new PropertyManagerConsumer(mock.Object);

         mock.SetupSet(m => m.FirstName = "Knights Of Ni!").Verifiable();

         nameUser.ChangeName("Knights Of Ni!");

         mock.Verify();
      }

      [Fact]
      public void VerifyPropertyIsSet_WithSpecificValue_WithVerifySet() {
         var mock = new Mock<IPropertyManager>();
         var nameUser = new PropertyManagerConsumer(mock.Object);

         nameUser.ChangeName("No Shrubbery!");

         mock.VerifySet(m => m.FirstName = "No Shrubbery!");
      }

      [Fact]
      public void Verify() {
         var mock = new Mock<IPropertyManager>();
         var nameUser = new PropertyManagerConsumer(mock.Object);

         nameUser.ChangeRemoteName("My dear old wig");

         mock.Verify(m => m.MutateFirstName(It.Is<string>(a => a == "My dear old wig")), Times.Once);
      }

      [Fact]
      public void BBBTrackPropertyWithSetUpProperty() {
         var mock = new Mock<IPropertyManager>();

         mock.SetupProperty(m => m.FirstName);
         mock.Object.FirstName = "Ni!";

         try {
            mock.Object.FirstName.Should().Be("Ni");
         }
         catch (Exception e) { // e is XunitException
            var zzz = e;
         }

         

         //mock.Object.FirstName = "der wechselnden";
         //mock.Object.FirstName.Should().Be("der wechselnden");
      }
   }

   public interface IPropertyManager {
      string FirstName { get; set; }
      string LastName { get; set; }
      void MutateFirstName(string name);
   }

   public class PropertyManager : IPropertyManager {
      public string FirstName { get; set; }
      public string LastName { get; set; }

      public void MutateFirstName(string name) {
         this.FirstName = name;
      }
   }

   class PropertyManagerConsumer {
      private readonly IPropertyManager _propertyManager;

      public PropertyManagerConsumer(IPropertyManager propertyManager) {
         _propertyManager = propertyManager;
      }

      public void ChangeName(string name) {
         _propertyManager.FirstName = name;
      }

      public string GetName() {
         return _propertyManager.FirstName;
      }

      public void ChangeRemoteName(string name) {
         _propertyManager.MutateFirstName(name);
      }
   }
}
