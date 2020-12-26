using System;
using System.Collections.Generic;
using System.Text;


namespace webApi
{
    public class DropBox_App
    {
        public void UploadAFile(string file_name)
        {

            Chilkat.Rest rest = new Chilkat.Rest();

            //  Connect to Dropbox
            bool success = rest.Connect("content.dropboxapi.com", 443, true, true);
            if (success != true)
            {
                Console.WriteLine(rest.LastErrorText);
                return;
            }

            //  Add request headers.
            rest.AddHeader("Content-Type", "application/octet-stream");
            rest.AddHeader("Authorization", "Bearer sl.AoE--WXsSzFEI7UGdO1XulmCYfhd_VM-i7N7ymib5t9HTDrZblyEeLsxvxe1gQRHmZPoSZZJJmL5aHbcypNXP8qjfJCbEYcewNZWeHXQJS1UXP8SxYyncHmOb3cukGGhtz3zSQleZTk");

            //  The upload "parameters" contained in JSON passed in an HTTP request header.

            Chilkat.JsonObject json = new Chilkat.JsonObject();
            json.AppendString("path", "/"+file_name);
            json.AppendString("mode", "add");
            json.AppendBool("autorename", true);
            json.AppendBool("mute", false);
            rest.AddHeader("Dropbox-API-Arg", json.Emit());

            //  Almost ready to go...
            //  Let's setup a file stream to point to a file.
            Chilkat.Stream fileStream = new Chilkat.Stream();
            fileStream.SourceFile = file_name;

            //  Do the upload.  The URL is https://content.dropboxapi.com/2/files/upload.
            //  We already connected to content.dropboxapi.com using TLS (i.e. HTTPS),
            //  so now we only need to specify the path "/2/files/upload".

            //  Note: The file is streamed directly from disk.  (The entire
            //  file will not be loaded into memory.)
            string responseStr = rest.FullRequestStream("POST", "/2/files/upload", fileStream);
            if (rest.LastMethodSuccess != true)
            {
                Console.WriteLine(rest.LastErrorText);
                return;
            }

            //  When successful, Dropbox responds with a 200 response code.
            if (rest.ResponseStatusCode != 200)
            {
                //  Examine the request/response to see what happened.
                Console.WriteLine("response status code = " + Convert.ToString(rest.ResponseStatusCode));
                Console.WriteLine("response status text = " + rest.ResponseStatusText);
                Console.WriteLine("response header: " + rest.ResponseHeader);
                Console.WriteLine("response body (if any): " + responseStr);
                Console.WriteLine("---");
                Console.WriteLine("LastRequestStartLine: " + rest.LastRequestStartLine);
                Console.WriteLine("LastRequestHeader: " + rest.LastRequestHeader);
                return;
            }

            //  The response is JSON.
            Chilkat.JsonObject jsonResp = new Chilkat.JsonObject();
            jsonResp.EmitCompact = false;
            jsonResp.Load(responseStr);

            //  Show the JSON response.
            Console.WriteLine(jsonResp.Emit());

            //  Returns JSON that looks like this:
            //  {
            //    "name": "hamlet.xml",
            //    "path_lower": "/homework/lit/hamlet.xml",
            //    "path_display": "/Homework/lit/hamlet.xml",
            //    "id": "id:74FkdeNuyKAAAAAAAAAAAQ",
            //    "client_modified": "2016-06-02T23:19:00Z",
            //    "server_modified": "2016-06-02T23:19:00Z",
            //    "rev": "9482db15f",
            //    "size": 279658
            //  }

            //  Sample code to get data from the JSON response:
            int size = jsonResp.IntOf("size");
            Console.WriteLine("size = " + Convert.ToString(size));

            string rev = jsonResp.StringOf("rev");
            Console.WriteLine("rev = " + rev);

            string clientModified = jsonResp.StringOf("client_modified");
            Chilkat.CkDateTime ckdt = new Chilkat.CkDateTime();
            ckdt.SetFromTimestamp(clientModified);
            bool bLocalTime = true;
            Chilkat.DtObj dt = ckdt.GetDtObj(bLocalTime);
            Console.WriteLine(Convert.ToString(dt.Day) + "/" + Convert.ToString(dt.Month) + "/" + Convert.ToString(dt.Year) + " " + Convert.ToString(dt.Hour)
                 + ":" + Convert.ToString(dt.Minute));
        }
        public void GetFileMetadata()
        {
            Chilkat.Rest rest = new Chilkat.Rest();
            bool success;

            //  URL: https://api.dropboxapi.com/2/files/get_metadata
            bool bTls = true;
            int port = 443;
            bool bAutoReconnect = true;
            success = rest.Connect("api.dropboxapi.com", port, bTls, bAutoReconnect);
            if (success != true)
            {
                System.Diagnostics.Debug.WriteLine("ConnectFailReason: " + Convert.ToString(rest.ConnectFailReason));
                System.Diagnostics.Debug.WriteLine(rest.LastErrorText);
                return;
            }

            //  Note: The above code does not need to be repeatedly called for each REST request.
            //  The rest object can be setup once, and then many requests can be sent.  Chilkat will automatically
            //  reconnect within a FullRequest* method as needed.  It is only the very first connection that is explicitly
            //  made via the Connect method.

            //  The following JSON is sent in the request body.


            Chilkat.JsonObject json = new Chilkat.JsonObject();
            json.UpdateString("path", "/local_file.txt");
            json.UpdateBool("include_media_info", false);
            json.UpdateBool("include_deleted", false);
            json.UpdateBool("include_has_explicit_shared_members", false);

            rest.AddHeader("Authorization", "Bearer sl.AoE--WXsSzFEI7UGdO1XulmCYfhd_VM-i7N7ymib5t9HTDrZblyEeLsxvxe1gQRHmZPoSZZJJmL5aHbcypNXP8qjfJCbEYcewNZWeHXQJS1UXP8SxYyncHmOb3cukGGhtz3zSQleZTk");
            rest.AddHeader("Content-Type", "application/json");

            Chilkat.StringBuilder sbRequestBody = new Chilkat.StringBuilder();
            json.EmitSb(sbRequestBody);
            Chilkat.StringBuilder sbResponseBody = new Chilkat.StringBuilder();
            success = rest.FullRequestSb("POST", "/2/files/get_metadata", sbRequestBody, sbResponseBody);
            if (success != true)
            {
                System.Diagnostics.Debug.WriteLine(rest.LastErrorText);
                return;
            }

            int respStatusCode = rest.ResponseStatusCode;
            System.Diagnostics.Debug.WriteLine("response status code = " + Convert.ToString(respStatusCode));
            if (respStatusCode >= 400)
            {
                System.Diagnostics.Debug.WriteLine("Response Status Code = " + Convert.ToString(respStatusCode));
                System.Diagnostics.Debug.WriteLine("Response Header:");
                System.Diagnostics.Debug.WriteLine(rest.ResponseHeader);
                System.Diagnostics.Debug.WriteLine("Response Body:");
                System.Diagnostics.Debug.WriteLine(sbResponseBody.GetAsString());
                return;
            }


        }
        public void DeleteFile()
        {
            Chilkat.Rest rest = new Chilkat.Rest();
            bool success;

            //  URL: https://api.dropboxapi.com/2/files/delete_v2
            bool bTls = true;
            int port = 443;
            bool bAutoReconnect = true;
            success = rest.Connect("api.dropboxapi.com", port, bTls, bAutoReconnect);
            if (success != true)
            {
                System.Diagnostics.Debug.WriteLine("ConnectFailReason: " + Convert.ToString(rest.ConnectFailReason));
                System.Diagnostics.Debug.WriteLine(rest.LastErrorText);
                return;
            }

            //  Note: The above code does not need to be repeatedly called for each REST request.
            //  The rest object can be setup once, and then many requests can be sent.  Chilkat will automatically
            //  reconnect within a FullRequest* method as needed.  It is only the very first connection that is explicitly
            //  made via the Connect method.

            //  The following JSON is sent in the request body.
            Chilkat.JsonObject json = new Chilkat.JsonObject();
            json.UpdateString("path", "/local_file.txt");

            rest.AddHeader("Authorization", "Bearer sl.AoE--WXsSzFEI7UGdO1XulmCYfhd_VM-i7N7ymib5t9HTDrZblyEeLsxvxe1gQRHmZPoSZZJJmL5aHbcypNXP8qjfJCbEYcewNZWeHXQJS1UXP8SxYyncHmOb3cukGGhtz3zSQleZTk");
            rest.AddHeader("Content-Type", "application/json");

            Chilkat.StringBuilder sbRequestBody = new Chilkat.StringBuilder();
            json.EmitSb(sbRequestBody);
            Chilkat.StringBuilder sbResponseBody = new Chilkat.StringBuilder();
            success = rest.FullRequestSb("POST", "/2/files/delete_v2", sbRequestBody, sbResponseBody);
            if (success != true)
            {
                System.Diagnostics.Debug.WriteLine(rest.LastErrorText);
                return;
            }

        }
        }
}
