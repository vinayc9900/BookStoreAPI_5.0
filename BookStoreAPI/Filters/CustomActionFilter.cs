using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Filters
{
    // "Attribute" Keyword is helps to Use class name like an  Attribute in Controller
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(" CustomActionFilter OnActionExecuting..");
        } 
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("CustomActionFilter OnActionExecuted successfully..");
        }

      
    }
}
