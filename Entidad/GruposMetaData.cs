using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class GruposMetaData
    {
        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "El nombre no puede estar vacio ")]
        public string Nombre { get; set; }    
      
    }


    [MetadataType(typeof(GruposMetaData))]
    public partial class Grupos : IValidable
    {       
        private List<ValidationResult> _ValidationErrors;
        public bool IsValid
        {
            get
            {
                var validator = Validator.Validate(this);
                _ValidationErrors = validator.Item2;
                return validator.Item1;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public List<ValidationResult> ValidationErrors
        {
            get
            {
                return _ValidationErrors;
            }

            set
            {
                _ValidationErrors = value;
            }
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
