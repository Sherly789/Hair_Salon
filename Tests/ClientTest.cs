using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test1_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test2_Equal_ReturnsTrueIfNameAreTheSame()
    {
      //Arrange, Act
      Client firstClient = new Client("Joe");
      Client secondClient = new Client("Joe");

      //Assert
      Assert.Equal(firstClient, secondClient);
    }

    [Fact]
    public void Test3_Save_AssignsIdToObject()
    {
      //Arrange
      Client testClient = new Client("Joe");

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
