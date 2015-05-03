﻿using Mandrill.Models;
using Mandrill.Requests.SubAccounts;

namespace Mandrill
{
  using System;
  using System.Collections.Generic;
  using System.Dynamic;
  using System.Threading.Tasks;

  public partial class MandrillApi
  {
    #region Public Methods and Operators

    /// <summary>
    ///     Add a new subaccount.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=add">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="request">The subaccount request</param>
    /// <returns>the information saved about the new subaccount</returns>
    public async Task<SubaccountInfo> AddSubaccount(AddSubAccountRequest request) {
      const string path = "/subaccounts/add.json";

      var resp = await Post<SubaccountInfo>(path, request);

      return resp;
    }


    /// <summary>
    ///     Delete an existing subaccount. Any email related to the subaccount will be saved, but stats will be removed and any
    ///     future sending calls to this subaccount will fail.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=delete">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>the information for the deleted subaccount</returns>
    public async Task<SubaccountInfo> DeleteSubaccount(DeleteSubAccountRequest request) {
      const string path = "/subaccounts/delete.json";

      var resp = await Post<SubaccountInfo>(path, request);

      return resp;
    }


    /// <summary>
    ///     Get the list of subaccounts defined for the account, optionally filtered by a prefix.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=list">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>the subaccounts for the account, up to a maximum of 1,000</returns>
    public async Task<List<SubaccountInfo>> ListSubaccounts(ListSubAccountsRequest request) {
      const string path = "/subaccounts/list.json";

      var resp = await Post<List<SubaccountInfo>>(path, request);

      return resp;
    }

    /// <summary>
    ///     Pause a subaccount's sending. Any future emails delivered to this subaccount will be queued for a maximum of 3 days
    ///     until the subaccount is resumed.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=pause">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>the information for the paused subaccount</returns>
    public async Task<SubaccountInfo> PauseSubaccount(PauseSubAccountRequest request) {

      const string path = "/subaccounts/pause.json";

      var resp = await Post<SubaccountInfo>(path, request);

      return resp;
    }

    /// <summary>
    ///     Resume a paused subaccount's sending
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=resume">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to resume</param>
    /// <returns>the information for the resumed subaccount</returns>
    public SubaccountInfo ResumeSubaccount(string id) {
      try {
        return this.ResumeSubaccountAsync(id).Result;
      } catch (AggregateException aex) {
        //catch and throw the inner exception
        throw aex.Flatten().InnerException;
      }
    }

    /// <summary>
    ///     Asynchronously resume a paused subaccount's sending
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=resume">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to resume</param>
    /// <returns>the information for the resumed subaccount</returns>
    public Task<SubaccountInfo> ResumeSubaccountAsync(string id) {
      const string path = "/subaccounts/resume.json";

      dynamic payload = new ExpandoObject();
      payload.id = id;

      return this.PostAsync<SubaccountInfo>(path, payload);
    }

    /// <summary>
    ///     Given the ID of an existing subaccount, asynchronously return the data about it
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=info">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>the information about the subaccount</returns>
    public async Task<SubaccountInfo> SubaccountInfo(SubAccountInfoRequest request) {
      const string path = "/subaccounts/info.json";

      var response = await Post<SubaccountInfo>(path, request);

      return response;
    }

    /// <summary>
    ///     Update an existing subaccount
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=update">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>the information for the updated subaccount</returns>
    public async Task<SubaccountInfo> UpdateSubaccount(UpdateSubAccountRequest request) {
      const string path = "/subaccounts/update.json";

      var response = await Post<SubaccountInfo>(path, request);

      return response;
    }

    #endregion
  }
}