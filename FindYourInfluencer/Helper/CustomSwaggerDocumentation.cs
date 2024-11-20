namespace FindYourInfluencer.Helper
{
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Swashbuckle.AspNetCore.Annotations;
    using Microsoft.OpenApi.Models;

    public class AddCustomSwaggerDocumentation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "CustomerRegistration") // Check for specific action
            {
                operation.Summary = "Registers a new customer";
                operation.Description = "This API endpoint allows the creation of a new customer. The request body should contain customer details like name, email, etc. The system will save the customer and return a success response.";
                operation.OperationId = "RegisterCustomer";
            }
        }
    }

}
