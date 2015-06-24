namespace Org.Cen.RobotManager.Controls
{
    using System.Collections.Generic;
    using System.Linq;

    /**
     * Store an history of strings by the more usefull reference
     */
    public class InputHistory
    {
        private const int MINIMUM_TEXT_LENGTH_COMPLETION = 2;

        private readonly IList<InputHistoryItem> _items;

        private int currentIndex = -1;

        public InputHistory()
        {
            _items = new List<InputHistoryItem>();
        }

        public string GetMostCloseTo(string startText)
        {
            if (startText == null || startText.Length <= MINIMUM_TEXT_LENGTH_COMPLETION)
            {
                return null;
            }
            InputHistoryItem result = null;
            int bestCounter = -1;
            foreach (InputHistoryItem item in _items)
            {
                if (item.Text.StartsWith(startText))
                {
                    if (item.Counter > bestCounter)
                    {
                        result = item;
                        bestCounter = item.Counter;
                    }
                }
            }
            if (result == null)
            {
                return null;
            }
            return result.Text;
        }

        private InputHistoryItem FindItemByText(string text)
        {
            InputHistoryItem result = _items.FirstOrDefault(p => p.Text == text);
            return result;
        }

        public void AddEntry(string text)
        {
            InputHistoryItem item = FindItemByText(text);
            if (item == null)
            {
                item = new InputHistoryItem(text);
                _items.Add(item);
                currentIndex = _items.Count - 1;
            }
            else
            {
                item.IncCounter();
            }
        }

        public InputHistoryItem FindNextHistoryItem()
        {
            if (_items.Count == 0)
            {
                return null;
            }
            if (currentIndex < 0 || currentIndex >= _items.Count)
            {
                return null;
            }
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            InputHistoryItem result = _items[currentIndex];

            return result;
        }

        public InputHistoryItem FindPreviousHistoryItem()
        {
            if (_items.Count == 0)
            {
                return null;
            }
            if (currentIndex < 0 || currentIndex >= _items.Count)
            {
                return null;
            }
            if (currentIndex < _items.Count - 1)
            {
                currentIndex++;
            }
            InputHistoryItem result = _items[currentIndex];

            return result;
        }
    }
}
