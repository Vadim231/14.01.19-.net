using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class  Article
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public DateTime PublicationTime { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int? AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
