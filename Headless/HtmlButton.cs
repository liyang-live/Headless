﻿namespace Headless
{
    using System.Xml.XPath;
    using Headless.Activation;

    /// <summary>
    ///     The <see cref="HtmlButton" />
    ///     class is used to represent a HTML button.
    /// </summary>
    /// <remarks>
    ///     This class does not support the button element or input type=button because they are usually for JavaScript
    ///     actions that Headless does not support. While some browsers may submit the form for these elements, not all
    ///     browsers will.
    /// </remarks>
    [SupportedTag("input", "type", "submit")]
    [SupportedTag("button", "type", "submit")]
    [SupportedTag("input", "type", "image")]
    public class HtmlButton : HtmlFormElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlButton"/> class.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="page"/> parameter is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="node"/> parameter is <c>null</c>.
        /// </exception>
        public HtmlButton(IHtmlPage page, IXPathNavigable node) : base(page, node)
        {
        }

        /// <summary>
        ///     Clicks the button and returns the response from the server.
        /// </summary>
        /// <returns>
        ///     A <see cref="IPage" /> value.
        /// </returns>
        public dynamic Click()
        {
            var form = Form;

            return form.Submit(this);
        }

        /// <summary>
        ///     Clicks the button and returns the response from the server.
        /// </summary>
        /// <typeparam name="T">The type of page to return.</typeparam>
        /// <returns>
        ///     A <typeparamref name="T" /> value.
        /// </returns>
        public T Click<T>() where T : IPage, new()
        {
            var form = Form;

            return form.Submit<T>(this);
        }
    }
}