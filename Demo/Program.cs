using System;

using HashProxy;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string algorithm = "SHA-512";
            byte[] data = new byte[] { (byte)'a' };
            string hash = HasherProxy.Compute(algorithm, data);
            Console.WriteLine(hash);
            Console.WriteLine(hash == "1F40FC92DA241694750979EE6CF582F2D5D7D28E18335DE05ABC54D0560E0F5302860C652BF08D560252AA5E74210546F369FBBBCE8C12CFC7957B2652FE9A75");
        }
    }
}
