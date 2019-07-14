using AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Build_IT_Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        #region Public_Methods
        
        public AutoMapperProfile()
        {
            LoadStandardMappings();
            LoadCustomMappings();
            LoadConverters();
        }

        #endregion // Public_Methods

        #region Private_Methods

        private void LoadConverters()
        {

        }

        private void LoadStandardMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
                CreateMap(map.Source, map.Destination).ReverseMap();
        }

        private void LoadCustomMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
                map.CreateMappings(this);
        }

        #endregion // Private_Methods
    }
}
