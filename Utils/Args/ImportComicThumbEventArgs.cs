﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowViewer.Utils.Args
{
    /// <summary>
    /// 导入漫画的缩略图
    /// </summary>
    public class ImportComicThumbEventArgs
    {
        public MemoryStream Thumb { get; }
        public ImportComicThumbEventArgs(MemoryStream thumb)
        {
            Thumb = thumb;
        }
    }
}
