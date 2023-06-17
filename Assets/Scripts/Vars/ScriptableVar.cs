namespace hYu
{
    public abstract class ScriptableVar<T> : ScriptableVarBase
    {
        public T value;

        public override void Reset()
        {
            value = default;
        }
    }
}