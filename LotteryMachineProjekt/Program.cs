using System;
using System.Collections.Generic;

namespace LotteryMachineProjekt
{
    class Program
    {
        private const int minBallCount = 1;
        private const int maxBallCount = 100;
        private static List<int> pickedNumberList = new List<int>();
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入球數(" + minBallCount +"~" + maxBallCount + ")");
            int ballCount = EnterBallCount();
            LotteryMachine machine = new LotteryMachine(ballCount);
            Start(machine);

            Console.WriteLine("");
            Console.WriteLine("您共抽到：");
            foreach (var item in pickedNumberList)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("剩餘號碼：");
            foreach (var item in machine.numberList)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("");
            Console.ReadLine();
        }
        private static void Start(LotteryMachine machine)
        {
            string action = GetCurrentStatusAndNextActions(machine);
            switch (action)
            {
                case "a":
                    machine.Shuffle();
                    Start(machine);
                    break;
                case "b":
                    if (machine.numberList.Count > 0)
                    {
                        int number = machine.GetOneNumber();
                        Console.WriteLine("您抽到：" + number + "號!");
                        pickedNumberList.Add(number);
                    }
                    else
                        Console.WriteLine("已無剩餘球，請輸入c結束");
                    Start(machine);
                    break;
                case "c": break;
            }
        }

        private static int EnterBallCount()
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int ballCount) && ballCount >= minBallCount && ballCount <= maxBallCount)
            {
                return ballCount;
            }
            else
            {
                Console.WriteLine("球數請輸入介於"+ minBallCount + "~" + maxBallCount + "正整數");
                return EnterBallCount();
            }
        }

        private static string GetCurrentStatusAndNextActions(LotteryMachine machine)
        {
            Console.WriteLine("目前剩餘球號碼：");
            foreach (var item in machine.numberList)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("請輸入執行動作：a.洗牌  b.抽牌  c.結束");
            string action = Console.ReadLine().ToLower();
            if(action != "a" && action != "b" && action != "c")
            {
                Console.WriteLine("操作錯誤。");
                return GetCurrentStatusAndNextActions(machine);
            }
            else
            {
                return action;
            }
        }
    }
}
