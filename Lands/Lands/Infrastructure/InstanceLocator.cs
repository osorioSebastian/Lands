
namespace Lands.Infrastructure
{
    using ViewsModels;
    public class InstanceLocator
    {

        #region Properties

        public MainViewModels Main
        {
            get;
            set;
        }

        #endregion

        #region Contructors
        public InstanceLocator()
        {
            this.Main = new MainViewModels();
        }
        #endregion
    }
}
