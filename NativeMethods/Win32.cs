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

/// <summary>
/// Wind32API����
/// </summary>

namespace System
{
    public partial class Win32
    {


        

        public const int GWL_EXSTYLE = -20;

        [StructLayout(LayoutKind.Sequential)]
        public struct SizeF
        {
            public Int32 cx;
            public Int32 cy;

            public SizeF(Int32 x, Int32 y)
            {
                cx = x;
                cy = y;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PointF
        {
            public Int32 x;
            public Int32 y;

            public PointF(Int32 x, Int32 y)
            {
                this.x = x;
                this.y = y;
            }
        }

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






        /// <summary>
        /// չʾ����API
        /// </summary>
        [DllImport("User32.dll", EntryPoint = "ShowWindow")]   //
        public static extern bool ShowWindow(IntPtr hWnd, int type);

        /// <summary>
        /// ����ָ�����ڵ���ʾ״̬�Լ���ԭ����С������󻯵�λ��
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// ִ�ж���
        /// </summary>
        /// <param name="whnd">�ؼ����</param>
        /// <param name="dwtime">����ʱ��</param>
        /// <param name="dwflag">�����������</param>
        /// <returns>boolֵ�������Ƿ�ɹ�</returns>
        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr whnd, int dwtime, int dwflag);

        /// <summary>
        /// <para>�ú�����ָ������Ϣ���͵�һ���������ڡ�</para>
        /// <para>�˺���Ϊָ���Ĵ��ڵ��ô��ڳ���ֱ�����ڳ���������Ϣ�ٷ��ء�</para>
        /// <para>������PostMessage��ͬ����һ����Ϣ���͵�һ���̵߳���Ϣ���к��������ء�</para>
        /// return ����ֵ : ָ����Ϣ����Ľ���������������͵���Ϣ��
        /// </summary>
        /// <param name="hWnd">Ҫ������Ϣ���Ǹ����ڵľ��</param>
        /// <param name="Msg">��Ϣ�ı�ʶ��</param>
        /// <param name="wParam">����ȡ������Ϣ</param>
        /// <param name="lParam">����ȡ������Ϣ</param>
        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessageA")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32", CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegisterWindowMessage(string msg);

        /// <summary>
        /// ����Բ�Ǵ���
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, Boolean bRedraw);

        /// <summary>
        /// ����Բ�Ǵ���
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hwnd, IntPtr hRgn, Boolean bRedraw);

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);

        /// <summary>
        /// ��õ��豸�����������������ڣ������ǿͻ�����
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref PointF pptDst, ref SizeF psize, IntPtr hdcSrc, ref PointF pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        /// <summary>
        /// ��ȡϵͳ�˵�
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        /// <summary>
        /// ��ȡ�˵�����
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int GetMenuItemCount(IntPtr hMenu);

        /// <summary>
        /// ���Ʋ˵�
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool DrawMenuBar(IntPtr hWnd);

        /// <summary>
        /// ɾ���˵�
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool RemoveMenu(IntPtr hMenu, Int32 uPosition, Int32 uFlags);
        
        /// <summary>
        /// �����Ӳ˵�
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetMenuItemBitmaps(IntPtr hMenu, Int32 nPosition, Int32 nFlags, Bitmap pBmpUnchecked, Bitmap pBmpchecked);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool InsertMenuItem(IntPtr hMenu, Int32 uItem, Int32 lpMenuItemInfo, bool fByPos);

        /// <summary>
        /// ��Ӳ˵�<br/>
        /// <param name="IDNewItem">IDNewItem��Ӧ����ID</param>
        /// </summary>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool AppendMenu(IntPtr hMenu, Int32 nFlags, Int32 IDNewItem, string lpNewItem);



        /// <summary>
        /// ��ָ��λ����ʾ��ݲ˵��������ٿ�ݲ˵��ϵ���Ŀѡ�񡣿�ݲ˵����Գ�������Ļ�ϵ��κ�λ��
        /// </summary>
        [DllImport("user32.dll")]
        public static extern uint TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// ���á�����ָ���Ĳ˵����ʹ�����
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr wnd, int msg, bool param, int lparam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

        [DllImport("user32.dll")]
        public static extern bool ShowScrollBar(IntPtr hWnd, int bar, int cmd);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        


    }
}

