using System;
using System.Reflection;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace DevFramework.Core.Aspects.PostSharp.ExceptionAspects
{
    [Serializable]
    public class ExceptionLogAspect: OnExceptionAspect
    {
        [NonSerialized]
        private LoggerService _loggerService;
        private Type _loggerType;

        public ExceptionLogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType != null)
            {
                if (_loggerType.BaseType != typeof(LoggerService))
                    throw new Exception("Wrong logger type");

                _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            }
            
            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            
            _loggerService?.Error(args.Exception);
        }
    }
}