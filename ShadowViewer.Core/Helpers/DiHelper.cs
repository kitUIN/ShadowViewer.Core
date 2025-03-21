using System.IO;
using Windows.Storage;
using DryIoc;
using Serilog;
using ShadowPluginLoader.WinUI;
using SqlSugar;
using ShadowViewer.Core.Services;
using ShadowViewer.Core;

namespace ShadowViewer.Core.Helpers;

/// <summary>
/// 依赖注入帮助类
/// </summary>
public static class DiHelper
{
    /// <summary>
    /// 初始化DI
    /// </summary>
    public static void Init()
    {
        var defaultPath = ConfigHelper.IsPackaged ? ApplicationData.Current.LocalFolder.Path : System.Environment.CurrentDirectory;
        DiFactory.Services.RegisterInstance<ISqlSugarClient>(new SqlSugarScope(new ConnectionConfig()
        {
            DbType = DbType.Sqlite,
            ConnectionString = $"DataSource={Path.Combine(defaultPath, "ShadowViewer.sqlite")}",
            IsAutoCloseConnection = true,
            MoreSettings = new ConnMoreSettings()
            {
                IsNoReadXmlDescription = true,
                SqliteCodeFirstEnableDefaultValue = true,
                SqliteCodeFirstEnableDescription = true,
            }
        },
            db =>
            {
                //单例参数配置，所有上下文生效
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Log.ForContext<ISqlSugarClient>().Debug("{Sql}", sql);
                };
            }));
        DiFactory.Services.Register<PluginLoader>(reuse: Reuse.Singleton);
    }
}