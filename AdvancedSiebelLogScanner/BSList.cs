using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedSiebelLogScanner
{
    public class BSList
    {

        public BSList(string requestId, string bsName, string methodInvoked, DateTime startTime, DateTime endTime, int line, TimeSpan runTime)
        {
            this.RequestId = requestId;
            this.BsName = bsName;
            this.MethodInvoked = methodInvoked;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Line = line;
            this.RunTime = runTime;
        }
        public string RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }
        private string requestId;
        public string BsName
        {
            get { return bsName; }
            set { bsName = value; }
        }
        private string bsName;
        public string MethodInvoked
        {
            get { return methodInvoked; }
            set { methodInvoked = value; }
        }
        private string methodInvoked;
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime startTime;
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private DateTime endTime;
        public int Line
        {
            get { return line; }
            set { line = value; }
        }
        private int line;
        public TimeSpan RunTime
        {
            get { return runTime; }
            set { runTime = value; }
        }
        private TimeSpan runTime;
    }
}
