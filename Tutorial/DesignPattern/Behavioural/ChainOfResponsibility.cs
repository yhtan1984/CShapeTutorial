using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioural.ChainOfResponsibility
{
    //Name      : Chain Of Responsibility
    //Intention : The chain of responsibility pattern creates a chain of receiver objects for a request. 
    //            normally each receiver contains reference to another receiver. If one object cannot handle the request then it passes the same to the next receiver and so on.
    //ref       : https://www.tutorialspoint.com/design_pattern/chain_of_responsibility_pattern.htm
    
    class ChainOfResponsibility:DemoClass
    {
        public override void execute()
        {
            AbstractLogger infoLog = new InfoLogger(AbstractLogger.LogType.Info);
            AbstractLogger debugLog = new InfoLogger(AbstractLogger.LogType.Debug);
            AbstractLogger errorLog = new InfoLogger(AbstractLogger.LogType.Error);

            //info as the starting of the chain.
            infoLog.setNextLog(debugLog);
            debugLog.setNextLog(errorLog);

            infoLog.Log(AbstractLogger.LogType.Error, "Error Log example\n");

            infoLog.Log(AbstractLogger.LogType.Info, "Info Log example\n");

            infoLog.Log(AbstractLogger.LogType.Debug, "Info Debug example\n");
        }
    }

    public abstract class AbstractLogger
    {
        public enum LogType
        {
            Info,
            Debug,
            Error
        }

        public AbstractLogger(AbstractLogger.LogType logType)
        {
            this.logLevel = (int)logType;
            this.logType = logType.GetType().Name;
        }

        protected AbstractLogger nextLogger;
        protected int logLevel;
        protected string logType;

        public void setNextLog(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        public void Log(LogType logType, string logMassage)
        {
            if (this.logLevel == (int)logType)
            { Console.WriteLine("{0} log: {1}", logType, logMassage); }
            else
                nextLogger.Log(logType, logMassage);
        }
    }

    public class InfoLogger : AbstractLogger
    {
        public InfoLogger(AbstractLogger.LogType logType):
            base(logType)
        {
        }
    }

    public class DebugLogger : AbstractLogger
    {
        public DebugLogger(AbstractLogger.LogType logType):base(logType)
        {
        }
    }

    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(AbstractLogger.LogType logType):base(logType)
        {
        }
    }

}
