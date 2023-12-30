using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestBuilder
{
    public class Request
    {
        public string Url { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Header { get; set; } = string.Empty;

        public string Print()
        {
            return $"Url: {this.Url}, Body: {this.Body}, Header: {this.Header}";
        }
    }
}
