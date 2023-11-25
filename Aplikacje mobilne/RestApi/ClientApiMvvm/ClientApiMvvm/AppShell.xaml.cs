using ClientApiMvvm.View;
namespace ClientApiMvvm
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("addPart", typeof(AddPartView));
            Routing.RegisterRoute("updatePart", typeof(UpdatePartView));
        }
    }
}
