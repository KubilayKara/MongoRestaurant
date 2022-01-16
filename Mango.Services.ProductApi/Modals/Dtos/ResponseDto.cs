using System.Collections.Generic;

namespace Mango.Services.ProductApi.Modals
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }

        public object Result { get; set; }

        public string DisplayMessage { get; set; }
        public List<string> ErrorMessaages { get; set; }
    }
}
    