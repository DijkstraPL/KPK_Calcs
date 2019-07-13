using AutoMapper;
using Build_IT_Application.Scripts.Scripts.Queries;
using Build_IT_Data.Entities.Scripts;
using System;
using System.Linq;

namespace Build_IT_Application.Mapping
{
    public class ScriptMappingProfile : Profile
    {
        #region Public_Methods
        
        public ScriptMappingProfile()
        {
            // Domain Resource to API
            CreateMap<Script, ScriptResource>();
                //.ForMember(svm => svm.Tags, operation
                //=> operation.MapFrom(s => s.Tags.Select(st => st.Tag)));

            // API Resource to Domain
            CreateMap<ScriptResource, Script>();
                //.ForMember(s => s.Id, operation => operation.Ignore())
                //.ForMember(s => s.Tags, operation => operation.Ignore())
                //.AfterMap((sr, s) =>
                //{
                //    RemoveNotAddedTags(sr, s);
                //    AddNewTags(sr, s);
                //});
        
        }

        #endregion // Public_Methods

        #region Private_Methods
            
        //private void RemoveNotAddedTags(ScriptResource scriptResource, Script script)
        //{
        //    var removedTags = script.Tags.Where(t =>
        //    !scriptResource.Tags.Select(tr => tr.Id).Contains(t.TagId)).ToList();
        //    foreach (var tag in removedTags)
        //        script.Tags.Remove(tag);
        //}

        //private void AddNewTags(ScriptResource scriptResource, Script script)
        //{
        //    var addedTags = scriptResource.Tags.Where(tr => !script.Tags.Any(t => t.TagId == tr.Id))
        //         .Select(tr => new ScriptTag { TagId = tr.Id }).ToList();
        //    foreach (var tag in addedTags)
        //        script.Tags.Add(tag);
        //}
        
        #endregion // Private_Methods
    }
}
