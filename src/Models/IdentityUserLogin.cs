﻿// © 2019 Mobsites. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Mobsites.AspNetCore.Identity.Cosmos
{
    /// <summary>
    ///     The required Cosmos implementation of an identity user login which uses a string as a primary key.
    /// </summary>
    public class IdentityUserLogin : Microsoft.AspNetCore.Identity.IdentityUserLogin<string>, ICosmosIdentity
    {
        /// <summary>
        ///     Initializes a new instance of <see cref="IdentityUserLogin"/>.
        /// </summary>
        /// <remarks>
        ///     The Id property is initialized to form a new GUID string value.
        /// </remarks>
        public IdentityUserLogin()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///     Cosmos requires a string property named "id" as a primary key. 
        ///     The base class does not provide one to override or hide.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Override this to provide a value for the partition key parameter in the Cosmos container method calls.
        ///     NOTE: The derived class must also include a property that matches the partition key path that was used when creating the container.
        /// </summary>
        public virtual string PartitionKey => nameof(IdentityUserLogin);
    }
}
