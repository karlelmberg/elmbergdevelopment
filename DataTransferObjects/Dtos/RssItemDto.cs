using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.Dtos
{
    public class RssItemDto
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string PublicationDate { get; set; }
    }
}
