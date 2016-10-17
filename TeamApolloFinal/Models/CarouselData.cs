using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamApolloFinal.Models
{
    public class CarouselData
    {
        //<div class="item"><a href = "https://www.github.com" target="_blank"><img src = "~/Content/Images/github.jpg" alt="Owl Image"></a></div>
        public string linkUrl { get; set; }
        public string src { get; set; }
        public string alt { get; set; }
    }
}