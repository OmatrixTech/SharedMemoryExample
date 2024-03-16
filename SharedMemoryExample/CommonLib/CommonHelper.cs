
using System.IO.MemoryMappedFiles;

namespace CommonLib
{
    public class CommonHelper
    {
        public MemoryMappedFile memoryMappedFile;
        // Private static instance variable to hold the single instance of the class
        private static CommonHelper instance;

        // Private static object for locking
        private static readonly object lockObject = new object();

        // Private constructor to prevent instantiation from outside the class
        private CommonHelper()
        {
            memoryMappedFile = MemoryMappedFile.CreateOrOpen("SharedMemory", 10000);
        }

        // Public static method to provide access to the single instance of the class
        public static CommonHelper GetInstance()
        {
            // Double-check locking to ensure thread safety
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new CommonHelper();
                    }
                }
            }
            return instance;
        }

    }

}
