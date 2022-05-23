using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Module
{
    public static class FileHelper
    {
        /// <summary>
        /// ɾ���ļ����������ļ����ļ���
        /// </summary>
        /// <param name="srcPath"></param>
        public static void DelectDir(string srcPath)
        {
            DirectoryInfo dir = new DirectoryInfo(srcPath);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //����Ŀ¼�������ļ�����Ŀ¼
            foreach (FileSystemInfo i in fileinfo)
            {
                //�ж��Ƿ��ļ���
                if (i is DirectoryInfo)
                {
                    DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                    //ɾ����Ŀ¼���ļ�
                    subdir.Delete(true);
                }
                else
                {
                    //ɾ��ָ���ļ�
                    File.Delete(i.FullName);
                }
            }
        }

        /// <summary>
        /// �ж��Ƿ���ڴ��ļ��У�û�о��𼶴���
        /// </summary>
        /// <param name="dirPath"></param>
        public static void CreateDir(string dirPath)
        {
            for (int i = 0; i < dirPath.Length; i++)
            {
                if (dirPath[i] == '/')
                {
                    var p = dirPath.Substring(0, i + 1);
                    if (!Directory.Exists(p))
                    {
                        Directory.CreateDirectory(p);
                    }
                }
            }
        }

        /// <summary>
        /// �����Ե�ַת������Ե�ַ
        /// </summary>
        /// <param name="absolutePath"></param>
        /// <param name="relativeTo"></param>
        /// <returns></returns>
        public static string RelativePath(string absolutePath, string relativeTo)
        {
            //from - www.cnphp6.com

            string[] absoluteDirectories = absolutePath.Split('/');
            string[] relativeDirectories = relativeTo.Split('/');

            //Get the shortest of the two paths
            int length = absoluteDirectories.Length < relativeDirectories.Length ? absoluteDirectories.Length : relativeDirectories.Length;

            //Use to determine where in the loop we exited
            int lastCommonRoot = -1;
            int index;

            //Find common root
            for (index = 0; index < length; index++)
                if (absoluteDirectories[index] == relativeDirectories[index])
                    lastCommonRoot = index;
                else
                    break;

            //If we didn't find a common prefix then throw
            if (lastCommonRoot == -1)
                throw new ArgumentException("Paths do not have a common base");

            //Build up the relative path
            StringBuilder relativePath = new StringBuilder();

            //Add on the ..
            for (index = lastCommonRoot + 1; index < absoluteDirectories.Length; index++)
                if (absoluteDirectories[index].Length > 0)
                    relativePath.Append("../");

            //Add on the folders
            for (index = lastCommonRoot + 1; index < relativeDirectories.Length - 1; index++)
                relativePath.Append(relativeDirectories[index] + "/");
            relativePath.Append(relativeDirectories[relativeDirectories.Length - 1]);

            return relativePath.ToString();
        }
    }
}
