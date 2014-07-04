using TestStack.Seleno.PageObjects;

namespace NGL.UiTests.Pages
{
    class HomePage : Page
    {
        public TopMenu TopMenu
        {
            get { return GetComponent<TopMenu>(); }
        }
    }
}