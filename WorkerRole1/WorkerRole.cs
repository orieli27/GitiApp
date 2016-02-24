using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using System.Web;
using System.IO;
using Com.Imagga.Api.Imagga;
using Com.Imagga.Api.Imagga.Api;
using Com.Imagga.Api.Imagga.Model;
using Com.Imagga.Api.Imagga.Client;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("WorkerRole1 is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole1 has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole1 has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
             //   TestTaggingTagging();

                await Task.Delay(1000);
            }
        }
        public void TestTaggingTagging()
        {
            // authentication setting using user name and password
            Configuration.Username = "acc_4e8f07b9378a41e";
            Configuration.Password = "7a8007de4812bf0b19eb2e656f54d52a";

            String url = "http://thumbs.dreamstime.com/z/chef-cook-baker-mixing-bowl-cartoon-27376733.jpg";  // url
            String content = "sampleContent";  // Content id received by uploading an image to the content...

            try
            {
                // first arguemnt 'basePath' is optional
                //TaggingApi taggingApi = new TaggingApi("https://api.imagga.com/v1");
               // TaggingResponse response = taggingApi.Tagging(url, content);
               // Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            // Add "Assert" here. Ref: http://www.nunit.org/index.php?p=assertions&r=2.6.4
        }
    }
}
