namespace SportStyleOasis.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            string serializedValue = JsonConvert.SerializeObject(value);
            session.SetString(key, serializedValue);
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            string? serializedValue = session.GetString(key);
            return serializedValue != null ? JsonConvert.DeserializeObject<T>(serializedValue) : default;
        }
    }
}
