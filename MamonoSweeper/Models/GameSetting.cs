namespace MamonoSweeper.Models
{
    public class GameSetting
    {
        public string Token { get; set; }
        public int Mode { get; set; }
        public int CountRow { get; set; }
        public int CountCol { get; set; }
        public int TotalNumber { get; set; }
        public int CountLv1 { get; set; }
        public int CountLv2 { get; set; }
        public int CountLv3 { get; set; }
        public int CountLv4 { get; set; }
        public int CountLv5 { get; set; }
        public int CountLv6 { get; set; }
        public int CountLv7 { get; set; }
        public int CountLv8 { get; set; }
        public int CountLv9 { get; set; }
        public int[] CountArray { get; set; }
        public int ExpToLv2 { get; set; }
        public int ExpToLv3 { get; set; }
        public int ExpToLv4 { get; set; }
        public int ExpToLv5 { get; set; }
        public int ExpToLv6 { get; set; }
        public int ExpToLv7 { get; set; }
        public int ExpToLv8 { get; set; }
        public int ExpToLv9 { get; set; }
        public int[] ExpArray { get; set; }
        public int[,] MineField { get; set; }
        public string GameType { get; set; }
        public int LV { get; set; }
        public int HP { get; set; }
        public string Color { get; set; }
        public GameSetting(int Mode = 1)
        {
            this.Mode = Mode;
            switch (Mode)
            {
                case 2:
                    {
                        GameType = "Normal"; Color = "#483818";
                        CountRow = 16; CountCol = 30; HP = 10; LV = 1;
                        CountLv1 = 33; CountLv2 = 27; CountLv3 = 20; CountLv4 = 13; CountLv5 = 6; CountLv6 = 0; CountLv7 = 0; CountLv8 = 0; CountLv9 = 0;
                        ExpToLv2 = 10; ExpToLv3 = 50; ExpToLv4 = 167; ExpToLv5 = 271;
                    }
                    break;
                case 3:
                    {
                        GameType = "Huge"; Color = "#207519";
                        CountRow = 25; CountCol = 50; HP = 30; LV = 1;
                        CountLv1 = 52; CountLv2 = 46; CountLv3 = 40; CountLv4 = 36; CountLv5 = 30; CountLv6 = 24; CountLv7 = 18; CountLv8 = 13; CountLv9 = 1;
                        ExpToLv2 = 10; ExpToLv3 = 90; ExpToLv4 = 202; ExpToLv5 = 400; ExpToLv6 = 1072; ExpToLv7 = 1840; ExpToLv8 = 2992; ExpToLv9 = 4656;
                    }
                    break;
                case 4:
                    {
                        GameType = "Extreme"; Color = "#2080b0";
                        CountRow = 16; CountCol = 30; HP = 10; LV = 1;
                        CountLv1 = 25; CountLv2 = 25; CountLv3 = 25; CountLv4 = 25; CountLv5 = 25; CountLv6 = 0; CountLv7 = 0; CountLv8 = 0; CountLv9 = 0;
                        ExpToLv2 = 10; ExpToLv3 = 50; ExpToLv4 = 175; ExpToLv5 = 375;
                    }
                    break;
                case 5:
                    {
                        GameType = "Blind"; Color = "#505050";
                        CountRow = 16; CountCol = 30; HP = 1; LV = 0;
                        CountLv1 = 33; CountLv2 = 27; CountLv3 = 20; CountLv4 = 13; CountLv5 = 6; CountLv6 = 0; CountLv7 = 0; CountLv8 = 0; CountLv9 = 0;
                        ExpToLv2 = 9999; ExpToLv3 = 9999; ExpToLv4 = 9999; ExpToLv5 = 9999;
                    }
                    break;
                case 6:
                    {
                        GameType = "Huge_Extreme"; Color = "#30a0c0";
                        CountRow = 25; CountCol = 50; HP = 10; LV = 1;
                        CountLv1 = 36; CountLv2 = 36; CountLv3 = 36; CountLv4 = 36; CountLv5 = 36; CountLv6 = 36; CountLv7 = 36; CountLv8 = 36; CountLv9 = 36;
                        ExpToLv2 = 10; ExpToLv3 = 0; ExpToLv4 = 0; ExpToLv5 = 0; ExpToLv6 = 0; ExpToLv7 = 0; ExpToLv8 = 0; ExpToLv9 = 0;
                    }
                    break;
                case 7:
                    {
                        GameType = "Huge_Blind"; Color = "#909090";
                        CountRow = 25; CountCol = 50; HP = 1; LV = 0;
                        CountLv1 = 52; CountLv2 = 46; CountLv3 = 40; CountLv4 = 36; CountLv5 = 30; CountLv6 = 24; CountLv7 = 18; CountLv8 = 13; CountLv9 = 1;
                        ExpToLv2 = 9999;
                    }
                    break;
                default:
                    {
                        Mode = 1;
                        GameType = "Easy"; Color = "#aaaa55";
                        CountRow = 16; CountCol = 16; HP = 10; LV = 1;
                        CountLv1 = 10; CountLv2 = 8; CountLv3 = 6; CountLv4 = 4; CountLv5 = 2; CountLv6 = 0; CountLv7 = 0; CountLv8 = 0; CountLv9 = 0;
                        ExpToLv2 = 7; ExpToLv3 = 20; ExpToLv4 = 50; ExpToLv5 = 82;
                    }
                    break;
            }
            TotalNumber = CountRow * CountCol;
            List<int> tempCount = new List<int>();
            if (CountLv1 != 0) tempCount.Add(CountLv1);
            if (CountLv2 != 0) tempCount.Add(CountLv2);
            if (CountLv3 != 0) tempCount.Add(CountLv3);
            if (CountLv4 != 0) tempCount.Add(CountLv4);
            if (CountLv5 != 0) tempCount.Add(CountLv5);
            if (CountLv6 != 0) tempCount.Add(CountLv6);
            if (CountLv7 != 0) tempCount.Add(CountLv7);
            if (CountLv8 != 0) tempCount.Add(CountLv8);
            if (CountLv9 != 0) tempCount.Add(CountLv9);
            CountArray = tempCount.ToArray();

            List<int> tempExp = new List<int>();
            if (ExpToLv2 != 0) tempExp.Add(ExpToLv2);
            if (ExpToLv3 != 0) tempExp.Add(ExpToLv3);
            if (ExpToLv4 != 0) tempExp.Add(ExpToLv4);
            if (ExpToLv5 != 0) tempExp.Add(ExpToLv5);
            if (ExpToLv6 != 0) tempExp.Add(ExpToLv6);
            if (ExpToLv7 != 0) tempExp.Add(ExpToLv7);
            if (ExpToLv8 != 0) tempExp.Add(ExpToLv8);
            if (ExpToLv9 != 0) tempExp.Add(ExpToLv9);
            ExpArray = tempExp.ToArray();

        }

    }
}
