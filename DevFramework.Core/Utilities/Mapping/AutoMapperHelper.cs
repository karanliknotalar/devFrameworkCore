using System.Collections.Generic;
using AutoMapper;

namespace DevFramework.Core.Utilities.Mapping
{
    public abstract class AutoMapperHelper
    {
        // public static List<T> MapToSameTypeList<T>(List<T> list)
        // {
        //     Mapper.Initialize(c => { c.CreateMap<T, T>(); });
        //     return Mapper.Map<List<T>, List<T>>(list);
        // }
        //
        // public static T MapToSameType<T>(T entity)
        // {
        //     Mapper.Initialize(c => { c.CreateMap<T, T>(); });
        //     return Mapper.Map<T, T>(entity);
        // }
    }
}