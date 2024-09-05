using PracticeProject.Model.RequestModels;

namespace PracticeProject.Core.Interface
{
    public interface IMappingUpdation
    {
        void UpdateMapping(MappingRequestModel requestModel);
        void UpdateMappingWithoutReferenceChange(MappingRequestModel requestModel);
    }
}