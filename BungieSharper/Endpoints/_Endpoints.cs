using BungieSharper.Client;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        private readonly ApiAccessor _apiAccessor;

        internal Endpoints(ApiAccessor apiAccessor)
        {
            _apiAccessor = apiAccessor;
        }
    }
}
