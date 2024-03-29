﻿namespace ShadowViewer.Plugins;

/// <summary>
/// 插件元数据
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class PluginMetaData : Attribute
{
    /// <summary>
    /// 标识符(大小写不敏感)
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// 显示的名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 介绍
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// 作者
    /// </summary>
    public string Author { get; set; }
    /// <summary>
    /// 版本号
    /// </summary>
    public string Version { get; set; }
    /// <summary>
    /// 项目地址
    /// </summary>
    public string WebUri { get; set; }

    /// <summary>
    /// 图标<br/>
    /// 1.本地文件,以ms-appx://开头<br/>
    /// 2.FontIcon,以font://开头<br/>
    /// 3.FluentRegularIcon,以fluent://regular开头
    /// 4.FluentFilledIcon,以fluent://filled
    /// <example><br/>
    /// 1.ms-appx:///Assets/Icons/Logo.png<br/>
    /// 2.font://\uE714<br/>
    /// 3.fluent://regular/\uE714
    /// 4.fluent://filled/\uE714
    /// </example>
    /// </summary>
    public string Logo { get; set; }

    /// <summary>
    /// 支持的插件管理器版本,该版本即为ShadowViewer.Core的发行版
    /// </summary>
    public string MinVersion { get; set; }
    /// <summary>
    /// 支持的语言
    /// </summary>
    public string[]? Lang { get; set; }
    /// <summary>
    /// 依赖的插件ID
    /// </summary>
    public string[]? Require { get; set; }
    /// <summary>
    /// 插件元数据
    /// </summary>
    /// <param name="id">标识符(大小写不敏感)</param>
    /// <param name="name">显示的名称</param>
    /// <param name="description">介绍</param>
    /// <param name="author">作者</param>
    /// <param name="version">版本号</param>
    /// <param name="webUri">项目地址</param>
    /// <param name="logo">图标<br/>
    /// 1.本地文件,以ms-appx://开头<br/>
    /// 2.FontIcon,以font://开头<br/>
    /// 3.FluentRegularIcon,以fluent://regular开头
    /// 4.FluentFilledIcon,以fluent://filled
    /// <example><br/>
    /// 1.ms-appx:///Assets/Icons/Logo.png<br/>
    /// 2.font://\uE714<br/>
    /// 3.fluent://regular/\uE714
    /// 4.fluent://filled/\uE714
    /// </example></param>
    /// <param name="requireVersion">支持的插件管理器版本,该版本即为ShadowViewer.Core的发行版</param>
    /// <param name="require">依赖的插件ID</param>
    /// <param name="lang">支持的语言</param>
    public PluginMetaData(string id, string name, string description, string author, string version, string webUri,
        string logo, string requireVersion, string[] require, string[] lang)
    {
        Id = id;
        Name = name;
        Description = description;
        Author = author;
        Version = version;
        WebUri = webUri;
        Logo = logo;
        MinVersion = requireVersion;
        Lang = lang ;
        Require = require;
    }

}