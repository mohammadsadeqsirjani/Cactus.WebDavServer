using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebDav.Request.Parameters;
using WebDav.Response;

namespace WebDav
{
    /// <summary>
    /// Represents a WebDAV client that can perform WebDAV operations.
    /// </summary>
    public interface IWebDavClient : IDisposable
    {
        /// <summary>
        /// Retrieves properties defined on the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <returns>An instance of <see cref="PropFindResponse" />.</returns>
        Task<PropFindResponse> Propfind(string requestUri);

        /// <summary>
        /// Retrieves properties defined on the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <returns>An instance of <see cref="PropFindResponse" />.</returns>
        Task<PropFindResponse> Propfind(Uri requestUri);

        /// <summary>
        /// Retrieves properties defined on the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="parameters">Parameters of the PROPFIND operation.</param>
        /// <returns>An instance of <see cref="PropFindResponse" />.</returns>
        Task<PropFindResponse> Propfind(string requestUri, PropFindParameters parameters);

        /// <summary>
        /// Retrieves properties defined on the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="parameters">Parameters of the PROPFIND operation.</param>
        /// <returns>An instance of <see cref="PropFindResponse" />.</returns>
        Task<PropFindResponse> Propfind(Uri requestUri, PropFindParameters parameters);

        /// <summary>
        /// Sets and/or removes properties defined on the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="parameters">Parameters of the PROPPATCH operation.</param>
        /// <returns>An instance of <see>
        ///         <cref>PropPatchResponse</cref>
        ///     </see>
        ///     .</returns>
        Task<PropPatchResponse> PropPatch(string requestUri, PropPatchParameters parameters);

        /// <summary>
        /// Sets and/or removes properties defined on the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="parameters">Parameters of the PROPPATCH operation.</param>
        /// <returns>An instance of <see>
        ///         <cref>PropPatchResponse</cref>
        ///     </see>
        ///     .</returns>
        Task<PropPatchResponse> PropPatch(Uri requestUri, PropPatchParameters parameters);

        /// <summary>
        /// Creates a new collection resource at the location specified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> MkCol(string requestUri);

        /// <summary>
        /// Creates a new collection resource at the location specified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> MkCol(Uri requestUri);

        /// <summary>
        /// Creates a new collection resource at the location specified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="parameters">Parameters of the MKCOL operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> MkCol(string requestUri, MkColParameters parameters);

        /// <summary>
        /// Creates a new collection resource at the location specified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="parameters">Parameters of the MKCOL operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> MkCol(Uri requestUri, MkColParameters parameters);

        /// <summary>
        /// Retrieves the file identified by the request URI telling the server to return it without processing.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <returns>An instance of <see cref="WebDavStreamResponse" />.</returns>
        Task<WebDavStreamResponse> GetRawFile(string requestUri);

        /// <summary>
        /// Retrieves the file identified by the request URI telling the server to return it without processing.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <returns>An instance of <see cref="WebDavStreamResponse" />.</returns>
        Task<WebDavStreamResponse> GetRawFile(Uri requestUri);

        /// <summary>
        /// Retrieves the file identified by the request URI telling the server to return it without processing.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="parameters">Parameters of the GET operation.</param>
        /// <returns>An instance of <see cref="WebDavStreamResponse" />.</returns>
        Task<WebDavStreamResponse> GetRawFile(string requestUri, GetParameters parameters);

        /// <summary>
        /// Retrieves the file identified by the request URI telling the server to return it without processing.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="parameters">Parameters of the GET operation.</param>
        /// <returns>An instance of <see cref="WebDavStreamResponse" />.</returns>
        Task<WebDavStreamResponse> GetRawFile(Uri requestUri, GetParameters parameters);

        /// <summary>
        /// Retrieves the file identified by the request URI telling the server to return a processed response, if possible.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <returns>An instance of <see cref="WebDavStreamResponse" />.</returns>
        Task<WebDavStreamResponse> GetProcessedFile(string requestUri);

