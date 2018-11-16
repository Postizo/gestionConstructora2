using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    class SubGruposMeta
    {
        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "El nombre no puede estar vacio ")]
        public string Nombre { get; set; }
     
    }
    [MetadataType(typeof(SubGruposMeta))]
    public partial class Subgrupos : IValidable
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
    }
}
