using Cactus.WebDav.Core.WebDav;
using System.Collections.Generic;
using Cactus.WebDav.Common.Helpers;

namespace WebDav.Response
{
    /// <summary>
    /// Represents a response of the PROPPATCH operation.
    /// </summary>
    public class PropPatchResponse : WebDavResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropPatchResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The status code of the operation.</param>
        public PropPatchResponse(int statusCode)
            : this(statusCode, null, new List<WebDavPropertyStatus>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropPatchResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The status code of the response.</param>
        /// <param name="propertyStatuses">The collection of property statuses.</param>
        public PropPatchResponse(int statusCode, IEnumerable<WebDavPropertyStatus> propertyStatuses)
            : this(statusCode, null, propertyStatuses)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropPatchResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The status code of the response.</param>
        /// <param name="description">The description of the response.</param>
        public PropPatchResponse(int statusCode, string description)
            : this(statusCode, description, new List<WebDavPropertyStatus>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropPatchResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The status code of the response.</param>
        /// <param name="description">The description of the response.</param>
        /// <param name="propertyStatuses">The collection of property statuses.</param>
        public PropPatchResponse(int statusCode, string description, IEnumerable<WebDavPropertyStatus> propertyStatuses)
            : base(statusCode, description)
        {
            Guard.NotNull(propertyStatuses, "propertyStatuses");

            PropertyStatuses = new List<WebDavPropertyStatus>(propertyStatuses);
        }

        /// <summary>
        /// Gets the collection statuses of set/delete operation on the resource's properties.
        /// </summary>
        public IReadOnlyCollection<WebDavPropertyStatus> PropertyStatuses { get; }

        public override string ToString()
        {
            return $"PROPPATCH WebDAV response - StatusCode: {StatusCode}, Description: {Description}";
        }
    }
}
