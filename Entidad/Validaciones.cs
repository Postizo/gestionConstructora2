using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;

namespace Entidad
{
    
    public interface IValidable
    {
        bool IsValid { get; set; }
        List<ValidationResult> ValidationErrors { get; set; }
    }

    interface IValidator
    {
        Tuple<bool, List<ValidationResult>> ValidateObject(IValidable objToValidate);
    }
    public class RegistarMetadatas
    {
        public  void registerBuddyClasses()
        {
            var buddyAssociations =
                from t in Assembly.GetExecutingAssembly().GetTypes()
                let md = t.GetCustomAttributes(typeof(MetadataTypeAttribute), false)
                        .FirstOrDefault() as MetadataTypeAttribute
                where md != null
                select new { Type = t, Buddy = md.MetadataClassType };

            foreach (var association in buddyAssociations)
            {
                var descriptionProvider =
                    new AssociatedMetadataTypeTypeDescriptionProvider(
                        association.Type, association.Buddy
                    );
                TypeDescriptor.AddProviderTransparent(descriptionProvider, association.Type);
            }
        }
    }
    public sealed class Validator : IValidator
    {
        private Validator() { }
        private static Validator validator = new Validator();
        public static Tuple<bool, List<ValidationResult>> Validate(IValidable objToValidate)
        {
            if (validator == null)
                validator = new Validator();
            return validator.ValidateObject(objToValidate);
        }
        public Tuple<bool, List<ValidationResult>> ValidateObject(IValidable objToValidate)
        {

            var results = new List<ValidationResult>();
            var context = new ValidationContext(objToValidate, null, null);
            var obj = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(objToValidate, context, results, true);
            return new Tuple<bool, List<ValidationResult>>(obj, results);
        }
    }
}
