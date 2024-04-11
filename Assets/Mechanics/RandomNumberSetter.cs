public abstract class  RandomNumberSetter
{
    System.Random r = new System.Random();
    private int[] numbersArray = new int[] { 1, 2, 3,4,5,6,7,8,9 };
    protected virtual int[] SetRandom(int len) 
    {
        var result = new int[len];
        int rInt;
        for (int i = 0; i < 7; i++)
        {
            rInt = r.Next(0, 25);
            result[i] += numbersArray[rInt];
        }
        return result;
    }
}
