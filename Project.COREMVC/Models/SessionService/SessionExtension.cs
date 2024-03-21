using Newtonsoft.Json;

namespace Project.COREMVC.Models.SessionService
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session,string key, object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }

        public static T GetObject<T>(this ISession session,string key)
        {
            string objectstring = session.GetString(key);
            if(!string.IsNullOrEmpty(objectstring))
            {
                T deserializedObject = JsonConvert.DeserializeObject<T>(objectstring);
            }
        }
    }
}