        /// <summary>
        /// Retrieves the file identified by the request URI telling the server to return a processed response, if possible.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <returns>An instance of <see cref="WebDavStreamResponse" />.</returns>
        Task<WebDavStreamResponse> GetProcessedFile(Uri requestUri);

        /// <summary>
        /// Retrieves the file identified by the request URI telling the server to return a processed response, if possible.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="parameters">Parameters of the GET operation.</param>
        /// <returns>An instance of <see cref="WebDavStreamResponse" />.</returns>
        Task<WebDavStreamResponse> GetProcessedFile(string requestUri, GetParameters parameters);

        /// <summary>
        /// Retrieves the file identified by the request URI telling the server to return a processed response, if possible.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="parameters">Parameters of the GET operation.</param>
        /// <returns>An instance of <see cref="WebDavStreamResponse" />.</returns>
        Task<WebDavStreamResponse> GetProcessedFile(Uri requestUri, GetParameters parameters);

        /// <summary>
        /// Retrieves the raw http response of a file identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="translate">A parameter indicating if the response can be processed by the web server.</param>
        /// <param name="parameters">Parameters of the GET operation.</param>
        /// <returns>An instance of <see cref="HttpResponseMessage" />.</returns>
        Task<HttpResponseMessage> GetFileResponse(Uri requestUri, bool translate, GetParameters parameters);

        /// <summary>
        /// Deletes the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Delete(string requestUri);

        /// <summary>
        /// Deletes the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Delete(Uri requestUri);

        /// <summary>
        /// Deletes the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="parameters">Parameters of the DELETE operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Delete(string requestUri, DeleteParameters parameters);

        /// <summary>
        /// Deletes the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="parameters">Parameters of the DELETE operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Delete(Uri requestUri, DeleteParameters parameters);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="stream">The stream of content of the resource.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(string requestUri, Stream stream);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="stream">The stream of content of the resource.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(Uri requestUri, Stream stream);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="stream">The stream of content of the resource.</param>
        /// <param name="contentType">The content type of the request body.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(string requestUri, Stream stream, string contentType);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="stream">The stream of content of the resource.</param>
        /// <param name="contentType">The content type of the request body.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(Uri requestUri, Stream stream, string contentType);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="stream">The stream of content of the resource.</param>
        /// <param name="parameters">Parameters of the PUT operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(string requestUri, Stream stream, PutFileParameters parameters);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="stream">The stream of content of the resource.</param>
        /// <param name="parameters">Parameters of the PUT operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(Uri requestUri, Stream stream, PutFileParameters parameters);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="content">The content to pass to the request.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(string requestUri, HttpContent content);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="content">The content to pass to the request.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(Uri requestUri, HttpContent content);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="content">The content to pass to the request.</param>
        /// <param name="parameters">Parameters of the PUT operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(string requestUri, HttpContent content, PutFileParameters parameters);

        /// <summary>
        /// Requests the resource to be stored under the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="content">The content to pass to the request.</param>
        /// <param name="parameters">Parameters of the PUT operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> PutFile(Uri requestUri, HttpContent content, PutFileParameters parameters);

        /// <summary>
        /// Creates a duplicate of the source resource identified by the source URI in the destination resource identified by the destination URI.
        /// </summary>
        /// <param name="sourceUri">A string that represents the source URI.</param>
        /// <param name="destinationUri">A string that represents the destination URI.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Copy(string sourceUri, string destinationUri);

        /// <summary>
        /// Creates a duplicate of the source resource identified by the source URI in the destination resource identified by the destination URI.
        /// </summary>
        /// <param name="sourceUri">The source <see cref="Uri"/>.</param>
        /// <param name="destinationUri">The destination <see cref="Uri"/>.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Copy(Uri sourceUri, Uri destinationUri);

        /// <summary>
        /// Creates a duplicate of the source resource identified by the source URI in the destination resource identified by the destination URI.
        /// </summary>
        /// <param name="sourceUri">A string that represents the source URI.</param>
        /// <param name="destinationUri">A string that represents the destination URI.</param>
        /// <param name="parameters">Parameters of the COPY operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Copy(string sourceUri, string destinationUri, CopyParameters parameters);

