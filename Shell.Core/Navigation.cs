using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Shell.Core
{
    public sealed class Navigation
    {
        public readonly Dictionary<Type, string> PageAliases;

        private NavigationService navService;
        private readonly PagesResolver pageResolver;

        private static volatile Navigation instance;
        private static readonly object SyncRoot = new object();

        private Navigation()
        {
            pageResolver = new PagesResolver();
            PageAliases = new Dictionary<Type, string>();
        }

        private static Navigation Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Navigation();
                        }
                    }
                }

                return instance;
            }
        }

        public static NavigationService Service
        {
            get { return Instance.navService; }
            set
            {
                if (Instance.navService != null)
                {
                    Instance.navService.Navigated -= Instance.NavService_Navigated;
                }

                Instance.navService = value;
                Instance.navService.Navigated += Instance.NavService_Navigated;
            }
        }

        public static void Navigate(Page page, object context)
        {
            if (Instance.navService == null || page == null)
            {
                return;
            }

            Instance.navService.Navigate(page, context);
        }

        public static void Navigate(Page page)
        {
            Navigate(page, null);
        }

        public static void Navigate(string uri, object context)
        {
            if (Instance.navService == null || uri == null)
            {
                return;
            }

            var page = Instance.pageResolver.GetInstance(uri);

            Navigate(page, context);
        }

        public static void Navigate(string uri)
        {
            Navigate(uri, null);
        }

        void NavService_Navigated(object sender, NavigationEventArgs e)
        {
            var page = e.Content as Page;

            if (page == null)
            {
                return;
            }

            page.DataContext = e.ExtraData;
        }
    }
}
