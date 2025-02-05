﻿using ShadowViewer.Models.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace ShadowViewer.Extensions;

/// <summary>
/// 历史记录拓展类,通过时间比较
/// </summary>
public class HistoryExtension : IComparer<IHistory>
{

    private readonly CaseInsensitiveComparer caseInsensitiveComparer = new();

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public int Compare(IHistory? x, IHistory? y)
    {
        return caseInsensitiveComparer.Compare( y?.Time,x?.Time);
    }
}