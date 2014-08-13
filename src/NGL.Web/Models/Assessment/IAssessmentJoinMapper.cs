using System;

namespace NGL.Web.Models.Assessment
{
    public interface IAssessmentJoinMapper<TTarget, TEntity> 
        where TTarget : class, new()
        where TEntity : class
    {
        TTarget Build(CreateModel source, TEntity toUse);
    }
}
