using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using ChameleonForms;
using ChameleonForms.Enums;
using ChameleonForms.FieldGenerators;
using ChameleonForms.Templates;
using ChameleonForms.Templates.TwitterBootstrap3;

namespace NGL.Web.Infrastructure.ChameleonForms
{
    public static class FormHelpers
    {
        public static IForm<TModel, TwitterBootstrapFormTemplate> BeginNglForm<TModel>(
            this HtmlHelper<TModel> htmlhelper, 
            string action = "", 
            FormMethod method = FormMethod.Post, 
            HtmlAttributes htmlAttributes = null, 
            EncType? enctype = null)
        {
            return new NglForm<TModel, TwitterBootstrapFormTemplate>(
                htmlhelper, 
                new TwitterBootstrapFormTemplate(), 
                action, 
                method, 
                htmlAttributes, 
                enctype);
        }
    }

    public class NglForm<TModel, TTemplate> : Form<TModel, TTemplate> where TTemplate : IFormTemplate
    {
        /// <summary>
        /// Construct a Chameleon Form.
        /// Note: Contains a call to the virtual method Write.
        /// </summary>
        /// <param name="helper">The HTML Helper for the current view</param>
        /// <param name="template">A template renderer instance to use to render the form</param>
        /// <param name="action">The action the form should submit to</param>
        /// <param name="method">The HTTP method the form submission should use</param>
        /// <param name="htmlAttributes">Any HTML attributes the form should use expressed as an anonymous object</param>
        /// <param name="enctype">The encoding type the form submission should use</param>
        public NglForm(HtmlHelper<TModel> helper, TTemplate template, string action, FormMethod method, HtmlAttributes htmlAttributes, EncType? enctype)
            :base(helper, template, action, method, htmlAttributes, enctype)
        {
        }

        public override IFieldGenerator GetFieldGenerator<T>(Expression<Func<TModel, T>> property)
        {
            return new NglFieldGenerator<TModel, T>(HtmlHelper, property, Template);
        }
    }
}