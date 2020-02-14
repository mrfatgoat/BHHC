using BHHC.Views.Shared.Models;

namespace BHHC.Views.Home.Models
{
    public class IndexViewModel : ILayoutViewModel
    {
        public string HomeViewProperty { get; set; }
        public string PageTitle { get; set; }
    }
}
