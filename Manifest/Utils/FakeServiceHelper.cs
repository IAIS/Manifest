using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HttpServer;
using Manifest.Shared;
using Warehouse.Exceptions;

namespace Manifest.Utils
{
    public class FakeServiceHelper
    {
        private static FakeServiceHelper _instance;
        private HttpServer.HttpListener _tagListener;
        private Random _random;

        private FakeServiceHelper()
        {
            this._random = new Random();
        }

        public static FakeServiceHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FakeServiceHelper();
            }
            return _instance;
        }

        public void Init()
        {
            _tagListener = HttpServer.HttpListener.Create(IPAddress.Any, 9090);
            _tagListener.RequestReceived += OnRequestTagReceived;
            _tagListener.Start(0);
        }

        private void OnRequestTagReceived(object sender, RequestEventArgs e)
        {
            IHttpClientContext context = (IHttpClientContext)sender;
            IHttpResponse response = e.Request.CreateResponse(context);

            try
            {
                int noOfBill = Int32.Parse(e.Request.Param["noOfBill"].Value);
                string consigneCode = e.Request.Param["consigneCode"].Value;
                List<String> bilList = new List<string>(noOfBill);
                for (int i = 0; i < noOfBill; i++)
                {
                    bilList.Add("BL" + this._random.Next());
                }

                Voyage voyage = new FakeHelper().GenerateFakeManifest("0000000000", bilList, this._random.Next().ToString(), "61041900", consigneCode, "IRBSR", "IRBND", "AEJEA");
                Utils.ParameterUtility.SetVoyage(voyage);

                ArchiveHelper.Compress("C:\\Tests\\fake-manifest\\fake-manifest.zip");
                String fakeManifest = Utils.Printer.GetResult();
                SendResponse(fakeManifest, response);
            }
            catch (Exception ex)
            {
                SendException(ex, response);
            }
            
        }

        private void SendResponse(string message, IHttpResponse response)
        {
            response.AddHeader("Access-Control-Allow-Origin", "*");
            StreamWriter writer = new StreamWriter(response.Body);
            writer.Write(message);
            writer.Flush();
            response.Send();
        }

        private void SendException(Exception ex, IHttpResponse response)
        {
            response.AddHeader("Access-Control-Allow-Origin", "*");
            StreamWriter writer = new StreamWriter(response.Body);
            writer.Write(ex.Message);
            writer.Flush();
            response.Send();
        }
    }
}
