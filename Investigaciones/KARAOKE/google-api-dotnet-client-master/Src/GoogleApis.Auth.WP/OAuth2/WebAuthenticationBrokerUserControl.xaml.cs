﻿/*
Copyright 2013 Google Inc

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Microsoft.Phone.Controls;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Google.Apis.Auth.OAuth2.Responses;

namespace Google.Apis.Auth.OAuth2
{
    /// <summary>
    /// Web authentication broker user control for retrieving
    /// <see cref="Google.Apis.Auth.OAuth2.Responses.AuthorizationCodeResponseUrl"/>
    /// </summary>
    internal partial class WebAuthenticationBrokerUserControl : UserControl
    {
        TaskCompletionSource<AuthorizationCodeResponseUrl> tcsAuthorizationCodeResponse;

        /// <summary>Constructs a new authentication broker user control.</summary>
        public WebAuthenticationBrokerUserControl()
        {
            InitializeComponent();

            PhoneApplicationFrame rootFrame = Application.Current.RootVisual as PhoneApplicationFrame;
            PhoneApplicationPage rootPage = rootFrame.Content as PhoneApplicationPage;
            rootPage.BackKeyPress += RootPage_BackKeyPress;
        }

        /// <summary>Displays the loading animation.</summary>
        private void StartLoading()
        {
            Loader.Visibility = Visibility.Visible;
        }

        /// <summary>Removes the loading animation.</summary>
        private void StopLoading()
        {
            Loader.Visibility = Visibility.Collapsed;
        }

        /// <summary>Callback of browser navigating.</summary>
        private void OnBrowserNavigating(object sender, NavigatingEventArgs e)
        {
            // The code or the error should be received by localhost.
            if (e.Uri.Host == "localhost")
            {
                var query = e.Uri.Query.Substring(1);
                tcsAuthorizationCodeResponse.TrySetResult(new AuthorizationCodeResponseUrl(query));
            }
        }

        /// <summary>Callback of browser navigation failed.</summary>
        private void OnBrowserNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (!tcsAuthorizationCodeResponse.Task.IsCompleted)
            {
                // See https://code.google.com/p/google-api-dotnet-client/issues/detail?id=431.
                // If we encounter a null exception, cancel the task because the Windows Phone app crashed.
                if (e.Exception != null)
                {
                    tcsAuthorizationCodeResponse.TrySetException(e.Exception);
                }
                else
                {
                    tcsAuthorizationCodeResponse.TrySetCanceled();
                }
            }
        }

        /// <summary>Callback of browser navigated.</summary>
        private void OnBrowserNavigated(object sender, NavigationEventArgs e)
        {
            StopLoading();
        }

        /// <summary>The window launcher that starts browse the browser controller to the given URI.</summary>
        /// <param name="uri">The authorization code request URI</param>
        /// <returns>The authorization code response</returns>
        public Task<AuthorizationCodeResponseUrl> Launch(Uri uri)
        {
            tcsAuthorizationCodeResponse = new TaskCompletionSource<AuthorizationCodeResponseUrl>();
            tcsAuthorizationCodeResponse.Task.ContinueWith(t =>
                {
                    RemoveBackKeyPressCallback();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            StartLoading();
            browser.Navigate(uri);
            return tcsAuthorizationCodeResponse.Task;
        }

        /// <summary>A callback handler for when the user presses the back key.</summary>
        void RootPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            tcsAuthorizationCodeResponse.TrySetCanceled();
        }

        /// <summary>Removes <see cref="RootPage_BackKeyPress"/> as the root page callback.</summary>
        void RemoveBackKeyPressCallback()
        {
            PhoneApplicationFrame rootFrame = Application.Current.RootVisual as PhoneApplicationFrame;
            PhoneApplicationPage rootPage = rootFrame.Content as PhoneApplicationPage;
            rootPage.BackKeyPress -= RootPage_BackKeyPress;
        }
    }
}
