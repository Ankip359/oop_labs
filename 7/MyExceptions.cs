using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    class GFException : Exception
    {
        public new string Message;

        public GFException(string message, string figure) : base(message)
        {
            Message = $"GeometricFigureException({figure}): " + message;
        }
    }

    class CEException : Exception
    {
        public new string Message;

        public CEException(string message, string element) : base(message)
        {
            Message = $"ControlElementException({element}): " + message;
        }
    }
}
