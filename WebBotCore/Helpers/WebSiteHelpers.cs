using System.Collections.Generic;
using System.Linq;
using WebBotCore.WebSite;

namespace WebBotCore.Helpers
{
    public static class WebSiteHelpers
    {
        public static T FirstOnTyppe<T, TDetails>(this IEnumerable<IDetailWebSite<TDetails>> enumerable) => (T)enumerable.First(d => d is T);
    }
}
