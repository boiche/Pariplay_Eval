namespace Pariplay_Eval.Data.Events
{
    public class MatchAdded
    {
        public delegate void MatchAddedHandler(object sender, MatchAddedArgs args);
    }

    public class MatchAddedArgs : EventArgs
    {
        public Match Match { get; set; }
    }
}
