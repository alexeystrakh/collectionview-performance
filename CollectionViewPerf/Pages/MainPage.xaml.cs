using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CollectionViewPerf
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListView_Clicked(System.Object sender, System.EventArgs e)
        {
            var newPage = new ListViewPage() { BindingContext = GetItemsViewModel() };
            
            Navigation.PushAsync(newPage);
        }

        private void CollectionView_Clicked(System.Object sender, System.EventArgs e)
        {
            var newPage = new CollectionViewPage() { BindingContext = GetItemsViewModel() };
            Navigation.PushAsync(newPage);
        }

        private ItemsViewModel GetItemsViewModel()
        {
            var random = new Random();
            var itemsViewModel = new ItemsViewModel();
            for (int i = 0; i < 10000; i++)
            {
                itemsViewModel.Items.Add(new Item
                {
                    Url = $"https://microsoft.com/{i}",
                    Name = $"Microsoft Page {Environment.TickCount}",
                    Icon = GetRandomImageUrl(random),
                });
            }

            return itemsViewModel;
        }

        private string GetRandomImageUrl(Random rnd)
        {
            var next = rnd.Next(1, 5);
            switch (next)
            {
                case 1:
                    return "https://i1.wp.com/build5nines.com/wp-content/uploads/2017/09/Azure.png?resize=519%2C387&ssl=1";
                case 2:
                    return "https://lh3.googleusercontent.com/proxy/FrZmLzf5sa-QD7VOhLnJPujnhm6EcwTyk4YY5vjNFFO7nnu2y2cJzvy3UPvYuRR0vC6emy85bxPl5DJJ6cunpOHJSp3aDojdaqlyLVa73hUBNJxk6NTUWpoWtZ4";
                case 3:
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c9/Microsoft_Office_Teams_%282018%E2%80%93present%29.svg/1200px-Microsoft_Office_Teams_%282018%E2%80%93present%29.svg.png";
                case 4:
                default:
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Microsoft_Office_logo_%282019%E2%80%93present%29.svg/1200px-Microsoft_Office_logo_%282019%E2%80%93present%29.svg.png";
            }
        
        }
    }
}
