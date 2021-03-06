﻿using System;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using Mandrill.Requests;
using Mandrill.Utilities;
using NUnit.Framework;

namespace Mandrill.Tests.UnitTests
{
  [TestFixture]
  public class PostTests
  {
    [SetUp]
    public void CreateHttpTest()
    {
      httpClient = new HttpTest();
    }

    [TearDown]
    public void DisposeHttpTest()
    {
      httpClient.Dispose();
    }

    private HttpTest httpClient;

    private class SampleObject
    {
      public string Name { get; set; }
      public int Id { get; set; }
    }

    private class SamplePayload : RequestBase
    {
    }

    [Test]
    public async Task Should_Serialize_Response_When_Json_Content_Is_Recieved()
    {
      string responseString = @"{
	      ""Name"": ""Shawn"",
	      ""Id"": 1
      }";
      httpClient.RespondWith(200, responseString);

      var api = new MandrillApi("");
      SampleObject response = await api.Post<SampleObject>("", new SamplePayload());

      Assert.AreEqual("Shawn", response.Name);
      Assert.AreEqual(1, response.Id);
    }

    [Test]
    public async Task Should_Throw_Mandrill_Exception_When_Server_Error()
    {
      string responseString = @"{
	      ""code"": ""501"",
	      ""message"": ""m1"",
	      ""name"": ""n1"",
	      ""status"": ""s1""
      }";

      httpClient.RespondWith(500, responseString);

      var api = new MandrillApi("");
      var ex = Assert.Throws<MandrillException>(async () => await api.Post<object>("", new SamplePayload()));
      Assert.AreEqual(501, ex.Error.Code);
      Assert.AreEqual("m1", ex.Error.Message);
      Assert.AreEqual("n1", ex.Error.Name);
      Assert.AreEqual("s1", ex.Error.Status);
    }

    [Test]
    public async Task Should_Throw_TimeOut_Exception_When_Timing_Out()
    {
      httpClient.SimulateTimeout();

      var api = new MandrillApi("");
      Assert.Throws<TimeoutException>(async () => await api.Post<object>("", new SamplePayload()));
    }
  }
}