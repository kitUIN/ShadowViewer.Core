using DryIoc;
using Serilog;
using ShadowPluginLoader.WinUI;
using ShadowPluginLoader.WinUI.Exceptions;
using ShadowViewer.Core.Models.Interfaces;
using ShadowViewer.Core.Plugins;
using ShadowViewer.Core.Responders;
using ShadowViewer.Core.Settings;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Nodes;

namespace ShadowViewer.Core;

/// <summary>
/// ShadowView 插件加载器
/// </summary>
public class PluginLoader(ILogger logger, PluginEventService pluginEventService)
    : AbstractPluginLoader<PluginMetaData, AShadowViewerPlugin>(logger, pluginEventService)
{
    /// <summary>
    /// 加载器版本
    /// </summary>
    public static Version CoreVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version!;

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<string, Type> RegisterForResponders { get; } = new();

    /// <inheritdoc/>
    protected override void BeforeLoadPlugin(Type plugin, PluginMetaData meta)
    {
        var pluginVersion = new Version(meta.CoreVersion);
        if (pluginVersion > CoreVersion)
        {
            throw new PluginImportException($"插件ID[{meta.Id}]最低支持CoreVersion为:{meta.CoreVersion},实际版本为:{CoreVersion}");
        }
    }

    /// <inheritdoc/>
    protected override void AfterLoadPlugin(Type tPlugin, AShadowViewerPlugin aPlugin, PluginMetaData meta)
    {
        var db = DiFactory.Services.Resolve<ISqlSugarClient>();
        var responder = aPlugin.MetaData.PluginResponder;
        if (responder.NavigationResponder != null)
        {
            DiFactory.Services.Register(typeof(INavigationResponder), responder.NavigationResponder,
                Reuse.Transient, made: Parameters.Of.Type(_ => meta.Id));
            Logger.Information(
                "{Id}{Name} Load INavigationResponder: {TNavigationResponder}",
                meta.Id, meta.Name,
                responder.NavigationResponder.Name);
        }

        if (responder.PicViewResponder != null)
        {
            DiFactory.Services.Register(typeof(IPicViewResponder), responder.PicViewResponder,
                Reuse.Transient, made: Parameters.Of.Type(_ => meta.Id));
            Logger.Information(
                "{Id}{Name} Load IPicViewResponder: {TNavigationResponder}",
                meta.Id, meta.Name,
                responder.PicViewResponder.Name);
        }

        if (responder.HistoryResponder != null)
        {
            DiFactory.Services.Register(typeof(IHistoryResponder), responder.HistoryResponder,
                Reuse.Transient, made: Parameters.Of.Type(_ => meta.Id));
            Logger.Information(
                "{Id}{Name} Load IHistoryResponder: {TNavigationResponder}",
                meta.Id, meta.Name,
                responder.HistoryResponder.Name);
        }

        if (responder.SearchSuggestionResponder != null)
        {
            DiFactory.Services.Register(typeof(ISearchSuggestionResponder), responder.SearchSuggestionResponder,
                Reuse.Transient, made: Parameters.Of.Type(_ => meta.Id));
            Logger.Information(
                "{Id}{Name} Load ISearchSuggestionResponder: {TNavigationResponder}",
                meta.Id, meta.Name,
                responder.SearchSuggestionResponder.Name);
        }

        foreach (var folder in responder.SettingFolders)
        {
            DiFactory.Services.Register(typeof(ISettingFolder), folder,
                Reuse.Transient, made: Parameters.Of.Type(_ => meta.Id));
            Logger.Information(
                "{Id}{Name} Load ISettingFolder: {TNavigationResponder}",
                meta.Id, meta.Name,
                folder.Name);
        }

        foreach (var kv in aPlugin.RegisterForResponders)
        {
            RegisterForResponders[kv.Key] = kv.Value;
        }

        if (aPlugin.MetaData.EntryPoints is not JsonObject entryPoints) return;

        foreach (var kv in RegisterForResponders)
        {
            if (!entryPoints.ContainsKey(kv.Key) || Type.GetType(entryPoints[kv.Key]!.GetValue<string>()) is
                    not { } responderType) continue;
            DiFactory.Services.Register(kv.Value, responderType,
                Reuse.Transient, made: Parameters.Of.Type(_ => meta.Id));
            Logger.Information(
                "{Id}{Name} Load {IResponder}: {TResponder}",
                meta.Id, meta.Name,
                kv.Value.Name,
                responderType.Name);
        }
    }

    /// <inheritdoc />
    protected override string PluginFolder => CoreSettings.Instance.PluginsPath;

    /// <inheritdoc />
    protected override string TempFolder => CoreSettings.Instance.TempPath;
}