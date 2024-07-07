﻿using Microsoft.UI.Xaml.Media.Animation;

namespace ShadowViewer.Models
{
    /// <summary>
    /// 导航实例
    /// </summary>
    /// <param name="sourcePageType"></param>
    /// <param name="parameter"></param>
    /// <param name="infoOverride"></param>
    public class ShadowNavigation(Type? sourcePageType, object? parameter, NavigationTransitionInfo? infoOverride)
    {
        /// <summary>
        /// 跳转目标页
        /// </summary>
        public Type? PageType { get; } = sourcePageType;
        /// <summary>
        /// 导航跳转传递的参数
        /// </summary>
        public object? Parameter { get; } = parameter;
        /// <summary>
        /// 跳转动画
        /// </summary>
        public NavigationTransitionInfo? TransitionInfo { get; } = infoOverride;

        /// <summary />
        /// <param name="sourcePageType"></param>
        /// <param name="parameter"></param>
        public ShadowNavigation(Type? sourcePageType, object? parameter) : this(sourcePageType, parameter, null)
        {
        }

        /// <summary />
        /// <param name="sourcePageType"></param>
        public ShadowNavigation(Type? sourcePageType) : this(sourcePageType, null, null)
        {
        }
    }
}
