using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
    }


    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int Pages { get; set; }
        public decimal Cost { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }
    }

}
