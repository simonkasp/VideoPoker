namespace VideoPoker
{
    public class Message
    {
        public string GetMenuMessage(int msgIndex)
        {            
            return msgIndex > 0 ? "1 - Draw new cards; 0 - Close app" : "1 - Draw new cards; 2 - Continue; 0 - Close app" ;
        }
    }
}
