using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;

namespace NTFS
{
    class ACL
    {
        public enum Roles
        {
            FullControl,
            Read,
            Write,
            Modify

        }

        public static void Add(string Path, string UserName, FileSystemRights Role)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(Path);
            DirectorySecurity sec = dirinfo.GetAccessControl();
            sec.AddAccessRule(new FileSystemAccessRule(UserName, Role, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            dirinfo.SetAccessControl(sec);

        }

        public static string Add(string Path, string UserName, Roles Role)
        {
            try
            {
                DirectoryInfo dirinfo = new DirectoryInfo(Path);

                //取得访问控制列表   
                DirectorySecurity sec = dirinfo.GetAccessControl();
                switch (Role)
                {
                    case Roles.FullControl:
                        sec.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        break;
                    case Roles.Read:
                        sec.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.Read, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        break;
                    case Roles.Write:
                        sec.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.Write, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        break;
                    case Roles.Modify:
                        sec.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.Modify, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        break;
                }


                dirinfo.SetAccessControl(sec);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            //参数

            //    * path 要设置 NTFS 权限的文件夹。
            //    * identity 用户名。
            //    * rights FileSystemRights 对象，值为 FileSystemRights.Read、FileSystemRights.Write、FileSystemRights.FullControl 等，或者用“|”将多个权限合起来。

            //InheritanceFlags 指定哪些接受权限继承

            //    * InheritanceFlags.ContainerInherit 下级文件夹要继承权限。
            //    * InheritanceFlags.None 下级文件夹、文件都不继承权限。
            //    * InheritanceFlags.ObjectInherit 下级文件要继承权限。

            //上面提到“文件夹”、“文件”，更准确的说法应该是“容器”、“叶对象”，因为它不仅仅用于文件夹、文件，还可能用于其他地方，比如注册表权限。

            //PropagationFlags 如何传播权限

            //    * PropagationFlags.InheritOnly 不对 path 作设置，只是传播到下级。
            //    * PropagationFlags.None 不作设置，即既对 path 作设置，也传播到下级。
            //    * PropagationFlags.NoPropagateInherit 只是对 path 作设置，不传播到下级。

            //PropagationFlags 只是在 InheritanceFlags 不为 None 时才有意义。也就是说 InheritanceFlags 指定了哪类对象可接受权限继承（传播），而 PropagationFlags 指明了如何传播这些权限。


        }
        public static void Del(string Path, string UserName)
        {
            DirectoryInfo dInfo = new DirectoryInfo(Path);
            DirectorySecurity sec = dInfo.GetAccessControl();

            foreach (FileSystemAccessRule rule in sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                if (
                    rule.IdentityReference.Value.ToLower() == UserName.ToLower() ||
                    rule.IdentityReference.Value.ToLower().Contains("\\" + UserName.ToLower())
                    )
                {
                    sec.RemoveAccessRuleAll(rule);
                    break;
                }
            }
            dInfo.SetAccessControl(sec);
        }
        public static void DelErr(string Path)
        {
            DirectoryInfo dInfo = new DirectoryInfo(Path);
            DirectorySecurity sec = dInfo.GetAccessControl();

            foreach (FileSystemAccessRule rule in sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                if (rule.IdentityReference.Value.StartsWith("S-1-5-21"))
                {
                    sec.RemoveAccessRuleAll(rule);
                }
            }
            dInfo.SetAccessControl(sec);
        }


        public static List<String> List(string Path)
        {
            List<String> list = new List<String>();

            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(Path);
                DirectorySecurity sec = dInfo.GetAccessControl();

                foreach (FileSystemAccessRule rule in sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                {

                    string[] U = rule.IdentityReference.Value.Split('\\');

                    if (!list.Contains(U[U.Length - 1]))
                    {
                        list.Add(U[U.Length - 1]);
                    }

                }
            }
            catch
            {

            }

            return list;
        }


        /// <returns>String,FileSystemRights键值对</returns>  
        public static Hashtable GetACL(String FolderPath)
        {
            Hashtable ret = new Hashtable();
            DirectorySecurity sec = Directory.GetAccessControl(FolderPath, AccessControlSections.All);
            foreach (FileSystemAccessRule rule in sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                ret[rule.IdentityReference.Value] = rule.FileSystemRights;

            }
            return ret;
        }


        public static string GetACLString(String FolderPath)
        {
            StringBuilder sb = new StringBuilder();
            Hashtable rights = GetACL(FolderPath);
            foreach (string key in rights.Keys)
            {
                sb.Append(key + ":\t" + ((FileSystemRights)rights[key]).ToString() + "\r\n");
            }
            return sb.ToString();
        }

    }
}
