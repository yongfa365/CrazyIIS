using System;
using System.Runtime.InteropServices;
namespace WinNT
{
    public class NetUser
    {
        //创建用户
        [DllImport("Netapi32.dll")]
        extern static int NetUserAdd([MarshalAs(UnmanagedType.LPWStr)] string sName, int Level, ref USER_INFO_1 buf, int parm_err);
        //修改用户密码
        [DllImport("Netapi32.dll")]
        extern static int NetUserChangePassword([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string UserName, [MarshalAs(UnmanagedType.LPWStr)] string OldPassword, [MarshalAs(UnmanagedType.LPWStr)] string NewPassword);
        //删除用户
        [DllImport("Netapi32.dll")]
        extern static int NetUserDel([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string UserName);
        //枚举全部用户
        [DllImport("Netapi32.dll")]
        extern static int NetUserEnum([MarshalAs(UnmanagedType.LPWStr)] string sName, int Level, int filter, out IntPtr bufPtr, int Prefmaxlen, out int Entriesread, out int Totalentries, out int Resume_Handle);
        //获取用户信息
        [DllImport("Netapi32.dll")]
        extern static int NetUserGetInfo([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string UserName, int Level, out IntPtr intptr);
        //获取用户所在本地组
        [DllImport("Netapi32.dll")]
        extern static int NetUserGetLocalGroups([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string UserName, int Level, int Flags, out IntPtr intptr, int Prefmaxlen, out int Entriesread, out int Totalentries);
        //修改用户信息
        [DllImport("Netapi32.dll")]
        extern static int NetUserSetInfo([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string UserName, int Level, ref USER_INFO_1 bufptr, int parm_err);
        //释放API
        [DllImport("Netapi32.dll")]
        extern static int NetApiBufferFree(IntPtr Buffer);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct LOCALGROUP_USERS_INFO_0
        {
            public string GroupName;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct USER_INFO_1
        {
            public string sName;    //用户名
            public string sPass;    //用户密码
            public int PasswordAge; //密码级别
            public int sPriv;       //帐户类型 1 如果没有加入组，他会自动变成0，但不能设置为0
            public string sHomeDir; //用户主目录 null
            public string sComment; //用户描述
            public int sFlags;      //用户权限
            public string sScriptPath;  //登陆脚本路径 null
        }
        //枚举全部用户
        public string UserEnum()
        {
            string tempStr = "<?xml version=\"1.0\" encoding=\"gb2312\" ?>\r\n";
            tempStr += "<INFO>\r\n";
            int Entriesread;
            int TotalEntries;
            int Resume_Handle;
            IntPtr bufPtr;
            if (NetUserEnum(null, 1, 0, out bufPtr, -1, out Entriesread, out TotalEntries, out Resume_Handle) != 0)
            {
                //throw (new Exception("枚举全部用户失败"));
                return "枚举全部用户失败";
            }
            if (Entriesread > 0)
            {
                USER_INFO_1[] UserInfo = new USER_INFO_1[Entriesread];
                IntPtr iter = bufPtr;
                for (int i = 0; i < Entriesread; i++)
                {
                    UserInfo[i] = (USER_INFO_1)Marshal.PtrToStructure(iter, typeof(USER_INFO_1));
                    iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(USER_INFO_1)));
                    tempStr += "<ITEM value=\"" + UserInfo[i].sComment + "\">" + UserInfo[i].sName + "</ITEM>\r\n";
                }
                tempStr += "</INFO>";
            }
            NetApiBufferFree(bufPtr);
            return tempStr;
        }
        //读取用户信息
        public string UserGetInfo(string UserName)
        {
            string tmpStr = "<?xml version=\"1.0\" encoding=\"gb2312\" ?>\r\n";
            tmpStr += "<INFO>\r\n";
            IntPtr bufPtr;
            USER_INFO_1 UserInfo = new USER_INFO_1();
            if (NetUserGetInfo(null, UserName, 1, out bufPtr) != 0)
            {
                //throw (new Exception("读取用户信息失败"));
                return "读取用户信息失败";
            }
            else
            {
                UserInfo = (USER_INFO_1)Marshal.PtrToStructure(bufPtr, typeof(USER_INFO_1));
                tmpStr += "<NAME>" + UserInfo.sName + "</NAME>\r\n";
                tmpStr += "<PASS>" + UserInfo.sPass + "</PASS>\r\n";
                tmpStr += "<DESC>" + UserInfo.sComment + "</DESC>\r\n";
                tmpStr += "<sPriv>" + UserInfo.sPriv + "</sPriv>\r\n";
                tmpStr += "</INFO>";
                NetApiBufferFree(bufPtr);
                return tmpStr;
            }
        }
        //删除用户
        public bool UserDelete(string UserName)
        {
            if (NetUserDel(null, UserName) != 0)
            {
                //throw (new Exception("删除用户失败"));
                return false;
            }
            else
            {
                return true;
            }
        }
        //修改用户信息
        public bool UserSetInfo(string UserName, string NewUserName, string UserPass, string sDescription)
        {
            USER_INFO_1 UserInfo = new USER_INFO_1();
            UserInfo.sName = NewUserName;
            UserInfo.sPass = UserPass;
            UserInfo.PasswordAge = 0;
            UserInfo.sPriv = 1;
            UserInfo.sHomeDir = null;
            UserInfo.sComment = sDescription;
            UserInfo.sFlags = 0x0040 | 0x10000;
            UserInfo.sScriptPath = null;
            if (NetUserSetInfo(null, UserName, 1, ref UserInfo, 0) != 0)
            {
                //throw (new Exception("用户信息修改失败"));
                return false;
            }
            else
            {
                return true;
            }
        }

        //创建系统用户
        public bool UserAdd(string UserName, string UserPass, string sDescription)
        {
            USER_INFO_1 UserInfo = new USER_INFO_1();
            UserInfo.sName = UserName;
            UserInfo.sPass = UserPass;
            UserInfo.PasswordAge = 0;
            UserInfo.sPriv = 1;
            UserInfo.sHomeDir = null;
            UserInfo.sComment = sDescription;
            UserInfo.sFlags = 0x0040 | 0x10000;
            UserInfo.sScriptPath = null;
            if (NetUserAdd(null, 1, ref UserInfo, 0) != 0)
            {
                //throw (new Exception("创建系统用户失败"));
                return false;
            }
            else
            {
                return true;
            }
        }
        //修改用户密码
        public bool UserChangePassword(string UserName, string OldPassword, string NewPassword)
        {
            if (NetUserChangePassword(null, UserName, OldPassword, NewPassword) != 0)
            {
                //throw (new Exception("修改系统用户密码失败"));
                return false;
            }
            else
            {
                return true;
            }
        }

        //修改用户信息
        public bool UserChangePassword(string UserName, string UserPass)
        {
            IntPtr bufPtr;
            USER_INFO_1 UserInfo = new USER_INFO_1();
            if (NetUserGetInfo(null, UserName, 1, out bufPtr) != 0)
            {
                return false;
            }
            else
            {
                UserInfo = (USER_INFO_1)Marshal.PtrToStructure(bufPtr, typeof(USER_INFO_1));
                UserInfo.sPass = UserPass;

                if (NetUserSetInfo(null, UserName, 1, ref UserInfo, 0) != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }


        //获取用户全部所在本地组
        public string UserGetLocalGroups(string UserName)
        {
            int EntriesRead;
            int TotalEntries;
            IntPtr bufPtr;
            string tempStr = "<?xml version=\"1.0\" encoding=\"gb2312\" ?>\r\n";
            tempStr += "<INFO>\r\n";
            if (NetUserGetLocalGroups(null, UserName, 0, 0, out bufPtr, 1024, out EntriesRead, out TotalEntries) != 0)
            {
                //throw (new Exception("读取用户所在本地组失败"));
                return "读取用户所在本地组失败";
            }
            if (EntriesRead > 0)
            {
                LOCALGROUP_USERS_INFO_0[] GroupInfo = new LOCALGROUP_USERS_INFO_0[EntriesRead];
                IntPtr iter = bufPtr;
                for (int i = 0; i < EntriesRead; i++)
                {
                    GroupInfo[i] = (LOCALGROUP_USERS_INFO_0)Marshal.PtrToStructure(iter, typeof(LOCALGROUP_USERS_INFO_0));
                    iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(LOCALGROUP_USERS_INFO_0)));
                    tempStr += "<GROUP>" + GroupInfo[i].GroupName + "</GROUP>\r\n";
                }
                tempStr += "</INFO>";
                NetApiBufferFree(bufPtr);
            }
            return tempStr;
        }
    }
}