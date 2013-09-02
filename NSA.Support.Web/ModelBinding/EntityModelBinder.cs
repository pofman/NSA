using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using NSA.Support.Domain;
using NSA.Support.Extensions;
using NailsFramework.IoC;
using NailsFramework.Persistence;

namespace NSA.Support.Web.ModelBinding
{
    /// <summary>
    /// This is the Entity Model Binder. It automatically loads an entity with an Id that comes from the url.
    /// </summary>
    public class EntityModelBinder : IModelBinder
    {
        [Inject]
        public static IObjectFactory ObjectFactory { private get; set; }

        /// <summary>
        /// Gets a non generic bag of a given type
        /// </summary>
        /// <param name="type">The type of the desired bag. It must be an Entity</param>
        /// <returns>The bag.</returns>
        private IQueryable GetBag(Type type)
        {
            return (IQueryable)ObjectFactory.GetObject(typeof(IBag<>).MakeGenericType(type));
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (!bindingContext.ModelType.IsAssignableFrom(typeof(Entity<>)))
                return false;

            var modelType = bindingContext.ModelType;
            var bag = GetBag(modelType);
            var id = Guid.Parse(actionContext.ActionArguments["id"].ToString());
            var entity = bag.GetById(id, modelType);

            if (entity == null)
                return false;

            bindingContext.Model = entity;
            return true;
        }
    }
}