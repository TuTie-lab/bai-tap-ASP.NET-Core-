using Bai_3.Models;

namespace Bai_3.Data
{
    public class Data
    {
        public List<Category> categories = new List<Category>
        {
            new Category (){Id=1,Name ="smartphone"},
            new Category (){Id=2,Name ="book"}

        };
        public static List<Pooduct> product = new List<Pooduct>
        {
            new Pooduct() {Id =1, Name = "table",Price = 10000, Description="new",CategroryId=1},
          new Pooduct() {Id =1, Name = "phone",Price = 10000, Description="new",CategroryId=1},
          new Pooduct() {Id =1, Name = "book",Price = 10000, Description="new",CategroryId=2},
          new Pooduct() {Id =1, Name = "pen",Price = 10000, Description="new",CategroryId=2},

        };
    }
}
