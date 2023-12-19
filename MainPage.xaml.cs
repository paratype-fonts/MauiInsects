using System.Diagnostics;

namespace MauiInsects {
    public partial class MainPage : ContentPage {
        readonly MainPageViewModel viewModel;
        public MainPage(MainPageViewModel viewModel) {
            InitializeComponent();
            BindingContext = viewModel;
            this.viewModel = viewModel;
        }
        private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e) {
            viewModel.SetFirstLastVisible(e.FirstVisibleItemIndex, e.LastVisibleItemIndex);
            Debug.WriteLine($"First visible: {e.FirstVisibleItemIndex:D4}");
            Debug.WriteLine($"Last  visible: {e.LastVisibleItemIndex:D4}");
        }
        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) {
        }
    }

}
