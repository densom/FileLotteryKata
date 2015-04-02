namespace FileLotteryKata
{
    public interface IRandomProvider
    {
        int[] GetRandomUniqueValues();
        int SetMaxIndex { get; set; }
    }
}