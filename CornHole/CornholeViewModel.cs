using System;
namespace CommonLib
{
    public class CornholeViewModel
    {
        protected ICornholeViewManager viewManager;

        public CornholeViewModel(ICornholeViewManager viewManager)
        {
            this.viewManager = viewManager ?? throw new ArgumentNullException(nameof(viewManager));
        }

        public virtual void ShowMessage()
        {
            var message = "Hello World";
            viewManager.ShowMessage(message);
        }
    }
}
