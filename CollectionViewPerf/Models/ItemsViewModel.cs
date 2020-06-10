using System.Collections.ObjectModel;

namespace CollectionViewPerf
{
    public class ItemsViewModel
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
    }
}
