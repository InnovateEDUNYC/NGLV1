using System;
using System.Web;
using ChameleonForms.Component.Config;
using ChameleonForms.Enums;
using ChameleonForms.FieldGenerators;
using ChameleonForms.FieldGenerators.Handlers;

namespace NGL.Web.Infrastructure.ChameleonForms
{
    internal class NglDateTimeHandler<TModel, T> : FieldGeneratorHandler<TModel, T>
    {
        /// <summary>
        /// Constructor for the DateTime Field Generator Handler.
        /// </summary>
        /// <param name="fieldGenerator">The field generator for the field</param>
        public NglDateTimeHandler(IFieldGenerator<TModel, T> fieldGenerator)
            : base(fieldGenerator)
        {
        }

        /// <inheritdoc />
        public override bool CanHandle()
        {
            return GetUnderlyingType(FieldGenerator) == typeof (DateTime);
        }

        /// <inheritdoc />
        public override IHtmlString GenerateFieldHtml(IReadonlyFieldConfiguration fieldConfiguration)
        {
            return GetInputHtml(TextInputType.Text, FieldGenerator, fieldConfiguration);
        }

        /// <inheritdoc />
        public override void PrepareFieldConfiguration(IFieldConfiguration fieldConfiguration)
        {
            var dateTimeFormat = "MM-dd-yyyy";

            if (!string.IsNullOrEmpty(FieldGenerator.Metadata.DisplayFormatString))
                dateTimeFormat = FieldGenerator.Metadata.DisplayFormatString.Replace("{0:", "").Replace("}", "");

            fieldConfiguration.Attr("data-val-format", dateTimeFormat);
            fieldConfiguration.AddClass("datepicker");
        }

        /// <inheritdoc />
        public override FieldDisplayType GetDisplayType(IReadonlyFieldConfiguration fieldConfiguration)
        {
            return FieldDisplayType.SingleLineText;
        }
    }
}