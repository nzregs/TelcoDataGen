using System.Collections.Generic;
using TelcoDataGen.model;

namespace TelcoDataGen
{
    public static class SampleData_Websites
    {
        public static IEnumerable<Website> GetWebsites()
        {
            yield return new Website { Uri = "facebook.com", Name = "Facebook" };
            yield return new Website { Uri = "twitter.com", Name = "Twitter" };
            yield return new Website { Uri = "skype.com", Name = "Skype" };
        }
    }
}
