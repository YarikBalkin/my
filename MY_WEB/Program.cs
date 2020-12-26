
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using Dropbox.Api;
using Dropbox.Api.Common;
using Dropbox.Api.Files;
using Dropbox.Api.Team;
using NUnit.Framework;

namespace webApi
{
    public class Tests
    {
        [Test]
        public void TestMethod_Upload()
        {
            DropBox_App pr = new DropBox_App(); // Creating a class Object  
            pr.UploadAFile("local_file.txt");
        }
        [Test]
        public void TestMethod_GetMetadata()
        {
            DropBox_App pr = new DropBox_App(); // Creating a class Object  
            pr.GetFileMetadata();
        }
        [Test]
        public void TestMethod_Delete()
        {
            DropBox_App pr = new DropBox_App(); // Creating a class Object  
            pr.DeleteFile();
        }
        class Program
        {

            public static void Main(string[] args)
            {

                DropBox_App pr = new DropBox_App(); // Creating a class Object  
                pr.UploadAFile("local_file.txt");
                pr.GetFileMetadata();
                pr.DeleteFile();


            }
        }
    }
}
