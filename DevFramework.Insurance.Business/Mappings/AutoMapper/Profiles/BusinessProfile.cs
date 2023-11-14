using AutoMapper;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile: Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, Product>();
        }
    }
}