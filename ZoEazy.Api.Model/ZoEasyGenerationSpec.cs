using TypeGen.Core.SpecGeneration;
using ZoEazy.Api.Model.ViewModels;

namespace ZoEazy.Api.Model
{
    public class ZoEazyGenerationSpec : GenerationSpec
    {
        public ZoEazyGenerationSpec()
        {
            AddClass<Branch.Branch>();
            AddClass<FranchiseeViewModel>();
        }
    }
}

