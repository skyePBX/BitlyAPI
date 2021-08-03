using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitlyAPI
{
    public class BitlyBitlinksResponse
    {
        public BitlyPagination Pagination { get; set; }
        
        public List<BitlyLink> Links { get; set; }
    }
}