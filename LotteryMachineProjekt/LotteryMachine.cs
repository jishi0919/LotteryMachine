using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryMachineProjekt
{
    public class LotteryMachine
    {
        Random random = new Random();
        public List<int> numberList = new List<int>();
        public LotteryMachine(int MaxAmountOfBalls)
        {
            for(int i = 1; i <= MaxAmountOfBalls; i++)
            {
                numberList.Add(i);
            }
        }

        public void Shuffle()
        {
            numberList = numberList.OrderBy(x => Guid.NewGuid()).ToList();
        }
        public int GetOneNumber()
        {
            if (numberList.Count == 0)
                return 0;
            int index = random.Next(0, numberList.Count);
            int number = numberList[index];
            numberList.RemoveAt(index);
            return number;
        }
    }
}
