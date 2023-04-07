using System;
using System.Runtime.Serialization;

namespace ADMINPT.controles.ReportesBodegaJiboa.Melaza.TanqueNivel
{
    [Serializable]
    internal class cCallbackException : Exception
    {
        public cCallbackException()
        {
        }

        public cCallbackException(string message) : base(message)
        {
        }

        public cCallbackException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected cCallbackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}