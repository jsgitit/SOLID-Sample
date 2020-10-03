using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating
{
    public class JsonPolicySerializer
    {
        // returns hydrated Policy object from the input string
        public Policy GetPolicyFromJsonString(string jsonPolicy)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonPolicy,
                new StringEnumConverter());
        }
    }
}