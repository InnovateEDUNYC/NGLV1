using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation;
using Ninject;
using Ninject.Planning.Bindings;

namespace NGL.Web.App_Start
{
    public class NinjectValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            var kernel = DependencyResolver.Current.GetService<IKernel>();

            if (((IList<IBinding>)kernel.GetBindings(validatorType)).Count == 0)
            {
                return null;
            }

            return kernel.Get(validatorType) as IValidator;
        }
    }
}