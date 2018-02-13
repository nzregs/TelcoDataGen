using System.Collections.Generic;
using TelcoDataGen.model;

namespace TelcoDataGen
{
    public static class SampleData_DataSpecials
    {
        public static IEnumerable<DataSpecial> GetDataSpecials()
        {
            yield return new DataSpecial { Uri = "facebook.com", Name = "Facebook", Offer = "free social networking", CostPerMB = "0" };
            yield return new DataSpecial { Uri = "twitter.com",Name="Twitter", Offer="free social networking", CostPerMB="0"};
            yield return new DataSpecial { Uri = "skype.com", Name="Skype", Offer="voip", CostPerMB="0.10" };
        }
    }
}
