using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Windows.Input;

namespace ECommerce
{
    public class CommandParameterBindingConvention : Attribute, IActionModelConvention
    {
      
        public void Apply(ActionModel action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (var parameter in action.Parameters)
            {
                if (typeof(ICommand).IsAssignableFrom((parameter.ParameterInfo.ParameterType)))
                {
                    parameter.BindingInfo = parameter.BindingInfo ?? new BindingInfo();
                    //parameter.BindingInfo.BindingSource = BindingSource.Body;
                }
            }
        }


    }
}