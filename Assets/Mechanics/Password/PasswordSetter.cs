public class PasswordSetter : RandomNumberSetter
{
    public int[] Pass { get { var val = SetRandom(4);  return val; } }

    protected override int[] SetRandom(int len)
    {
        return base.SetRandom(len);
    }
}
