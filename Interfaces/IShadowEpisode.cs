﻿namespace ShadowViewer.Interfaces;

public interface IShadowEpisode
{
    /// <summary>
    /// 用于处理的本体,建议为索引号
    /// </summary>
    object Source { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    string Title { get; set; }
    /// <summary>
    /// 其他备注
    /// </summary>
    object Tag{ get; set; }
}