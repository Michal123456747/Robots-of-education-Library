using Newtonsoft.Json.Linq;

namespace ROELibrary
{
    interface IMessageContainerToSend : IMessageContainer //object that can be sended
    {
        JObject serializeToJsonObject(); 
    }
}
