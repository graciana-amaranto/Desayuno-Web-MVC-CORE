using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebMisRecetas.Validations
{
    public class CategoriaDesayunoAttribute : ValidationAttribute
    {
        public CategoriaDesayunoAttribute()
        {
            ErrorMessage = "La categoría que ingrese debe ser solo 'Desayuno'.";
        }

        public override bool IsValid(object value)
        {
            string categoria = (string)value; //el valor q pone el user 
           
            if (categoria.ToLower() != "desayuno")
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
