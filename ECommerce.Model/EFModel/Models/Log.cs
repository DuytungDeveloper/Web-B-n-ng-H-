using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ECommerce.Model.EFModel.Models
{
    public class Log : BaseModel, IBaseModel
    {
        public Log()
        {
            this.Id = Guid.NewGuid();
            this.CreateDate = DateTime.Now;
        }

        public Nullable<Guid> Id { get; set; }
        public string ErrorLog { get; set; }
        public string TargetName { get; set; }
        public string UserId { get; set; }
        public Nullable<int> Type { get; set; }
        public string BaseRequest { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public string Headers { get; set; }
        public string Authority { get; set; }
        public string PathAndQuery { get; set; }
        public string UserInfo { get; set; }
        public string ApplicationPath { get; set; }
        public string PhysicalApplicationPath { get; set; }
        public string Browser { get; set; }
        public string HttpMethod { get; set; }
        public string ServerVariables { get; set; }
        public string ClientIP { get; set; }
        //public string LocalAddr { get; set; }
        //public string ServerIP { get; set; }
        public string Params { get; set; }

        public string MetadataException
        {
            get
            {
                try
                {
                    if (this.Exception != null)
                    {
                        // Get stack trace for the exception with source file information
                        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(this.Exception, true);
                        var frame = trace.GetFrame(0);
                        var data = new
                        {
                            method = frame.GetMethod() != null ? frame.GetMethod().Name : "",
                            filename = frame.GetFileName(),
                            line = frame.GetFileLineNumber(),
                            str = frame.ToString(),
                        };

                        return Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        public int LineNumber
        {
            get
            {
                int linenum = 0;
                try
                {
                    linenum = Convert.ToInt32(this.Exception.StackTrace.Substring(this.Exception.StackTrace.LastIndexOf(":line") + 5));
                }
                catch
                {
                    //Stack trace is not available!
                }
                return linenum;
            }
        }

        public class InfoException
        {
            public string FileName { get; set; }
            public int? LineNumber { get; set; }
            public int? ColumnNumber { get; set; }
            public MethodBase Method { get; internal set; }
            public Type Class { get; internal set; }
        }

        public string Level { get; set; }
    }
}
