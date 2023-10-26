namespace QIMSchoolPro.Thesis.WebUI.Models.ServiceModels
{
    public class RequestResponse
    {
        public RequestResponse(bool isComplete, string message, string detailedMessage)
        {
            IsComplete = isComplete;
            Message = message;
            DetailedMessage = detailedMessage;
        }

        public bool IsComplete { get; set; }
        public string Message { get; }
        public string DetailedMessage { get; }

        public static RequestResponse Error(Exception ex)
        {
            return new RequestResponse(false, ex.Message, ex.InnerException.Message);
        }
        public static RequestResponse Error(string message, string detailed = "")
        {
            return new RequestResponse(false, message, detailed);
        }
        public static RequestResponse BadRequest(string message, string detailed = "")
        {
            return new RequestResponse(false, message, detailed);
        }

        public static RequestResponse Done(string message)
        {
            return new RequestResponse(true, message, null);
        }
    }
}
