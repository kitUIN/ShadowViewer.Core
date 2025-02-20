﻿using System;
using SqlSugar;

namespace ShadowViewer.Core.Models.Interfaces;
/// <summary>
/// 历史记录基类
/// </summary>
public interface IHistory
{
    /// <summary>
    /// 名称
    /// </summary>
    string? Title { get; set; }
    /// <summary>
    /// ID
    /// </summary>
    long Id { get; set; }
    /// <summary>
    /// 图片
    /// </summary>
    string? Icon { get; set; }
    /// <summary>
    /// 阅读时间
    /// </summary>
    DateTime Time { get; set; }
    /// <summary>
    /// 来源插件
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    string PluginId { get; }
}