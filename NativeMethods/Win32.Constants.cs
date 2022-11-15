using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Versioning;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Wind32API����
/// </summary>

namespace System
{
    public partial class Win32
    {


        public const byte AC_SRC_OVER = 0;
        public const Int32 ULW_ALPHA = 2;
        public const byte AC_SRC_ALPHA = 1;

        public const int GW_HWNDNEXT = 2;


        public const Int32 AW_HOR_POSITIVE = 0x00000001;    // ��������ʾ
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;    // ���ҵ�����ʾ
        public const Int32 AW_VER_POSITIVE = 0x00000004;    // ���ϵ�����ʾ
        /// <summary>
        /// ���µ�����ʾ
        /// </summary>
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        /// <summary>
        /// ��ʹ����AW_HIDE��־����ʹ���������ص������������ڣ�����ʹ����������չ����չ������
        /// </summary>
        public const Int32 AW_CENTER = 0x00000010;
        /// <summary>
        /// ���ش��ڣ�ȱʡ����ʾ����
        /// </summary>
        public const Int32 AW_HIDE = 0x00010000;
        /// <summary>
        /// ����ڡ���ʹ����AW_HIDE��־����ʹ�������־
        /// </summary>
        public const Int32 AW_ACTIVATE = 0x00020000;
        /// <summary>
        /// ʹ�û������͡�ȱʡ��Ϊ�����������͡���ʹ��AW_CENTER��־ʱ�������־�ͱ�����
        /// </summary>
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000;   // ͸���ȴӸߵ���


        public static int PS_SOLID = 0;




        [SuppressMessage("Microsoft.Performance", "CA1802:UseLiteralsWhereAppropriate")]
        public static readonly int TCM_SETITEM;
        [SuppressMessage("Microsoft.Performance", "CA1802:UseLiteralsWhereAppropriate")]
        public static readonly int TCM_INSERTITEM;


    }


}

