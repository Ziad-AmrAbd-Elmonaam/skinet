using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ValidationErrorResponsen : ApiResponse
    {
        public ValidationErrorResponsen() : base(400)
        {
        }
        public IEnumerable <string> Erros { get; set; }
    }
}