#include <bits/stdc++.h>
using namespace std;
struct packet {
    vector<packet*> inner{};
    int val{ -1 };
    void print() {
        if (val != -1) cout << val;
        else {
            cout << '[';
            bool first = 1;
            for (auto p : inner) {
                if (!first) cout << ',';
                p->print();
                first = false;
            }
            cout << ']';
        }
    }
};
int compI(int a, int b) {
    if (a < b) return -1;
    if (a > b) return 1;
    return 0;
}
int comp(const packet& a, const packet& b) {
    if (a.val != -1 && b.val != -1) {
        return compI(a.val, b.val);
    }
    if (a.val != -1 && b.val == -1) {
        packet copya;
        packet content;
        content.val = a.val;
        copya.inner.push_back(&content);
        return comp(copya, b);
    }
    if (a.val == -1 && b.val != -1) {
        return -comp(b, a);
    }
    for (int i = 0; i < a.inner.size() && i < b.inner.size(); i++) {
        int ic = comp(*a.inner[i], *b.inner[i]);
        if (ic == -1) return -1;
        if (ic == 1) return 1;
    }
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
            valPacket->val = stoi(st);
            curr->inner.push_back(valPacket);
            i += l - 1;
        }
    }
    return base;
}
packet* makeExtra(int val) {
    packet* u = new packet;
    packet* ui = new packet;
    packet* uii = new packet;
    uii->val = val;
    ui->inner.push_back(uii);
    u->inner.push_back(ui);
    return u;
}

int main() {
    ifstream f("input.txt");
    string as, bs;
    int res = 0;
    vector<packet*> pv;
    for (int i = 0; f >> ws >> as >> bs; i++) {
        packet* a = makePacket(as);
        packet* b = makePacket(bs);
        int c = comp(*a, *b);
        if (c != 1) res += i + 1;
        pv.push_back(a);
        pv.push_back(b);
    }
    cout << res << endl;
    packet* u = makeExtra(2);
    packet* v = makeExtra(6);
    pv.push_back(u);
    pv.push_back(v);
    sort(pv.begin(), pv.end(), [](auto a, auto b) { return comp(*a, *b) == -1; });
    int upos = find(pv.begin(), pv.end(), u) - pv.begin() + 1;
    int vpos = find(pv.begin(), pv.end(), v) - pv.begin() + 1;
    cout << upos * vpos;
}