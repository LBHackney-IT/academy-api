using System.Collections.Generic;

namespace AcademyApi.V1.Boundary.Response
{
    public class SearchResponseObjectList
    {
#nullable enable
        public List<SearchResponseObject>? Customers { get; set; }
#nullable disable
        public string Error { get; set; }
    }
}
