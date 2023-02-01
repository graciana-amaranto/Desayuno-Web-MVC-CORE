using System.ComponentModel.DataAnnotations;

namespace SistemaWebMisRecetas.Validations
{
    public class EdadMayorQueAttribute : ValidationAttribute
    {
        public EdadMayorQueAttribute()
        {
            ErrorMessage = "El autor debe tener más de 18 años.";
        }

        public override bool IsValid(object value)
        {
            int edad = (int)value; //el valor q pone el user 
            if (edad < 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}