﻿using DryIoc;
using Serilog;
using ShadowPluginLoader.WinUI;
using SqlSugar;
using System;

namespace ShadowViewer.Core.Cache
{
    /// <summary>
    /// 缓存的解压密码
    /// </summary>
    public class CacheZip
    {
        public CacheZip() { }
        [SugarColumn(ColumnDataType = "Nchar(32)", IsPrimaryKey = true, IsNullable = false)]
        public string? Id { get; private set; }
        public string? Md5 { get; private set; }
        [SugarColumn(ColumnDataType = "Nvarchar(1024)")]
        public string? Sha1 { get; private set; }
        [SugarColumn(ColumnDataType = "Nvarchar(2048)", IsNullable = true)]
        public string? Password { get; set; }

        [SugarColumn(ColumnDataType = "Nvarchar(2048)", IsNullable = true)]
        public string? Name { get; set; }
        [SugarColumn(ColumnDataType = "NText", IsNullable = true)]
        public string? CachePath { get; set; }
        [SugarColumn(IsNullable = true)]
        public long? ComicId { get; set; }

        public static string RandomId()
        {
            var db = DiFactory.Services.Resolve<ISqlSugarClient>();
            var id = Guid.NewGuid().ToString("N");
            while (db.Queryable<CacheZip>().Any(x => x.Id == id))
            {
                id = Guid.NewGuid().ToString("N");
            }

            return id;
        }
        public static CacheZip Create(string md5, string sha1, 
            string? password = null, string? cachePath = null)
        {
            // var db = DiFactory.Services.Resolve<ISqlSugarClient>();
            var id = RandomId();
            return new CacheZip()
            {
                Md5 = md5,
                Sha1 = sha1,
                Id = id,
                Password = password,
                CachePath = cachePath,
            };
        }

        [SugarColumn(IsIgnore = true)]
        public static ILogger Logger { get; } = Log.ForContext<CacheZip>();
    }
}
