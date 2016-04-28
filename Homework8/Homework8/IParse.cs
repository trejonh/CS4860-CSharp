namespace Homework8
{
    public interface IParse<out T>
    {
        T Parse(byte[] buffer);
    }
}
