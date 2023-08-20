﻿using Microsoft.Windows.ApplicationModel.Resources;
using ShadowViewer.Plugin.Local.Enums;

namespace ShadowViewer.Plugin.Local.Helpers
{
    /// <summary>
    /// 本地化 帮助类
    /// </summary>
    internal static class LocalResourcesHelper
    {
        private static readonly ResourceManager resourceManager = new ResourceManager();
        private static readonly string prefix = "ShadowViewer.Plugin.Local/Resources/";
        public static string GetString(string key)
        {
            return resourceManager.MainResourceMap.GetValue(prefix + key).ValueAsString;
        }
        public static string GetString(LocalResourceKey key)
        {
            return GetString(key.ToString());
        }
    }
}