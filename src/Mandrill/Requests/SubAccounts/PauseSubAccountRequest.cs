﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Requests.SubAccounts
{
  public class PauseSubAccountRequest : RequestBase
  {
    public PauseSubAccountRequest(string id)
    {
      Id = id;
    }

    [JsonProperty("id")]
    public string Id { get; set; }
  }
}
