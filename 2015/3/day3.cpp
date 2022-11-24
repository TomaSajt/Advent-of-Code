#include <bits/stdc++.h>
#define speed ios::sync_with_stdio(0);cin.tie(0)
using namespace std;

int main() {
    speed;
    char c;
    set<pair<int, int>> m;
    cout << "Actor count: " << flush;
    int actors; cin >> actors;
    vector<pair<int, int>> positions(actors, { 0,0 });
    m.insert({ 0,0 });
    ifstream stream("input.txt");
    string s; stream >> s;
    int actor = 0;
    for (char c : s) {
        auto& pos = positions[actor];
        switch (c) {
        case 'v': pos.second++; break;
        case '<': pos.first--; break;
        case '>': pos.first++; break;
        case '^': pos.second--; break;
        }
        m.insert(pos);
        actor = (actor + 1) % actors;
    }
    cout << m.size();
    stream.close();
}