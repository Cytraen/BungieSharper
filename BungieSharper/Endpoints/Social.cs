using BungieSharper.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns your Bungie Friend list
        /// Requires OAuth2 scope(s): ReadUserData
        /// </summary>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Social.Friends.BungieFriendListResponse> Social_GetFriendList(string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Social.Friends.BungieFriendListResponse>(
                new Uri($"Social/Friends/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Returns your friend request queue.
        /// Requires OAuth2 scope(s): ReadUserData
        /// </summary>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Social.Friends.BungieFriendRequestListResponse> Social_GetFriendRequestList(string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Social.Friends.BungieFriendRequestListResponse>(
                new Uri($"Social/Friends/Requests/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }

        /// <summary>
        /// Requests a friend relationship with the target user. Any of the target user's linked membership ids are valid inputs.
        /// Requires OAuth2 scope(s): BnetWrite
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to add.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<bool> Social_IssueFriendRequest(string membershipId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"Social/Friends/Add/{Uri.EscapeDataString(membershipId)}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Accepts a friend relationship with the target user. The user must be on your incoming friend request list, though no error will occur if they are not.
        /// Requires OAuth2 scope(s): BnetWrite
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to accept.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<bool> Social_AcceptFriendRequest(string membershipId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"Social/Friends/Requests/Accept/{Uri.EscapeDataString(membershipId)}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Declines a friend relationship with the target user. The user must be on your incoming friend request list, though no error will occur if they are not.
        /// Requires OAuth2 scope(s): BnetWrite
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to decline.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<bool> Social_DeclineFriendRequest(string membershipId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"Social/Friends/Requests/Decline/{Uri.EscapeDataString(membershipId)}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Remove a friend relationship with the target user. The user must be on your friend list, though no error will occur if they are not.
        /// Requires OAuth2 scope(s): BnetWrite
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to remove.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<bool> Social_RemoveFriend(string membershipId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"Social/Friends/Remove/{Uri.EscapeDataString(membershipId)}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Remove a friend relationship with the target user. The user must be on your outgoing request friend list, though no error will occur if they are not.
        /// Requires OAuth2 scope(s): BnetWrite
        /// </summary>
        /// <param name="membershipId">The membership id of the user you wish to remove.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<bool> Social_RemoveFriendRequest(string membershipId, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<bool>(
                new Uri($"Social/Friends/Requests/Remove/{Uri.EscapeDataString(membershipId)}/", UriKind.Relative),
                null, HttpMethod.Post, authToken, cancelToken
                );
        }

        /// <summary>
        /// Gets the platform friend of the requested type, with additional information if they have Bungie accounts. Must have a recent login session with said platform.
        /// </summary>
        /// <param name="friendPlatform">The platform friend type.</param>
        /// <param name="page">The zero based page to return. Page size is 100.</param>
        /// <param name="authToken">The OAuth access token to autheticate the request with.</param>
        /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
        public Task<Entities.Social.Friends.PlatformFriendResponse> Social_GetPlatformFriendList(Entities.Social.Friends.PlatformFriendType friendPlatform, string page, string? authToken = null, CancellationToken cancelToken = default)
        {
            return _apiAccessor.ApiRequestAsync<Entities.Social.Friends.PlatformFriendResponse>(
                new Uri($"Social/PlatformFriends/{friendPlatform}/{Uri.EscapeDataString(page)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, cancelToken
                );
        }
    }
}