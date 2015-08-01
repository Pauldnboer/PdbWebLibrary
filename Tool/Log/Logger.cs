using System;

namespace PDBWebLibrary.Tool.Log
{
    public class Logger
    {
        private static Logger instance;

        public static Logger Instance
        {
            get
            {
                return instance ?? (instance = new Logger());
            }
        }

        public Logger()
        {
        }

        public void Error(string error, Exception ex)
        {
            
        }

        public void Info(string info)
        {
            
        }

        public void Error(string error)
        {
            
        }
    
    }
}