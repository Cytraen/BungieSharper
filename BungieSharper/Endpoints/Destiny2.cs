using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints;

public partial class Endpoints
{
    /// <summary>
    /// Returns the current version of the manifest as a json object.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Config.DestinyManifest> Destiny2_GetDestinyManifest(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Config.DestinyManifest>(
            new Uri($"Destiny2/Manifest/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetDestinyManifest(string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetDestinyManifest<T>(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Manifest/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns the static definition of an entity of the given Type and hash identifier. Examine the API Documentation for the Type Names of entities that have their own definitions. Note that the return type will always *inherit from* DestinyDefinition, but the specific type returned will be the requested entity type if it can be found. Please don't use this as a chatty alternative to the Manifest database if you require large sets of data, but for simple and one-off accesses this should be handy.
    /// </summary>
    /// <param name="entityType">The type of entity for whom you would like results. These correspond to the entity's definition contract name. For instance, if you are looking for items, this property should be 'DestinyInventoryItemDefinition'. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is tentatively in final form, but there may be bugs that prevent desirable operation.</param>
    /// <param name="hashIdentifier">The hash identifier for the specific Entity you want returned.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Definitions.DestinyDefinition> Destiny2_GetDestinyEntityDefinition(string entityType, uint hashIdentifier, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Definitions.DestinyDefinition>(
            new Uri($"Destiny2/Manifest/{Uri.EscapeDataString(entityType)}/{hashIdentifier}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetDestinyEntityDefinition(string, uint, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetDestinyEntityDefinition<T>(string entityType, uint hashIdentifier, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Manifest/{Uri.EscapeDataString(entityType)}/{hashIdentifier}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns a list of Destiny memberships given a global Bungie Display Name. This method will hide overridden memberships due to cross save.
    /// </summary>
    /// <param name="membershipType">A valid non-BungieNet membership type, or All. Indicates which memberships to return. You probably want this set to All.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<IEnumerable<Entities.User.UserInfoCard>> Destiny2_SearchDestinyPlayerByBungieName(Entities.BungieMembershipType membershipType, Entities.User.ExactSearchRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.User.UserInfoCard>>(
            new Uri($"Destiny2/SearchDestinyPlayerByBungieName/{membershipType}/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_SearchDestinyPlayerByBungieName(Entities.BungieMembershipType, Entities.User.ExactSearchRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_SearchDestinyPlayerByBungieName<T>(Entities.BungieMembershipType membershipType, Entities.User.ExactSearchRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/SearchDestinyPlayerByBungieName/{membershipType}/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns a summary information about all profiles linked to the requesting membership type/membership ID that have valid Destiny information. The passed-in Membership Type/Membership ID may be a Bungie.Net membership or a Destiny membership. It only returns the minimal amount of data to begin making more substantive requests, but will hopefully serve as a useful alternative to UserServices for people who just care about Destiny data. Note that it will only return linked accounts whose linkages you are allowed to view.
    /// </summary>
    /// <param name="getAllMemberships">(optional) if set to 'true', all memberships regardless of whether they're obscured by overrides will be returned. Normal privacy restrictions on account linking will still apply no matter what.</param>
    /// <param name="membershipId">The ID of the membership whose linked Destiny accounts you want returned. Make sure your membership ID matches its Membership Type: don't pass us a PSN membership ID and the XBox membership type, it's not going to work!</param>
    /// <param name="membershipType">The type for the membership whose linked Destiny accounts you want returned.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyLinkedProfilesResponse> Destiny2_GetLinkedProfiles(long membershipId, Entities.BungieMembershipType membershipType, bool? getAllMemberships = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyLinkedProfilesResponse>(
            new Uri($"Destiny2/{membershipType}/Profile/{membershipId}/LinkedProfiles/" + HttpRequestGenerator.MakeQuerystring(getAllMemberships != null ? $"getAllMemberships={getAllMemberships}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetLinkedProfiles(long, Entities.BungieMembershipType, bool?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetLinkedProfiles<T>(long membershipId, Entities.BungieMembershipType membershipType, bool? getAllMemberships = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Profile/{membershipId}/LinkedProfiles/" + HttpRequestGenerator.MakeQuerystring(getAllMemberships != null ? $"getAllMemberships={getAllMemberships}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns Destiny Profile information for the supplied membership.
    /// </summary>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyProfileResponse> Destiny2_GetProfile(long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyProfileResponse>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetProfile(long, Entities.BungieMembershipType, IEnumerable<Entities.Destiny.DestinyComponentType>?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetProfile<T>(long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns character information for the supplied character.
    /// </summary>
    /// <param name="characterId">ID of the character.</param>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyCharacterResponse> Destiny2_GetCharacter(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyCharacterResponse>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetCharacter(long, long, Entities.BungieMembershipType, IEnumerable<Entities.Destiny.DestinyComponentType>?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetCharacter<T>(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always report rewards as not redeemed.
    /// </summary>
    /// <param name="groupId">A valid group id of clan.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Milestones.DestinyMilestone> Destiny2_GetClanWeeklyRewardState(long groupId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Milestones.DestinyMilestone>(
            new Uri($"Destiny2/Clan/{groupId}/WeeklyRewardState/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetClanWeeklyRewardState(long, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetClanWeeklyRewardState<T>(long groupId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Clan/{groupId}/WeeklyRewardState/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns the dictionary of values for the Clan Banner
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Config.ClanBanner.ClanBannerSource> Destiny2_GetClanBannerSource(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Config.ClanBanner.ClanBannerSource>(
            new Uri($"Destiny2/Clan/ClanBannerDictionary/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetClanBannerSource(string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetClanBannerSource<T>(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Clan/ClanBannerDictionary/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Retrieve the details of an instanced Destiny Item. An instanced Destiny item is one with an ItemInstanceId. Non-instanced items, such as materials, have no useful instance-specific details and thus are not queryable here.
    /// </summary>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">The membership ID of the destiny profile.</param>
    /// <param name="itemInstanceId">The Instance ID of the destiny item.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyItemResponse> Destiny2_GetItem(long destinyMembershipId, long itemInstanceId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyItemResponse>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Item/{itemInstanceId}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetItem(long, long, Entities.BungieMembershipType, IEnumerable<Entities.Destiny.DestinyComponentType>?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetItem<T>(long destinyMembershipId, long itemInstanceId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Item/{itemInstanceId}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Get currently available vendors from the list of vendors that can possibly have rotating inventory. Note that this does not include things like preview vendors and vendors-as-kiosks, neither of whom have rotating/dynamic inventories. Use their definitions as-is for those.
    /// </summary>
    /// <param name="characterId">The Destiny Character ID of the character for whom we're getting vendor info.</param>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
    /// <param name="filter">The filter of what vendors and items to return, if any.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyVendorsResponse> Destiny2_GetVendors(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, Entities.Destiny.DestinyVendorFilter? filter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyVendorsResponse>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null, filter != null ? $"filter={filter}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetVendors(long, long, Entities.BungieMembershipType, IEnumerable<Entities.Destiny.DestinyComponentType>?, Entities.Destiny.DestinyVendorFilter?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetVendors<T>(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, Entities.Destiny.DestinyVendorFilter? filter = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null, filter != null ? $"filter={filter}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Get the details of a specific Vendor.
    /// </summary>
    /// <param name="characterId">The Destiny Character ID of the character for whom we're getting vendor info.</param>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="vendorHash">The Hash identifier of the Vendor to be returned.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyVendorResponse> Destiny2_GetVendor(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, uint vendorHash, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyVendorResponse>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetVendor(long, long, Entities.BungieMembershipType, uint, IEnumerable<Entities.Destiny.DestinyComponentType>?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetVendor<T>(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, uint vendorHash, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Get items available from vendors where the vendors have items for sale that are common for everyone. If any portion of the Vendor's available inventory is character or account specific, we will be unable to return their data from this endpoint due to the way that available inventory is computed. As I am often guilty of saying: 'It's a long story...'
    /// </summary>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyPublicVendorsResponse> Destiny2_GetPublicVendors(IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyPublicVendorsResponse>(
            new Uri($"Destiny2/Vendors/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetPublicVendors(IEnumerable<Entities.Destiny.DestinyComponentType>?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetPublicVendors<T>(IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Vendors/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Given a Presentation Node that has Collectibles as direct descendants, this will return item details about those descendants in the context of the requesting character.
    /// </summary>
    /// <param name="characterId">The Destiny Character ID of the character for whom we're getting collectible detail info.</param>
    /// <param name="collectiblePresentationNodeHash">The hash identifier of the Presentation Node for whom we should return collectible details. Details will only be returned for collectibles that are direct descendants of this node.</param>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyCollectibleNodeDetailResponse> Destiny2_GetCollectibleNodeDetails(long characterId, uint collectiblePresentationNodeHash, long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyCollectibleNodeDetailResponse>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Collectibles/{collectiblePresentationNodeHash}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetCollectibleNodeDetails(long, uint, long, Entities.BungieMembershipType, IEnumerable<Entities.Destiny.DestinyComponentType>?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetCollectibleNodeDetails<T>(long characterId, uint collectiblePresentationNodeHash, long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Collectibles/{collectiblePresentationNodeHash}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Transfer an item to/from your vault. You must have a valid Destiny account. You must also pass BOTH a reference AND an instance ID if it's an instanced item. itshappening.gif
    /// Requires OAuth2 scope(s): MoveEquipDestinyItems
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<int> Destiny2_TransferItem(Entities.Destiny.Requests.DestinyItemTransferRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<int>(
            new Uri($"Destiny2/Actions/Items/TransferItem/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_TransferItem(Entities.Destiny.Requests.DestinyItemTransferRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_TransferItem<T>(Entities.Destiny.Requests.DestinyItemTransferRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Actions/Items/TransferItem/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Extract an item from the Postmaster, with whatever implications that may entail. You must have a valid Destiny account. You must also pass BOTH a reference AND an instance ID if it's an instanced item.
    /// Requires OAuth2 scope(s): MoveEquipDestinyItems
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<int> Destiny2_PullFromPostmaster(Entities.Destiny.Requests.Actions.DestinyPostmasterTransferRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<int>(
            new Uri($"Destiny2/Actions/Items/PullFromPostmaster/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_PullFromPostmaster(Entities.Destiny.Requests.Actions.DestinyPostmasterTransferRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_PullFromPostmaster<T>(Entities.Destiny.Requests.Actions.DestinyPostmasterTransferRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Actions/Items/PullFromPostmaster/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Equip an item. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline.
    /// Requires OAuth2 scope(s): MoveEquipDestinyItems
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<int> Destiny2_EquipItem(Entities.Destiny.Requests.Actions.DestinyItemActionRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<int>(
            new Uri($"Destiny2/Actions/Items/EquipItem/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_EquipItem(Entities.Destiny.Requests.Actions.DestinyItemActionRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_EquipItem<T>(Entities.Destiny.Requests.Actions.DestinyItemActionRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Actions/Items/EquipItem/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Equip a list of items by itemInstanceIds. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline. Any items not found on your character will be ignored.
    /// Requires OAuth2 scope(s): MoveEquipDestinyItems
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.DestinyEquipItemResults> Destiny2_EquipItems(Entities.Destiny.Requests.Actions.DestinyItemSetActionRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.DestinyEquipItemResults>(
            new Uri($"Destiny2/Actions/Items/EquipItems/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_EquipItems(Entities.Destiny.Requests.Actions.DestinyItemSetActionRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_EquipItems<T>(Entities.Destiny.Requests.Actions.DestinyItemSetActionRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Actions/Items/EquipItems/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Set the Lock State for an instanced item. You must have a valid Destiny Account.
    /// Requires OAuth2 scope(s): MoveEquipDestinyItems
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<int> Destiny2_SetItemLockState(Entities.Destiny.Requests.Actions.DestinyItemStateRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<int>(
            new Uri($"Destiny2/Actions/Items/SetLockState/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_SetItemLockState(Entities.Destiny.Requests.Actions.DestinyItemStateRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_SetItemLockState<T>(Entities.Destiny.Requests.Actions.DestinyItemStateRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Actions/Items/SetLockState/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Set the Tracking State for an instanced item, if that item is a Quest or Bounty. You must have a valid Destiny Account. Yeah, it's an item.
    /// Requires OAuth2 scope(s): MoveEquipDestinyItems
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<int> Destiny2_SetQuestTrackedState(Entities.Destiny.Requests.Actions.DestinyItemStateRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<int>(
            new Uri($"Destiny2/Actions/Items/SetTrackedState/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_SetQuestTrackedState(Entities.Destiny.Requests.Actions.DestinyItemStateRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_SetQuestTrackedState<T>(Entities.Destiny.Requests.Actions.DestinyItemStateRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Actions/Items/SetTrackedState/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Insert a plug into a socketed item. I know how it sounds, but I assure you it's much more G-rated than you might be guessing. We haven't decided yet whether this will be able to insert plugs that have side effects, but if we do it will require special scope permission for an application attempting to do so. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline. Request must include proof of permission for 'InsertPlugs' from the account owner.
    /// Requires OAuth2 scope(s): AdvancedWriteActions
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyItemChangeResponse> Destiny2_InsertSocketPlug(Entities.Destiny.Requests.Actions.DestinyInsertPlugsActionRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyItemChangeResponse>(
            new Uri($"Destiny2/Actions/Items/InsertSocketPlug/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_InsertSocketPlug(Entities.Destiny.Requests.Actions.DestinyInsertPlugsActionRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_InsertSocketPlug<T>(Entities.Destiny.Requests.Actions.DestinyInsertPlugsActionRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Actions/Items/InsertSocketPlug/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Insert a 'free' plug into an item's socket. This does not require 'Advanced Write Action' authorization and is available to 3rd-party apps, but will only work on 'free and reversible' socket actions (Perks, Armor Mods, Shaders, Ornaments, etc.). You must have a valid Destiny Account, and the character must either be in a social space, in orbit, or offline.
    /// Requires OAuth2 scope(s): MoveEquipDestinyItems
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Responses.DestinyItemChangeResponse> Destiny2_InsertSocketPlugFree(Entities.Destiny.Requests.Actions.DestinyInsertPlugsFreeActionRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyItemChangeResponse>(
            new Uri($"Destiny2/Actions/Items/InsertSocketPlugFree/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_InsertSocketPlugFree(Entities.Destiny.Requests.Actions.DestinyInsertPlugsFreeActionRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_InsertSocketPlugFree<T>(Entities.Destiny.Requests.Actions.DestinyInsertPlugsFreeActionRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Actions/Items/InsertSocketPlugFree/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets the available post game carnage report for the activity ID.
    /// </summary>
    /// <param name="activityId">The ID of the activity whose PGCR is requested.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.HistoricalStats.DestinyPostGameCarnageReportData> Destiny2_GetPostGameCarnageReport(long activityId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.HistoricalStats.DestinyPostGameCarnageReportData>(
            new Uri($"Destiny2/Stats/PostGameCarnageReport/{activityId}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetPostGameCarnageReport(long, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetPostGameCarnageReport<T>(long activityId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Stats/PostGameCarnageReport/{activityId}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Report a player that you met in an activity that was engaging in ToS-violating activities. Both you and the offending player must have played in the activityId passed in. Please use this judiciously and only when you have strong suspicions of violation, pretty please.
    /// Requires OAuth2 scope(s): BnetWrite
    /// </summary>
    /// <param name="activityId">The ID of the activity where you ran into the brigand that you're reporting.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<int> Destiny2_ReportOffensivePostGameCarnageReportPlayer(long activityId, Entities.Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<int>(
            new Uri($"Destiny2/Stats/PostGameCarnageReport/{activityId}/Report/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_ReportOffensivePostGameCarnageReportPlayer(long, Entities.Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_ReportOffensivePostGameCarnageReportPlayer<T>(long activityId, Entities.Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Stats/PostGameCarnageReport/{activityId}/Report/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets historical stats definitions.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, Entities.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>> Destiny2_GetHistoricalStatsDefinition(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Dictionary<string, Entities.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>>(
            new Uri($"Destiny2/Stats/Definition/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetHistoricalStatsDefinition(string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetHistoricalStatsDefinition<T>(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Stats/Definition/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
    /// </summary>
    /// <param name="groupId">Group ID of the clan whose leaderboards you wish to fetch.</param>
    /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
    /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, Dictionary<string, Entities.Destiny.HistoricalStats.DestinyLeaderboard>>> Destiny2_GetClanLeaderboards(long groupId, int? maxtop = null, string? modes = null, string? statid = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Dictionary<string, Dictionary<string, Entities.Destiny.HistoricalStats.DestinyLeaderboard>>>(
            new Uri($"Destiny2/Stats/Leaderboards/Clans/{groupId}/" + HttpRequestGenerator.MakeQuerystring(maxtop != null ? $"maxtop={maxtop}" : null, modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null, statid != null ? $"statid={Uri.EscapeDataString(statid)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetClanLeaderboards(long, int?, string?, string?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetClanLeaderboards<T>(long groupId, int? maxtop = null, string? modes = null, string? statid = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Stats/Leaderboards/Clans/{groupId}/" + HttpRequestGenerator.MakeQuerystring(maxtop != null ? $"maxtop={maxtop}" : null, modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null, statid != null ? $"statid={Uri.EscapeDataString(statid)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets aggregated stats for a clan using the same categories as the clan leaderboards. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
    /// </summary>
    /// <param name="groupId">Group ID of the clan whose leaderboards you wish to fetch.</param>
    /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<IEnumerable<Entities.Destiny.HistoricalStats.DestinyClanAggregateStat>> Destiny2_GetClanAggregateStats(long groupId, string? modes = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Destiny.HistoricalStats.DestinyClanAggregateStat>>(
            new Uri($"Destiny2/Stats/AggregateClanStats/{groupId}/" + HttpRequestGenerator.MakeQuerystring(modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetClanAggregateStats(long, string?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetClanAggregateStats<T>(long groupId, string? modes = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Stats/AggregateClanStats/{groupId}/" + HttpRequestGenerator.MakeQuerystring(modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus. PREVIEW: This endpoint has not yet been implemented. It is being returned for a preview of future functionality, and for public comment/suggestion/preparation.
    /// </summary>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, Dictionary<string, Entities.Destiny.HistoricalStats.DestinyLeaderboard>>> Destiny2_GetLeaderboards(long destinyMembershipId, Entities.BungieMembershipType membershipType, int? maxtop = null, string? modes = null, string? statid = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Dictionary<string, Dictionary<string, Entities.Destiny.HistoricalStats.DestinyLeaderboard>>>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/Leaderboards/" + HttpRequestGenerator.MakeQuerystring(maxtop != null ? $"maxtop={maxtop}" : null, modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null, statid != null ? $"statid={Uri.EscapeDataString(statid)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetLeaderboards(long, Entities.BungieMembershipType, int?, string?, string?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetLeaderboards<T>(long destinyMembershipId, Entities.BungieMembershipType membershipType, int? maxtop = null, string? modes = null, string? statid = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/Leaderboards/" + HttpRequestGenerator.MakeQuerystring(maxtop != null ? $"maxtop={maxtop}" : null, modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null, statid != null ? $"statid={Uri.EscapeDataString(statid)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
    /// </summary>
    /// <param name="characterId">The specific character to build the leaderboard around for the provided Destiny Membership.</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, Dictionary<string, Entities.Destiny.HistoricalStats.DestinyLeaderboard>>> Destiny2_GetLeaderboardsForCharacter(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, int? maxtop = null, string? modes = null, string? statid = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Dictionary<string, Dictionary<string, Entities.Destiny.HistoricalStats.DestinyLeaderboard>>>(
            new Uri($"Destiny2/Stats/Leaderboards/{membershipType}/{destinyMembershipId}/{characterId}/" + HttpRequestGenerator.MakeQuerystring(maxtop != null ? $"maxtop={maxtop}" : null, modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null, statid != null ? $"statid={Uri.EscapeDataString(statid)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetLeaderboardsForCharacter(long, long, Entities.BungieMembershipType, int?, string?, string?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetLeaderboardsForCharacter<T>(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, int? maxtop = null, string? modes = null, string? statid = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Stats/Leaderboards/{membershipType}/{destinyMembershipId}/{characterId}/" + HttpRequestGenerator.MakeQuerystring(maxtop != null ? $"maxtop={maxtop}" : null, modes != null ? $"modes={Uri.EscapeDataString(modes)}" : null, statid != null ? $"statid={Uri.EscapeDataString(statid)}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets a page list of Destiny items.
    /// </summary>
    /// <param name="page">Page number to return, starting with 0.</param>
    /// <param name="searchTerm">The string to use when searching for Destiny entities.</param>
    /// <param name="type">The type of entity for whom you would like results. These correspond to the entity's definition contract name. For instance, if you are looking for items, this property should be 'DestinyInventoryItemDefinition'.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Definitions.DestinyEntitySearchResult> Destiny2_SearchDestinyEntities(string searchTerm, string type, int? page = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Definitions.DestinyEntitySearchResult>(
            new Uri($"Destiny2/Armory/Search/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(searchTerm)}/" + HttpRequestGenerator.MakeQuerystring(page != null ? $"page={page}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_SearchDestinyEntities(string, string, int?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_SearchDestinyEntities<T>(string searchTerm, string type, int? page = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Armory/Search/{Uri.EscapeDataString(type)}/{Uri.EscapeDataString(searchTerm)}/" + HttpRequestGenerator.MakeQuerystring(page != null ? $"page={page}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets historical stats for indicated character.
    /// </summary>
    /// <param name="characterId">The id of the character to retrieve. You can omit this character ID or set it to 0 to get aggregate stats across all characters.</param>
    /// <param name="dayend">Last day to return when daily stats are requested. Use the format YYYY-MM-DD. Currently, we cannot allow more than 31 days of daily data to be requested in a single request.</param>
    /// <param name="daystart">First day to return when daily stats are requested. Use the format YYYY-MM-DD. Currently, we cannot allow more than 31 days of daily data to be requested in a single request.</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="groups">Group of stats to include, otherwise only general stats are returned. Comma separated list is allowed. Values: General, Weapons, Medals</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="modes">Game modes to return. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="periodType">Indicates a specific period type to return. Optional. May be: Daily, AllTime, or Activity</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, Entities.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>> Destiny2_GetHistoricalStats(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, DateTime? dayend = null, DateTime? daystart = null, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType>? groups = null, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyActivityModeType>? modes = null, Entities.Destiny.HistoricalStats.Definitions.PeriodType? periodType = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Dictionary<string, Entities.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/" + HttpRequestGenerator.MakeQuerystring(dayend != null ? $"dayend={dayend}" : null, daystart != null ? $"daystart={daystart}" : null, groups != null ? $"groups={string.Join(",", groups.Select(x => x.ToString()))}" : null, modes != null ? $"modes={string.Join(",", modes.Select(x => x.ToString()))}" : null, periodType != null ? $"periodType={periodType}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetHistoricalStats(long, long, Entities.BungieMembershipType, DateTime?, DateTime?, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType>?, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyActivityModeType>?, Entities.Destiny.HistoricalStats.Definitions.PeriodType?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetHistoricalStats<T>(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, DateTime? dayend = null, DateTime? daystart = null, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType>? groups = null, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyActivityModeType>? modes = null, Entities.Destiny.HistoricalStats.Definitions.PeriodType? periodType = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/" + HttpRequestGenerator.MakeQuerystring(dayend != null ? $"dayend={dayend}" : null, daystart != null ? $"daystart={daystart}" : null, groups != null ? $"groups={string.Join(",", groups.Select(x => x.ToString()))}" : null, modes != null ? $"modes={string.Join(",", modes.Select(x => x.ToString()))}" : null, periodType != null ? $"periodType={periodType}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets aggregate historical stats organized around each character for a given account.
    /// </summary>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="groups">Groups of stats to include, otherwise only general stats are returned. Comma separated list is allowed. Values: General, Weapons, Medals.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult> Destiny2_GetHistoricalStatsForAccount(long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType>? groups = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/" + HttpRequestGenerator.MakeQuerystring(groups != null ? $"groups={string.Join(",", groups.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetHistoricalStatsForAccount(long, Entities.BungieMembershipType, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType>?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetHistoricalStatsForAccount<T>(long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType>? groups = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/" + HttpRequestGenerator.MakeQuerystring(groups != null ? $"groups={string.Join(",", groups.Select(x => x.ToString()))}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets activity history stats for indicated character.
    /// </summary>
    /// <param name="characterId">The id of the character to retrieve.</param>
    /// <param name="count">Number of rows to return</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="mode">A filter for the activity mode to be returned. None returns all activities. See the documentation for DestinyActivityModeType for valid values, and pass in string representation.</param>
    /// <param name="page">Page number to return, starting with 0.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.HistoricalStats.DestinyActivityHistoryResults> Destiny2_GetActivityHistory(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, int? count = null, Entities.Destiny.HistoricalStats.Definitions.DestinyActivityModeType? mode = null, int? page = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.HistoricalStats.DestinyActivityHistoryResults>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/Activities/" + HttpRequestGenerator.MakeQuerystring(count != null ? $"count={count}" : null, mode != null ? $"mode={mode}" : null, page != null ? $"page={page}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetActivityHistory(long, long, Entities.BungieMembershipType, int?, Entities.Destiny.HistoricalStats.Definitions.DestinyActivityModeType?, int?, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetActivityHistory<T>(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, int? count = null, Entities.Destiny.HistoricalStats.Definitions.DestinyActivityModeType? mode = null, int? page = null, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/Activities/" + HttpRequestGenerator.MakeQuerystring(count != null ? $"count={count}" : null, mode != null ? $"mode={mode}" : null, page != null ? $"page={page}" : null), UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets details about unique weapon usage, including all exotic weapons.
    /// </summary>
    /// <param name="characterId">The id of the character to retrieve.</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.HistoricalStats.DestinyHistoricalWeaponStatsData> Destiny2_GetUniqueWeaponHistory(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.HistoricalStats.DestinyHistoricalWeaponStatsData>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/UniqueWeapons/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetUniqueWeaponHistory(long, long, Entities.BungieMembershipType, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetUniqueWeaponHistory<T>(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/UniqueWeapons/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets all activities the character has participated in together with aggregate statistics for those activities.
    /// </summary>
    /// <param name="characterId">The specific character whose activities should be returned.</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.HistoricalStats.DestinyAggregateActivityResults> Destiny2_GetDestinyAggregateActivityStats(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.HistoricalStats.DestinyAggregateActivityResults>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/AggregateActivityStats/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetDestinyAggregateActivityStats(long, long, Entities.BungieMembershipType, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetDestinyAggregateActivityStats<T>(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/AggregateActivityStats/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets custom localized content for the milestone of the given hash, if it exists.
    /// </summary>
    /// <param name="milestoneHash">The identifier for the milestone to be returned.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Milestones.DestinyMilestoneContent> Destiny2_GetPublicMilestoneContent(uint milestoneHash, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Milestones.DestinyMilestoneContent>(
            new Uri($"Destiny2/Milestones/{milestoneHash}/Content/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetPublicMilestoneContent(uint, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetPublicMilestoneContent<T>(uint milestoneHash, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Milestones/{milestoneHash}/Content/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Gets public information about currently available Milestones.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<uint, Entities.Destiny.Milestones.DestinyPublicMilestone>> Destiny2_GetPublicMilestones(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Dictionary<uint, Entities.Destiny.Milestones.DestinyPublicMilestone>>(
            new Uri($"Destiny2/Milestones/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_GetPublicMilestones(string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_GetPublicMilestones<T>(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Milestones/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Initialize a request to perform an advanced write action.
    /// Requires OAuth2 scope(s): AdvancedWriteActions
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Advanced.AwaInitializeResponse> Destiny2_AwaInitializeRequest(Entities.Destiny.Advanced.AwaPermissionRequested requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Advanced.AwaInitializeResponse>(
            new Uri($"Destiny2/Awa/Initialize/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_AwaInitializeRequest(Entities.Destiny.Advanced.AwaPermissionRequested, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_AwaInitializeRequest<T>(Entities.Destiny.Advanced.AwaPermissionRequested requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Awa/Initialize/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Provide the result of the user interaction. Called by the Bungie Destiny App to approve or reject a request.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<int> Destiny2_AwaProvideAuthorizationResult(Entities.Destiny.Advanced.AwaUserResponse requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<int>(
            new Uri($"Destiny2/Awa/AwaProvideAuthorizationResult/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_AwaProvideAuthorizationResult(Entities.Destiny.Advanced.AwaUserResponse, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_AwaProvideAuthorizationResult<T>(Entities.Destiny.Advanced.AwaUserResponse requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Awa/AwaProvideAuthorizationResult/", UriKind.Relative),
            new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns the action token if user approves the request.
    /// Requires OAuth2 scope(s): AdvancedWriteActions
    /// </summary>
    /// <param name="correlationId">The identifier for the advanced write action request.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Destiny.Advanced.AwaAuthorizationResult> Destiny2_AwaGetActionToken(string correlationId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<Entities.Destiny.Advanced.AwaAuthorizationResult>(
            new Uri($"Destiny2/Awa/GetActionToken/{Uri.EscapeDataString(correlationId)}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <inheritdoc cref="Destiny2_AwaGetActionToken(string, string?, CancellationToken)" />
    /// <typeparam name="T">The custom type to deserialize to.</typeparam>
    public Task<T> Destiny2_AwaGetActionToken<T>(string correlationId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync<T>(
            new Uri($"Destiny2/Awa/GetActionToken/{Uri.EscapeDataString(correlationId)}/", UriKind.Relative),
            null, HttpMethod.Get, authToken, cancelToken
            );
    }
}