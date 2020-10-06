using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating
{
    public class JsonPolicySerializer
    {
        // returns hydrated Policy object from the input string

        // TODO: If Policy is unknown, we'll get an exception on Deserialization.
        // This needs a fix.
        public Policy GetPolicyFromJsonString(string jsonPolicy)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonPolicy,
                new StringEnumConverter());
        }
    }
}