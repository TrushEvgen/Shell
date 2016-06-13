using System.Windows.Controls;

namespace Shell.Core
{
    public class PagesResolver : ObjectResolver<Page>
    {
        public PagesResolver(params Page[] pages)
        {
            //RegisterResolver();
            //pagesResolvers.Add(Navigation.Page1Alias, () => new Page1());
            //pagesResolvers.Add(Navigation.Page2Alias, () => new Page2());
            //pagesResolvers.Add(Navigation.Page3Alias, () => new Page3());
            //pagesResolvers.Add(Navigation.NotFoundPageAlias, () => new Page404());
        }
    }
}
