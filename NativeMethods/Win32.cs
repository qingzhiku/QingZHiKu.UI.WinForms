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






        ///// <summary>
        ///// չʾ����API
        ///// </summary>
        //[DllImport("User32.dll", EntryPoint = "ShowWindow")]   //
        //public static extern bool ShowWindow(IntPtr hWnd, int type);

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

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

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

        [DllImport("user32.dll")]
        public static extern IntPtr DeleteMenu(IntPtr hMenu, Int32 nPosition, Int32 wFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr DeleteMenu(IntPtr hMenu, long nPosition, long wFlags);

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

        [DllImport("user32.dll")]
        public static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetSubMenu")]
        public static extern IntPtr GetSubMenu(IntPtr hMenu, int nPos);

        [DllImport("user32.dll", EntryPoint = "GetMenuItemID")]
        public static extern IntPtr GetMenuItemID(IntPtr hMenu, int nPos);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

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

        public enum SM_Index : int
        {
            SM_CXSCREEN = 0, // ��Ļ���
            SM_CYSCREEN = 1, // ��Ļ�߶�
            SM_CXVSCROLL = 2, // ��ֱ�������Ŀ��
            SM_CYHSCROLL = 3, // ˮƽ�������Ŀ��
            SM_CYCAPTION = 4, // Height of windows caption ʵ�ʱ���߶ȼ���SM_CYBORDER
            SM_CXBORDER = 5, // Width of no-sizable borders �޷������Ĵ��ڿ�ܿ��
            SM_CYBORDER = 6, // Height of non-sizable borders �޷������Ĵ��ڿ�ܸ߶�
            SM_CXDLGFRAME = 7, // Width of dialog box borders
            SM_CYDLGFRAME = 8, // Height of dialog box borders
            SM_CYHTHUMB = 9, // Height of scroll box on horizontal scroll bar ˮƽ�������ϻ���ĸ߶�
            SM_CXHTHUMB = 10, // Width of scroll box on horizontal scroll bar ˮƽ�������ϻ���Ŀ��
            SM_CXICON = 11, // Width of standard icon ͼ����
            SM_CYICON = 12, // Height of standard icon ͼ��߶�
            SM_CXCURSOR = 13, // Width of standard cursor �����
            SM_CYCURSOR = 14, // Height of standard cursor ���߶�
            SM_CYMENU = 15, // Height of menu �����ؼ���ĵ����˵����ĸ߶�
            SM_CXFULLSCREEN = 16, // Width of client area of maximized window
            SM_CYFULLSCREEN = 17, // Height of client area of maximized window
            SM_CYKANJIWINDOW = 18, // Height of Kanji window
            SM_MOUSEPRESENT = 19, // True is a mouse is present ���ΪTRUE��Ϊ0��ֵ��װ����꣬����û�а�װ��
            SM_CYVSCROLL = 20, // Height of arrow in vertical scroll bar
            SM_CXHSCROLL = 21, // Width of arrow in vertical scroll bar
            SM_DEBUG = 22, // rTue if deugging version of windows is running
            SM_SWAPBUTTON = 23, // True if left and right buttons are swapped.
            SM_CXMIN = 28, // Minimum width of window
            SM_CYMIN = 29, // Minimum height of window
            SM_CXSIZE = 30, // Width of title bar bitmaps
            SM_CYSIZE = 31, // height of title bar bitmaps
            SM_CXFRAME = 32, // Width of window frame
            SM_CYFRAME = 33, // Height of window frame
            SM_CXMINTRACK = 34, // Minimum tracking width of window
            SM_CYMINTRACK = 35, // Minimum tracking height of window
            SM_CXDOUBLECLK = 36, // double click width
            SM_CYDOUBLECLK = 37, // double click height
            SM_CXICONSPACING = 38, // width between desktop icons
            SM_CYICONSPACING = 39, // height between desktop icons
            SM_MENUDROPALIGNMENT = 40, // Zero if popup menus are aligned to the left of the memu bar item. True if it is aligned to the right.
            SM_PENWINDOWS = 41, // The handle of the pen windows DLL if loaded.
            SM_DBCSENABLED = 42, // True if double byte characteds are enabled
            SM_CMOUSEBUTTONS = 43, // Number of mouse buttons.
            SM_CMETRICS = 44, // Number of system metrics
            SM_CLEANBOOT = 67, // Windows 95 boot mode. 0 = normal, 1 = safe, 2 = safe with network
            SM_CXMAXIMIZED = 61, // default width of win95 maximised window
            SM_CXMAXTRACK = 59, // maximum width when resizing win95 windows
            SM_CXMENUCHECK = 71, // width of menu checkmark bitmap
            SM_CXMENUSIZE = 54, // width of button on menu bar
            SM_CXMINIMIZED = 57, // width of rectangle into which minimised windows must fit.
            SM_CYMAXIMIZED = 62, // default height of win95 maximised window
            SM_CYMAXTRACK = 60, // maximum width when resizing win95 windows
            SM_CYMENUCHECK = 72, // height of menu checkmark bitmap
            SM_CYMENUSIZE = 55, // height of button on menu bar
            SM_CYMINIMIZED = 58, // height of rectangle into which minimised windows must fit.
            SM_CYSMCAPTION = 51, // height of windows 95 small caption
            SM_MIDEASTENABLED = 74, // Hebrw and Arabic enabled for windows 95
            SM_NETWORK = 63, // bit o is set if a network is present.
            SM_SECURE = 44, // True if security is present on windows 95 system
            SM_SLOWMACHINE = 73, // true if machine is too slow to run win95.
            SM_CXPADDEDBORDER = 92, // width of window border, in pixels, when a window has a caption but no borders
        }

       [DllImport("user32")]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32")]
        public static extern  int GetSystemMetricsForDpi(int nIndex,int dpi);

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
        
        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();

        [StructLayout(LayoutKind.Sequential)]
        public class COMRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public COMRECT()
            {
            }

            public COMRECT(System.Drawing.Rectangle r)
            {
                this.left = r.X;
                this.top = r.Y;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }


            public COMRECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            /* Unused
            public RECT ToRECT() {
                return new RECT(left, top, right, bottom);
            }
            */

            public static COMRECT FromXYWH(int x, int y, int width, int height)
            {
                return new COMRECT(x, y, x + width, y + height);
            }

            public override string ToString()
            {
                return "Left = " + left + " Top " + top + " Right = " + right + " Bottom = " + bottom;
            }
        }
        
        public const int RDW_INVALIDATE = 0x0001;
        public const int RDW_ERASE = 0x0004;
        public const int RDW_ALLCHILDREN = 0x0080;
        public const int RDW_ERASENOW = 0x0200;
        public const int RDW_UPDATENOW = 0x0100;
        public const int RDW_FRAME = 0x0400;
        
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool RedrawWindow(IntPtr hwnd, COMRECT rcUpdate, IntPtr hrgnUpdate, int flags);


        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetWindowRect(IntPtr hWnd, [In, Out] ref Win32.RECT rect);
        
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);
        
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetDlgItem(IntPtr hWnd, int nIDDlgItem);
        
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern IntPtr GetModuleHandle(string modName);
        
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr DefMDIChildProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg,IntPtr wParam, IntPtr lParam);

        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,  int x, int y, int cx, int cy, int flags);



        

    }

    
}

