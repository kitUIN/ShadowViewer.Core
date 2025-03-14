﻿using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ShadowViewer.Core.Models.Interfaces;

namespace ShadowViewer.Core.Plugins;

public abstract partial class AShadowViewerPlugin
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public virtual IEnumerable<IShadowSearchItem> SearchTextChanged(AutoSuggestBox sender,
        AutoSuggestBoxTextChangedEventArgs args)
    {
        return new List<IShadowSearchItem>();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public virtual void SearchSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public virtual void SearchQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public virtual void SearchGotFocus(object sender, RoutedEventArgs args)
    {
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public virtual void SearchLostFocus(object sender, RoutedEventArgs args)
    {
    }
}