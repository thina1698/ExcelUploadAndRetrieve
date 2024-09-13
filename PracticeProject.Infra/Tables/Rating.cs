using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Infra.Tables
{
    public class Rating
    {
        public int RatingId {  get; set; }
        public int ProductId { get; set; }
        public int CustomerId {  get; set; }
        public string Comments {  get; set; }
        public int ProductRating {  get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
