#include <bits/stdc++.h>
using namespace std;
struct packet {
    vector<packet*> inner{};
    int val{ -1 };
};
int compI(int a, int b) {
    cout << "asd" << endl;
    if (a < b) return -1;
    if (a > b) return 1;
    return 0;
}
int comp(const packet& a, const packet& b) {
    if (a.val != -1 && b.val != -1) {
        cout << "Comparing values: " << a.val << " and " << b.val << endl;
        return compI(a.val, b.val);
    }
    if (a.val != -1 && b.val == -1) {
        packet copya;
        packet content;
        content.val = a.val;
        copya.inner.push_back(&content);
        cout << "comparing list and value" << endl;
        return comp(copya, b);
    }
    if (a.val == -1 && b.val != -1) {
        cout << "flip0" << endl;
        return -comp(b, a);
    }
    for (int i = 0; i < a.inner.size() && i < b.inner.size(); i++) {
        cout << "comparing lists" << endl;
        int ic = comp(*a.inner[i], *b.inner[i]);
        if (ic == -1) return -1;
        if (ic == 1) return 1;
    }
    cout << "comparing lengths" << endl;
    return compI(a.inner.size(), b.inner.size());
}

packet* makePacket(const string& s) {
    packet* base = new packet;
    stack<packet*> sta;
    sta.push(base);
    for (int i = 1; i < s.size() - 1; i++) {
        char c = s[i];
        packet* curr = sta.top();
        if (c == '[') {
            curr->inner.push_back(new packet);
            sta.push(curr->inner.back());
        }
        else if (c == ']') sta.pop();
        else if (c == ',') continue;
        else {
            int l = 0;
            while ('0' <= s[i + l] && s[i + l] <= '9') l++;
            string st = s.substr(i, l);
            packet* valPacket = new packet;
            //cout << st << endl;
            valPacket->val = stoi(st);
            curr->inner.push_back(valPacket);
            i += l - 1;
        }
    }
    return base;
}

int main() {
    ifstream f("input.txt");
    string as, bs;
    int i = 0;
    int res = 0;
    while (f >> as >> bs >> ws) {
        packet* a = makePacket(as);
        packet* b = makePacket(bs);
        int c = comp(*a, *b);
        cout << c << endl;
        if (c != 1) res += i + 1;
        if (i == 1) {
            //cout << "r:" << b->inner[1]->val << endl;
        }
        i++;
    }
    cout << res;
}