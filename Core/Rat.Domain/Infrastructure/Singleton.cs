namespace Rat.Domain.Infrastructure
{
    public sealed class Singleton<T>
    {
        private static T instance;

        public static T Instance 
        { 
            get
            { 
                return instance;
            }
            set
            {
                instance = value;
            }
        }
    }
}
