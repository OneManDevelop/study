/*using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;*/

namespace sign
{
    class Signature
    {
        public void MakeSign(ref string msg)
        {
           msg = msg + "\n" + @"// by CsBot"; 
        }

    }
}
//change2