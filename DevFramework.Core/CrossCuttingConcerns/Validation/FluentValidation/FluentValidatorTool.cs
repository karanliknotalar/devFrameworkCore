using FluentValidation;

namespace DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public abstract class FluentValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context); 

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
