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
    public class MappingUpdation : IMappingUpdation
    {
        private readonly PracticeDbContext _PracticeDbcontext;

        public MappingUpdation(PracticeDbContext practiceDbcontext)
        {
            _PracticeDbcontext = practiceDbcontext;
        }

        public void UpdateMapping(MappingRequestModel requestModel)
        {
            // Retrieve the existing mappings for the given customer
            var previousValues = _PracticeDbcontext.Mapping
                                    .Where(pm => pm.CustomerId == requestModel.CustomerId)
                                    .ToList();

            // Remove the existing mappings from the database
            _PracticeDbcontext.Mapping.RemoveRange(previousValues);

            // Create new mappings based on the provided ProductsId
            var newMappings = requestModel.ProductId.Select(productId => new Mapping
            {
                CustomerId = requestModel.CustomerId,
                ProductId = productId,
            });
            _PracticeDbcontext.Mapping.AddRange(newMappings);
            _PracticeDbcontext.SaveChanges();
        }

        public void UpdateMappingWithoutReferenceChange(MappingRequestModel requestModel)
        {
            // Retrieve the existing mappings for the given customer
            var existingMappings = _PracticeDbcontext.Mapping
                .Where(pm => pm.CustomerId == requestModel.CustomerId)
                .ToList();

            // Iterate through the existing mappings and update the ProductsId
            for (int i = 0; i < existingMappings.Count && i < requestModel.ProductId.Count; i++)
            {
                existingMappings[i].ProductId = requestModel.ProductId[i];
            }

            // If there are more new ProductsId than existing mappings, add the new ones
            if (requestModel.ProductId.Count > existingMappings.Count)
            {
                var newMappings = requestModel.ProductId
                    .Skip(existingMappings.Count)
                    .Select(productId => new Mapping
                    {
                        CustomerId = requestModel.CustomerId,
                        ProductId = productId,
                    });

                _PracticeDbcontext.Mapping.AddRange(newMappings);
            }
            // If there are more existing mappings than new ProductsId, remove the extra ones
            else if (existingMappings.Count > requestModel.ProductId.Count)
            {
                _PracticeDbcontext.Mapping.RemoveRange(
                    existingMappings.Skip(requestModel.ProductId.Count));
            }
            _PracticeDbcontext.SaveChanges();
        }
    }
}
