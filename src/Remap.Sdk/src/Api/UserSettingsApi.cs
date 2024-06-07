using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Настройки пользователя
    /// </summary>
    public class UserSettingsApi : ApiAccessor
    {
        /// <summary>
        /// Creates a new instance of the <see cref="UserSettingsApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public UserSettingsApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/usersettings", httpClient, credentials)
        {
        }

        /// <summary>
        /// Получить настройки текущего пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<UserSettings> Get()
        {
            var requestContext = new RequestContext(Path, HttpMethod.Get);

            var httpResponse = await InternalCallAsync(requestContext);
            var result = (UserSettings)await DeserializeAsync(httpResponse, typeof(UserSettings));
            return result ?? null;
        }
    }
}
