using Foundation;
using System;
using System.Runtime.InteropServices;
using UIKit;

namespace vs_test
{
    public partial class ViewController : UIViewController
    {
        [DllImport("__Internal", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern int ossl_store_init_once(); // from libopenssl.a

        [DllImport("__Internal", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr curl_easy_init(); // from libcurl.a

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Console.WriteLine(ossl_store_init_once()); // prints 1 in console

            var ptr = curl_easy_init(); // throws EntryPointNotFoundException curl_easy_init assembly:<unknown assembly> type:<unknown type> member:(null)
        }
    }
}
