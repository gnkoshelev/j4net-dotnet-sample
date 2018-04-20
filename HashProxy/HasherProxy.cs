using J4Net.Core;
using J4Net.Core.JNICore.Interface;

namespace HashProxy
{
    public class HasherProxy
    {
        private static GlobalRef classRef;
        private static GlobalRef methodRef;
        static HasherProxy()
        {
            JniEnvWrapper env = JvmManager.INSTANCE.GetEnv();
            classRef = env.FindClass("ru/gnkoshelev/j4net/sample/hash/lib/Hasher");
            methodRef = env.GetStaticMethodId(classRef.Ptr, "compute", "(Ljava/lang/String;[B)Ljava/lang/String;");
        }
        public static string Compute(string algorithm, byte[] bytes)
        {
            JniEnvWrapper env = JvmManager.INSTANCE.GetEnv();
            using (var jString = env.NewStringUtf(algorithm))
            {
                using (var jByteArray = env.NewByteArray(bytes))
                {
                    using (var localRef = env.CallStaticObjectMethod(classRef.Ptr, methodRef.Ptr, new JValue { PointerValue = jString.Ptr }, new JValue { PointerValue = jByteArray.Ptr }))
                    {
                        return env.GetString(localRef.Ptr);
                    }
                }
            }
        }
    }
}
