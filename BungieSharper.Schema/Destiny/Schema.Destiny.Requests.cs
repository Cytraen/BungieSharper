namespace BungieSharper.Schema.Destiny.Requests
{
    public class DestinyItemTransferRequest
    {
        public uint itemReferenceHash { get; set; }

        public int stackSize { get; set; }

        public bool transferToVault { get; set; }

        public long itemId { get; set; }

        public long characterId { get; set; }

        public BungieMembershipType membershipType { get; set; }
    }
}