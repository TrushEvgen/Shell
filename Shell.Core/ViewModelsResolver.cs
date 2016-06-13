namespace Shell.Core
{
    public class ViewModelsResolver : ObjectResolver<ViewModelBase>
    {
        public ViewModelsResolver(params ViewModelBase[] viewModels)
        {
            //RegisterResolver();
            //pagesResolvers.Add(Navigation.Page1Alias, () => new Page1());
            //pagesResolvers.Add(Navigation.Page2Alias, () => new Page2());
            //pagesResolvers.Add(Navigation.Page3Alias, () => new Page3());
            //pagesResolvers.Add(Navigation.NotFoundPageAlias, () => new Page404());
        }
    }
}
