using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test1_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test2_Equal_ReturnsTrueIfNameAreTheSame()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Sara");
      Stylist secondStylist = new Stylist("Sara");

      //Assert
      Assert.Equal(firstStylist, secondStylist);
    }

    [Fact]
    public void Test3_Save_AssignsIdToObject()
    {
      //Arrange
      Stylist testStylist = new Stylist("Sara");

      //Act
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test4_Find_FindsStylistInDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Sara");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.Equal(testStylist, foundStylist);
    }

    [Fact]
    public void Test5_Update_UpdatesStylistInDatabase()
    {
      //Arrange
      string name = "Sara";
      Stylist testStylist = new Stylist(name);
      testStylist.Save();
      string newName = "Tom";

      //Act
      testStylist.Update(newName);

      string result = testStylist.GetName();

      //Assert
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test_GetClients_RetrievesAllClientsWithStylist()
    {
      Stylist testStylist = new Stylist("Sara");
      testStylist.Save();

      Client firstClient = new Client("Joe", testStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client("John", testStylist.GetId());
      secondClient.Save();


      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClients();

      Assert.Equal(testClientList, resultClientList);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
