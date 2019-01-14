using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CommentTime { get; set; }

        public int? AutorId { get; set; }
        public Autor Autor { get; set; }

        public int? ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
