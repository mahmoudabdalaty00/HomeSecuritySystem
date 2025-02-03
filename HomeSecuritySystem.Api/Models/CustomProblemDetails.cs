using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HomeSecuritySystem.Api.Models
{
    public class CustomProblemDetails : ProblemDetails
    {
         IDictionary<string , string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
