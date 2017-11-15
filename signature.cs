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