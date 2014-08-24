using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Castle.Core.Internal;

namespace NGL.Web.Data.Entities
{
    public partial class NglDbContext : INglDbContext
    {
        public void Save()
        {
            try
            {
                SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var elmahException = new DbEntityValidationException(DbEntityValidationExceptionToString(ex), ex);
                Elmah.ErrorSignal.FromCurrentContext().Raise(elmahException);
                ChangeTracker.Entries().ForEach(e =>
                {
                    e.State = EntityState.Detached;
                });
                throw;
            }
        }

        static string DbEntityValidationExceptionToString(DbEntityValidationException e)
        {
            var validationErrors = DbEntityValidationResultToString(e);
            var exceptionMessage = string.Format("{0}{1}Validation errors:{1}{2}", e, Environment.NewLine, validationErrors);
            return exceptionMessage;
        }

        static string DbEntityValidationResultToString(DbEntityValidationException e)
        {
            return e.EntityValidationErrors
                    .Select(dbEntityValidationResult => DbValidationErrorsToString(dbEntityValidationResult, dbEntityValidationResult.ValidationErrors))
                    .Aggregate(string.Empty, (current, next) => string.Format("{0}{1}{2}", current, Environment.NewLine, next));
        }

        static string DbValidationErrorsToString(DbEntityValidationResult dbEntityValidationResult, IEnumerable<DbValidationError> dbValidationErrors)
        {
            var entityName = string.Format("[{0}]", dbEntityValidationResult.Entry.Entity.GetType().Name);
            const string indentation = "\t - ";
            var aggregatedValidationErrorMessages = dbValidationErrors.Select(error => string.Format("[{0} - {1}]", error.PropertyName, error.ErrorMessage))
                                                   .Aggregate(string.Empty, (current, validationErrorMessage) => current + (Environment.NewLine + indentation + validationErrorMessage));
            return string.Format("{0}{1}", entityName, aggregatedValidationErrorMessages);
        }

        IDbSet<TEntity> INglDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }
    }
}
