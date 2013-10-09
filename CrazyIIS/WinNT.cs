using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;

namespace WinNT
{
    public class User
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">密码</param>
        /// <returns>返回 "OK" 或错误信息</returns>
        public static string Add(string UserName, string PassWord)
        {
            try
            {

                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry NewUser = dir.Children.Add(UserName, "User");
                NewUser.Invoke("SetPassword", PassWord); //用户密码
                //禁用登录帐号0x0002
                //用户不能更改密码0x0040
                //用户密码永不到期0x10000


                NewUser.Invoke("Put", "UserFlags", 0x0040 | 0x10000);
                NewUser.Invoke("Put", "Description", "IIS网站匿名用户");

                //NewUser.Properties["UserFlags"].Add(0x0040 | 0x10000);
                //NewUser.Properties["Description"].Add("IIS网站匿名用户");
                //NewUser.Properties["FullName"].Add(UserName); //用户全称
                NewUser.CommitChanges();


                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }



        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>返回 "OK" 或错误信息</returns>
        public static string Del(string UserName)
        {

            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                dir.Invoke("Delete", "User", UserName);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>返回 "OK" 或错误信息</returns>
        public static string Del(string[] UserNames)
        {

            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                foreach (string UserName in UserNames)
                {
                    dir.Invoke("Delete", "User", UserName);
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static List<String> List()
        {
            List<String> list = new List<String>();
            DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
            foreach (DirectoryEntry child in dir.Children)
            {
                if (child.SchemaClassName == "User")
                {
                    list.Add(child.Name);
                }
            }
            return list;
        }

        //{
        //    try
        //    {
        //        DirectoryEntry obComputer = new DirectoryEntry("WinNt://" + Environment.MachineName);//获得计算机实例
        //        DirectoryEntry obUser = obComputer.Children.Find(Username, "User");//找得用户
        //        obComputer.Children.Remove(obUser);//删除用户
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}




        /// <summary>
        /// 修改本地密码的方法
        /// </summary>
        /// <param name="intputPwd">输入的新密码</param>
        /// <returns>成功返回"success",失败返回exception</returns>
        public static string SetPassword(string intputPwd)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry user = dir.Children.Find("test", "User");
                user.Invoke("SetPassword", new object[] { intputPwd });
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public static bool ChangePassword(string UserName, string oldPwd, string newPwd)
        {
            try
            {
                DirectoryEntry MachineDirectoryEntry;
                MachineDirectoryEntry = new DirectoryEntry("WinNT://" + System.Environment.MachineName);
                DirectoryEntry CurrentDirectoryEntry = MachineDirectoryEntry.Children.Find(UserName);
                CurrentDirectoryEntry.Invoke("ChangePassword", new Object[] { oldPwd, newPwd });
                CurrentDirectoryEntry.CommitChanges();
                CurrentDirectoryEntry.Close();
                return true;
            }
            catch (Exception exp)
            {
                if (exp.InnerException.Message.Replace("'", "").IndexOf("网络密码不正确") != -1)
                    throw new Exception("密码修改失败,输入的原始密码不正确");
                else
                    throw new Exception(exp.InnerException.Message);
            }
            finally
            {
            }
        }

    }

    public class Group
    {

        public static string Add(string GroupName)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry newEntry = dir.Children.Add(GroupName, "Group");
                //newEntry.Properties["groupType"][0] = "4";
                //newEntry.Properties["Description"].Add("test");
                newEntry.CommitChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static string Del(string GroupName)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                dir.Invoke("Delete", "Group", GroupName);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }

    public class Other
    {


        public static string AddUserToGroup(string UserName, string GroupName)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry grp = dir.Children.Find(GroupName, "Group");
                DirectoryEntry obUser = dir.Children.Find(UserName, "User");
                if (grp.Name != "")
                {
                    grp.Invoke("Add", obUser.Path.ToString());//将用户添加到某组
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public static string DelUserFromGroup(string UserName, string GroupName)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry grp = dir.Children.Find(GroupName, "Group");
                DirectoryEntry obUser = dir.Children.Find(UserName, "User");
                if (grp.Name != "" && obUser.Name != "")
                {
                    grp.Invoke("Remove", obUser.Path.ToString());//将用户添加到某组
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }




        /// <summary>
        /// 根据本地用户组获得组里的用户名数组
        /// </summary>
        /// <param name="localGroup">本地用户组</param>
        /// <returns>用户名数组</returns>
        static List<String> GetUsersList(DirectoryEntry directoryEntry)
        {
            List<String> arrUsers = new List<String>();

            try
            {

                foreach (object member in (IEnumerable)directoryEntry.Invoke("Members"))
                {
                    DirectoryEntry dirmem = new DirectoryEntry(member);
                    arrUsers.Add(dirmem.Name);
                }
                return arrUsers;
            }
            catch { return arrUsers; }

        }

        /// <summary>
        /// 根据用户组,查询本地包含用户HashTable(含名称、全名、描述）的数组
        /// </summary>
        /// <param name="localGroup">用户组名称</param>
        /// <returns>包含用户HashTable(含名称、全名、描述）的数组</returns>
        public static List<String> GetUsersByGroup(string localGroup)
        {
            List<String> arr = new List<String>();//al返回HASHTABLE数组用

            try
            {

                DirectoryEntry group = new DirectoryEntry("WinNT://" + Environment.MachineName + "/" + localGroup + ",group");

                foreach (string user in GetUsersList(group))
                {
                    arr.Add(user);
                }
            }
            catch (Exception ex)
            {
                string errMsg = ex.ToString();
            }
            return arr;
        }


    }
}
