/*
 * This file contains a Response class defines all the properties for a response Object as required in the frontend.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class Response
    {
        public bool success { get; set; }
        public string message { get; set; }

    }
}
