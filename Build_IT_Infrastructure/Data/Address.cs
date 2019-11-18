using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Infrastructure.Data
{
    public class Address
    {
#if DEBUG
        public const string Url = "https://localhost:44322/";
#elif TRACE
        public const string Url = "http://building-it.net/";
#endif
    }
}
