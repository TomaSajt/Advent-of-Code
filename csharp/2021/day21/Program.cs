static long wrap(long x) => ((x - 1) % 10) + 1;
var pos = File.ReadAllLines("input.txt").Select(l => long.Parse(l.Split()[4])).ToArray();
long[,,,,] DP = new long[21, 21, 11, 11, 2]; // score0, score1, pos0, pos1, turn
DP[0, 0, pos[0], pos[1], 0] = 1; //0 score, everyone at their start pos, player 0 starts
bool r = false;
long points0 = 0, points1 = 0;
do
{
    var oDP = DP;
    DP = new long[21, 21, 11, 11, 2];
    r = false;
    for (long sc0 = 0; sc0 < 21; sc0++)
    {
        for (long sc1 = 0; sc1 < 21; sc1++)
        {
            for (long pos0 = 1; pos0 <= 10; pos0++)
            {
                for (long pos1 = 1; pos1 <= 10; pos1++)
                {
                    if (oDP[sc0, sc1, pos0, pos1, 0] != 0 || oDP[sc0, sc1, pos0, pos1, 1] != 0) r = true;
                    for (long d1 = 1; d1 <= 3; d1++)
                    {
                        for (long d2 = 1; d2 <= 3; d2++)
                        {
                            for (long d3 = 1; d3 <= 3; d3++)
                            {
                                long dies_of_cring = d1 + d2 + d3;
                                //player0
                                long newPos0 = wrap(pos0 + dies_of_cring);
                                if (sc0 + newPos0 >= 21) points0 += oDP[sc0, sc1, pos0, pos1, 0];
                                else DP[sc0 + newPos0, sc1, newPos0, pos1, 1] += oDP[sc0, sc1, pos0, pos1, 0];
                                //player0
                                long newPos1 = wrap(pos1 + dies_of_cring);
                                if (sc1 + newPos1 >= 21) points1 += oDP[sc0, sc1, pos0, pos1, 1];
                                else DP[sc0, sc1 + newPos1, pos0, newPos1, 0] += oDP[sc0, sc1, pos0, pos1, 1];
                            }
                        }
                    }
                }
            }
        }
    }
} while (r);
Console.WriteLine(Math.Max(points0, points1));