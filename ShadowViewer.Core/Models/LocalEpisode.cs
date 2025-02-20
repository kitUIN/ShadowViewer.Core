﻿
using System;
using DryIoc;
using Serilog;
using ShadowPluginLoader.WinUI;
using SqlSugar;

namespace ShadowViewer.Core.Models
{
    /// <summary>
    /// 本地漫画-话
    /// </summary>
    public class LocalEpisode
    {
        public LocalEpisode() { }
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsNullable = false)]
        public long Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnDataType = "Nvarchar(2048)")]
        public string Name { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 所属的漫画
        /// </summary>
        [SugarColumn()]
        public long ComicId { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCounts { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public static LocalEpisode Create(string name, int order, long comicId, int counts, long size)
        {
            var db = DiFactory.Services.Resolve<ISqlSugarClient>();

            DateTime time = DateTime.Now;
            return new LocalEpisode()
            {
                Name = name,
                Order = order,
                ComicId = comicId,
                PageCounts = counts,
                Size = size,
                CreateTime = time,
            };
        }
        [SugarColumn(IsIgnore = true)]
        public static ILogger Logger { get; } = Log.ForContext<LocalEpisode>();
    }
}
