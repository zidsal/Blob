namespace Game.Interface
{
    public class NewsReader
    {
        public string ReadTitle()
        {
            return "Breaking News";
        }

        public string ReadNews()
        {
            return "This is going to be a really long piece of text to show off the word wrapping sooner or later this text will be repalced with an xml reader "
                   + "that shall read the content off the site and post any breaking news it sees. " +
                   "This way we have an easy way to tell players " + "oh shit something "
                   + "is going down everyone panic see what a good idea this is :)";
        }
    }
}
