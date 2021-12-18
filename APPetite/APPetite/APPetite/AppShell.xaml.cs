using APPetite.Views;
using Xamarin.Forms;

namespace APPetite
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(CategoryPage), typeof(CategoryPage));
            Routing.RegisterRoute(nameof(MyRecipePage), typeof(MyRecipePage));
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
        }

    }
}
