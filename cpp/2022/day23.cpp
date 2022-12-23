#include <bits/stdc++.h>
using namespace std;
typedef array<int, 2> point;

vector<point> dirs8{ {0,1},{1,1},{1,0},{1,-1},{0,-1},{-1,-1},{-1,0},{-1,1} };
vector<vector<point>> dirs4_3{ {{-1,-1},{0,-1},{1,-1}},{{1,1},{0,1},{-1,1}},{{-1,1},{-1,0},{-1,-1}},{{1,-1},{1,0},{1,1}} };
point operator+(const point& a, const point& b) { return { a[0] + b[0], a[1] + b[1] }; }

int main() {
    ifstream f("input.txt");
    string s;
    set<point> vpos;
    for (int y = 0; f >> s; y++) {
        for (int x = 0; x < s.size(); x++) {
            if (s[x] == '#') vpos.insert({ x,y });

        }
    }
    auto makeWish = [&](const point& pos) {
        bool stay = 1;
        for (auto& dir : dirs8) {
            if (vpos.count(pos + dir)) stay = 0;
        }
        if (stay) return pos;
        for (auto& dir_3 : dirs4_3) {
            bool move = 1;
            for (auto& dir : dir_3) {
                if (vpos.count(pos + dir)) move = 0;
            }
            if (move) return pos + dir_3[1];
        }
        return pos;
    };
    auto doRound = [&]() {
        map<point, vector<point>> wishToPosVecMap;
        for (auto& pos : vpos) wishToPosVecMap[makeWish(pos)].push_back(pos);
        bool moved = 0;
        for (auto& [wish, wvpos] : wishToPosVecMap) {
            if (wvpos.size() != 1) continue;
            auto& pos = wvpos[0];
            if (wish == pos) continue;
            moved = 1;
            vpos.erase(pos);
            vpos.insert(wish);
        }
        rotate(dirs4_3.begin(), dirs4_3.begin() + 1, dirs4_3.end());
        return moved;
    };
    int res1 = -1, res2 = -1;
    for (int i = 1; res1 == -1 || res2 == -1; i++) {
        cout << "Simulating round " << i << endl;
        bool moved = doRound();
        if (res2 == -1 && !moved) {
            res2 = i;
        }
        if (i == 10) {
            int minX = 1e9, minY = 1e9, maxX = -1e9, maxY = -1e9;
            for (auto& pos : vpos) {
                minX = min(minX, pos[0]);
                minY = min(minY, pos[1]);
                maxX = max(maxX, pos[0]);
                maxY = max(maxY, pos[1]);
            }
            res1 = (maxX - minX + 1) * (maxY - minY + 1) - vpos.size();
        }
    }
    cout << res1 << ' ' << res2;
}