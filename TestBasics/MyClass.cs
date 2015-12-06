using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasics
{
    class MyClass
    {

        bool disposed = false;

        public void Dispose()
        {
            if (disposed == false)
            { 
                //在托管资源中调用Dispose
                //...
                //释放所有非托管的资源
            }
            disposed = true;
            GC.SuppressFinalize(this);
        }

        ~MyClass()
        { 
            if(disposed == false)
            {
                //释放所有非托管的资源
            }
        }
    }
}
