Func<List<long>, long>[] funcMap =
{
    list => list.Sum(),
    list => list.Aggregate(1L, (a, b) => a * b),
    list => list.Min(),
    list => list.Max(),
    list => throw new Exception(),
    list => list[0] > list[1] ? 1 : 0,
    list => list[0] < list[1] ? 1 : 0,
    list => list[0] == list[1] ? 1 : 0
};
using StreamReader sr = new("input.txt");
int count = 0, versionSum = 0, pointer = 0, currHex = 0;
var res = Solve();
Console.WriteLine($"{versionSum}\n{res}");
int ReadBits(int n)
{
    int res = 0;
    for (int i = 0; i < n; i++)
    {
        res <<= 1;
        if (pointer == 0)
        {
            pointer = 4;
            int c = sr.Read();
            currHex = c <= '9' ? c - '0' : c - 'A' + 10;
        }
        res += (currHex >> --pointer) & 1;
    }
    return res;
}
long Solve()
{
    versionSum += ReadBits(3);
    int packetType = ReadBits(3);
    count += 6;
    if (packetType == 4)
    {
        long val = 0;
        while (true)
        {
            int f = ReadBits(1);
            val <<= 4;
            val += ReadBits(4);
            count += 5;
            if (f == 0) break;
        }
        return val;
    }
    int lc = ReadBits(1) == 0 ? 15 : 11;
    int l = ReadBits(lc);
    count += lc + 1;
    var subPackets = new List<long>();
    if (lc == 15)
    {
        int temp = count;
        while (temp + l > count) subPackets.Add(Solve());
    }
    else for (int i = 0; i < l; i++) subPackets.Add(Solve());
    return funcMap[packetType](subPackets);
}






/*var pc = new PacketConsumer("input.txt");
var res = pc.ConsumePacket();
Console.WriteLine(pc.versionSum);
Console.WriteLine(res);

class PacketConsumer
{
    static readonly Dictionary<int, Func<List<long>, long>> funcDict = new()
    {
        { 0, list => list.Sum() },
        { 1, list => list.Aggregate(1L, (a, b) => a * b) },
        { 2, list => list.Min() },
        { 3, list => list.Max() },
        { 5, list => list[0] > list[1] ? 1 : 0 },
        { 6, list => list[0] < list[1] ? 1 : 0 },
        { 7, list => list[0] == list[1] ? 1 : 0 },
    };

    readonly BinaryConsumer bc;
    int count;
    public int versionSum = 0;
    public PacketConsumer(string path) => bc = new(path);
    public long ConsumePacket()
    {
        count = 0;
        return ConsumePacketRec();
    }
    long ConsumePacketRec()
    {
        versionSum += bc.ReadBits(3);
        int packetType = bc.ReadBits(3);
        count += 6;
        if (packetType == 4) return ReadLiteral();
        int lc = bc.ReadBit() == 0 ? 15 : 11;
        int l = bc.ReadBits(lc);
        count += lc + 1;
        var subPackets = new List<long>();
        if (lc == 15)
        {
            int temp = count;
            while (temp + l > count) subPackets.Add(ConsumePacketRec());
        }
        else
        {
            for (int i = 0; i < l; i++) subPackets.Add(ConsumePacketRec());
        }
        return funcDict[packetType](subPackets);
    }
    long ReadLiteral()
    {
        long val = 0;
        while (true)
        {
            bool end = bc.ReadBit() == 0;
            val <<= 4;
            val += bc.ReadBits(4);
            count += 5;
            if (end) break;
        }
        return val;
    }
}
class BinaryConsumer
{
    readonly StreamReader sr;
    int pointer = 0;
    int curr;
    public BinaryConsumer(string path) => sr = new(path);
    public int ReadBit()
    {
        if (pointer == 0)
        {
            pointer = 4;
            int c = sr.Read();
            curr = c <= '9' ? c - '0' : c - 'A' + 10;
        }
        pointer--;
        return (curr >> pointer) & 1;
    }
    public int ReadBits(int n)
    {
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res <<= 1;
            res += ReadBit();
        }
        return res;
    }
}*/