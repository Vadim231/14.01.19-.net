using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class NewContext: DbContext
    {
        public NewContext(): base("DbConnection")
        { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
