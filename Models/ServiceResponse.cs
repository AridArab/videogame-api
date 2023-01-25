using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace videogame_api.Models
{
    public class ServiceResponse<T>
    {
        /* Object that is returned when calling the api, contains
         the data as well as if the call was successful
        Along with the message. */
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}