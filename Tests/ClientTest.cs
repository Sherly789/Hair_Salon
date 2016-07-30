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

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