        /// <summary>
        /// Creates a duplicate of the source resource identified by the source URI in the destination resource identified by the destination URI.
        /// </summary>
        /// <param name="sourceUri">The source <see cref="Uri"/>.</param>
        /// <param name="destinationUri">The destination <see cref="Uri"/>.</param>
        /// <param name="parameters">Parameters of the COPY operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" /></returns>
        Task<WebDavResponse> Copy(Uri sourceUri, Uri destinationUri, CopyParameters parameters);

        /// <summary>
        /// Moves the resource identified by the source URI to the destination identified by the destination URI.
        /// </summary>
        /// <param name="sourceUri">A string that represents the source URI.</param>
        /// <param name="destUri">A string that represents the destination URI.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Move(string sourceUri, string destUri);

        /// <summary>
        /// Moves the resource identified by the source URI to the destination identified by the destination URI.
        /// </summary>
        /// <param name="sourceUri">The source <see cref="Uri"/>.</param>
        /// <param name="destUri">The destination <see cref="Uri"/>.</param>
        /// <returns>An instance of <see cref="WebDavResponse" /></returns>
        Task<WebDavResponse> Move(Uri sourceUri, Uri destUri);

        /// <summary>
        /// Moves the resource identified by the source URI to the destination identified by the destination URI.
        /// </summary>
        /// <param name="sourceUri">A string that represents the source URI.</param>
        /// <param name="destUri">A string that represents the destination URI.</param>
        /// <param name="parameters">Parameters of the MOVE operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Move(string sourceUri, string destUri, MoveParameters parameters);

        /// <summary>
        /// Moves the resource identified by the source URI to the destination identified by the destination URI.
        /// </summary>
        /// <param name="sourceUri">The source <see cref="Uri"/>.</param>
        /// <param name="destUri">The destination <see cref="Uri"/>.</param>
        /// <param name="parameters">Parameters of the MOVE operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Move(Uri sourceUri, Uri destUri, MoveParameters parameters);

        /// <summary>
        /// Takes out a shared lock or refreshes an existing lock of the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <returns>An instance of <see cref="LockResponse" />.</returns>
        Task<LockResponse> Lock(string requestUri);

        /// <summary>
        /// Takes out a shared lock or refreshes an existing lock of the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <returns>An instance of <see cref="LockResponse" />.</returns>
        Task<LockResponse> Lock(Uri requestUri);

        /// <summary>
        /// Takes out a lock of any type or refreshes an existing lock of the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="parameters">Parameters of the LOCK operation.</param>
        /// <returns>An instance of <see cref="LockResponse" />.</returns>
        Task<LockResponse> Lock(string requestUri, LockParameters parameters);

        /// <summary>
        /// Takes out a lock of any type or refreshes an existing lock of the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="parameters">Parameters of the LOCK operation.</param>
        /// <returns>An instance of <see cref="LockResponse" />.</returns>
        Task<LockResponse> Lock(Uri requestUri, LockParameters parameters);

        /// <summary>
        /// Removes the lock identified by the lock token from the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="lockToken">The resource lock token.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Unlock(string requestUri, string lockToken);

        /// <summary>
        /// Removes the lock identified by the lock token from the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="lockToken">The resource lock token.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Unlock(Uri requestUri, string lockToken);

        /// <summary>
        /// Removes the lock identified by the lock token from the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">A string that represents the request URI.</param>
        /// <param name="parameters">Parameters of the UNLOCK operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Unlock(string requestUri, UnlockParameters parameters);

        /// <summary>
        /// Removes the lock identified by the lock token from the resource identified by the request URI.
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> to request.</param>
        /// <param name="parameters">Parameters of the UNLOCK operation.</param>
        /// <returns>An instance of <see cref="WebDavResponse" />.</returns>
        Task<WebDavResponse> Unlock(Uri requestUri, UnlockParameters parameters);
    }
}
