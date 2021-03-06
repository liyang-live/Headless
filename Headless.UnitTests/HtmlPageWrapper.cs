﻿namespace Headless.UnitTests
{
    using System;
    using System.Net.Http;

    /// <summary>
    ///     The <see cref="HtmlPageWrapper" />
    ///     class is used for internal testing.
    /// </summary>
    internal class HtmlPageWrapper : HtmlPage
    {
        /// <summary>
        ///     The location.
        /// </summary>
        private readonly Uri _targetLocation;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HtmlPageWrapper" /> class.
        /// </summary>
        public HtmlPageWrapper()
        {
            _targetLocation = new Uri("https://google.com");
        }

        /// <summary>
        /// Assigns the content.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        public void AssignContent(HttpContent content)
        {
            SetContent(content);
        }

        /// <inheritdoc />
        public override Uri TargetLocation
        {
            get
            {
                return _targetLocation;
            }
        }
    }
}