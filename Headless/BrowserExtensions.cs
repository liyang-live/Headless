﻿namespace Headless
{
    using System;
    using System.Net;

    /// <summary>
    ///     The <see cref="BrowserExtensions" />
    ///     class is used to provide extension methods to the <see cref="Browser" /> class.
    /// </summary>
    public static class BrowserExtensions
    {
        /// <summary>
        /// Browses to the location defined by the specified page type.
        /// </summary>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <returns>
        /// A <see cref="Page"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        public static T GoTo<T>(this Browser browser) where T : Page, new()
        {
            if (browser == null)
            {
                throw new ArgumentNullException("browser");
            }

            return browser.GoTo<T>(null, HttpStatusCode.OK);
        }

        /// <summary>
        /// Browses to the specified location.
        /// </summary>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// A dynamic html page.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        public static dynamic GoTo(this Browser browser, Uri location)
        {
            if (browser == null)
            {
                throw new ArgumentNullException("browser");
            }

            var dynamicPage = browser.GoTo<DynamicResolverPage>(location, HttpStatusCode.OK);

            return dynamicPage.GetAppropriatePage();
        }

        /// <summary>
        /// Browses to the specified location.
        /// </summary>
        /// <typeparam name="T">
        /// The type of page to return.
        /// </typeparam>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <param name="location">
        /// The location to navigate to.
        /// </param>
        /// <returns>
        /// A <see cref="Page"/> value.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="browser"/> parameter is <c>null</c>.
        /// </exception>
        public static T GoTo<T>(this Browser browser, Uri location) where T : IPage, new()
        {
            if (browser == null)
            {
                throw new ArgumentNullException("browser");
            }

            return browser.GoTo<T>(location, HttpStatusCode.OK);
        }
    }
}