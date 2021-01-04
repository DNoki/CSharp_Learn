namespace CSharp_Learn
{
    /// <summary>
    /// 单例模式模板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class Singleton<T> where T : class, new()
    {
        private static T instance;
        private static readonly object locked = new object();
        /// <summary>
        /// 获取实例
        /// </summary>
        internal static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locked)
                    {
                        if (instance == null) instance = new T();
                    }
                }
                return instance;
            }
        }
    }
}
