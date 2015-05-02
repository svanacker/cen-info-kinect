namespace Org.Cen.RobotManager.Controls
{
    public class InputHistoryItem
    {
        public string Text { get; private set; }

        public int Counter { get; private set; }

        public InputHistoryItem(string text)
        {
            Text = text;
        }

        public void IncCounter()
        {
            Counter++;
        }
    }
}
