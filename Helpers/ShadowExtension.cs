﻿namespace ShadowViewer.Helpers
{
    /// <summary>
    /// Shadow拓展方法类
    /// </summary>
    public static class ShadowExtension
    {
        private static ILogger Logger { get; } = Log.ForContext<FileHelper>();
        /// <summary>
        /// 是否是图片
        /// </summary> 
        public static bool IsPic(this StorageFile file)
        {
            bool flag = FileHelper.pngs.Contains(file.FileType);
            Logger.Debug("文件{Paht}是否是图片:{F}", file.Path, flag);
            return flag;
        }
        /// <summary>
        /// 是否是图片
        /// </summary> 
        public static bool IsPic(this string file)
        {
            string extension = Path.GetExtension(file);
            bool flag = FileHelper.pngs.Any(x => x == extension);
            Logger.Debug("文件{Paht}是否是图片:{F}", file, flag);
            return flag;
        }
        /// <summary>
        /// 是否是压缩文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsZip(this StorageFile file)
        {
            bool flag = FileHelper.zips.Contains(file.FileType);
            Logger.Debug("文件{Paht}是否是压缩包:{F}", file.Path, flag);
            return flag;
        }
        /// <summary>
        /// 从url获取StorageFolder,若没有则创建文件夹
        /// </summary>
        public static async Task<StorageFolder> ToStorageFolder(this string path)
        {
            path.CreateDirectory();
            return await StorageFolder.GetFolderFromPathAsync(path);
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void CreateDirectory(this string path)
        {
            string[] substrings = path.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string[] result = new string[substrings.Length];
            for (int i = 0; i < substrings.Length; i++)
            {
                result[i] = string.Join("/", substrings.Take(i + 1));
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (!Directory.Exists(result[i]))
                {
                    Directory.CreateDirectory(result[i]);
                    Logger.Information("文件夹{Dir}不存在,新建", result[i]);
                }
            }
        }
        /// <summary>
        /// 删除文件夹
        /// </summary>
        public static void DeleteDirectory(this string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                return;
            }
            File.SetAttributes(targetDir, System.IO.FileAttributes.Normal);
            foreach (string file in Directory.GetFiles(targetDir))
            {
                File.SetAttributes(file, System.IO.FileAttributes.Normal);
                File.Delete(file);
            }
            foreach (string subDir in Directory.GetDirectories(targetDir))
            {
                DeleteDirectory(subDir);
            }
            Directory.Delete(targetDir, false);
            Logger.Information("删除文件夹{Dir}", targetDir);
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        public static void CreateFile(this string path)
        {
            string[] substrings = path.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string[] result = new string[substrings.Length];
            for (int i = 0; i < substrings.Length; i++)
            {
                result[i] = string.Join("/", substrings.Take(i + 1));
            }
            for (int i = 0; i < result.Length - 1; i++)
            {
                if (!Directory.Exists(result[i]))
                {
                    Directory.CreateDirectory(result[i]);
                    Logger.Information("文件夹{Dir}不存在,新建", result[i]);
                }
            }
            if (!File.Exists(path))
            {
                File.Create(path);
                Logger.Information("文件{Dir}不存在,新建", path);
            }
        }
        /// <summary>
        /// 从url获取StorageFile,若没有则创建文件
        /// </summary>
        public static async Task<StorageFile> ToStorageFile(this string path)
        {
            path.CreateFile();
            return await StorageFile.GetFileFromPathAsync(path);
        }
        /// <summary>
        /// true -> Visible <br/>
        /// false -> Collapsed
        /// </summary>
        public static Visibility ToVisibility(this bool flag)
        {
            return flag ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
