namespace TableTime.DB
{
    public interface IDB <T, F, O>
    {
        F[] Get(T key);
        O Set(T key, F value);
        O Update(T key, F newValue);
        F[] GetAll();

    }
}
