namespace ProductClientHub.Communication.Response
{
    public class ResponseErrorMessageJson
    {
        public List<string> Errors { get; private set; }

        public ResponseErrorMessageJson(string message)
        {
            //Errors = new List<string> { message };
            Errors = [message]; //Formar simplificada de intanciar uma lista com um item
        }
    }
}
