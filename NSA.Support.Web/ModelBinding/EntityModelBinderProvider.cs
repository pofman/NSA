using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using NSA.Support.Domain;

namespace NSA.Support.Web.ModelBinding
{
    public class EntityModelBinderProvider : ModelBinderProvider
    {
        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            if (modelType.IsAssignableFrom(typeof(Entity<>)))
                return new EntityModelBinder();

            return null;
        }
    }
}