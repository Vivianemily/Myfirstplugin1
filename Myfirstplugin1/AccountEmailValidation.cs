using Microsoft.Xrm.Sdk;
using System;

public class AccountEmailValidation : IPlugin
{
    public void Execute(IServiceProvider serviceProvider)
    {
        var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

        if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
        {
            Entity entity = (Entity)context.InputParameters["Target"];

            if (entity.LogicalName != "account")
                return;

            string email = entity.GetAttributeValue<string>("emailaddress1");

            if (string.IsNullOrEmpty(email))
            {
                throw new InvalidPluginExecutionException("Email is required.");
            }
        }
    }
}
