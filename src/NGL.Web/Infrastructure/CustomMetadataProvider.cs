using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Validators;
using Humanizer;

namespace NGL.Web.Infrastructure
{
    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        readonly IValidatorFactory _factory;
        public CustomModelMetadataProvider(IValidatorFactory factory)
        {
            _factory = factory;
        }

        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            var propertyAttributes = attributes.ToList();
            var modelMetadata = base.CreateMetadata(propertyAttributes, containerType, modelAccessor, modelType, propertyName);

            if (ShouldHumanize(modelMetadata, propertyAttributes))
                modelMetadata.DisplayName = modelMetadata.PropertyName.Humanize();

            return modelMetadata;
        }

        protected override ModelMetadata GetMetadataForProperty(
            Func<object> modelAccessor,
            Type containerType,
            PropertyDescriptor propertyDescriptor)
        {
            ModelMetadata metadata = base.GetMetadataForProperty(modelAccessor, containerType, propertyDescriptor);
            metadata.IsRequired = metadata.IsRequired || IsNotEmpty(containerType, propertyDescriptor.Name);
            return metadata;
        }


        private static bool ShouldHumanize(ModelMetadata modelMetadata, IList<Attribute> propertyAttributes)
        {
            if (string.IsNullOrEmpty(modelMetadata.PropertyName))
                return false;

            if (propertyAttributes.OfType<DisplayNameAttribute>().Any())
                return false;

            if (propertyAttributes.OfType<DisplayAttribute>().Any())
                return false;

            return true;
        }

        bool IsNotEmpty(Type type, string name)
        {
            var validator = _factory.GetValidator(type);

            if (validator == null)
                return false;

            IEnumerable<IPropertyValidator> validators = validator.CreateDescriptor().GetValidatorsForMember(name);

            var propertyValidators = validators as IPropertyValidator[] ?? validators.ToArray();
            bool notEmpty = propertyValidators
                .OfType<INotNullValidator>()
                .Concat(propertyValidators.OfType<INotEmptyValidator>().Cast<IPropertyValidator>())
                .Any();

            return notEmpty;
        }
    }
}