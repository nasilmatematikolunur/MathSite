using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class StringHelper
    {
        public static string TitleToSlug(string title)
        {
            return title.ToLower().Replace(" ", "_");
        }
    }
}
