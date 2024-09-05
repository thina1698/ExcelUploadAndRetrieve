using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Model.RequestModels
{
    public class MappingRequestModel
    {
        public int MappingId {  get; set; }
        public int CustomerId { get; set; }
        public List<int> ProductId { get; set; }
    }
}
