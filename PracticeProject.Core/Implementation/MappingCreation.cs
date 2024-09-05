using PracticeProject.Core.Interface;
using PracticeProject.Infra;
using PracticeProject.Infra.Tables;
using PracticeProject.Model.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.Implementation
{
    public class MappingCreation : IMappingCreation
    {
        private readonly PracticeDbContext _practiceDbcontext;

        public MappingCreation(PracticeDbContext practiceDbcontext)
        {
            _practiceDbcontext = practiceDbcontext;
        }
        public void CreateMapping(MappingRequestModel requestModel)
        {

            var customerProductMapping = requestModel.ProductId.Select(b => new Mapping()
            {
                CustomerId = requestModel.CustomerId,
                ProductId = b,
            });

            _practiceDbcontext.Mapping.AddRange(customerProductMapping);
            _practiceDbcontext.SaveChanges();
        }
    }
}
