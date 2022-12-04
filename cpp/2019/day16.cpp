#include <bits/stdc++.h>
using namespace std;
map<string, vector<pair<int, int>>> classes;

bool is_valid(vector<pair<int, int>>& pairs, int val) {
    for (auto& [from, to] : pairs) {
        if (val >= from && val <= to) return true;
    }
    return false;
}
bool is_valid_for_any(int val) {
    for (auto& [name, pairs] : classes) {
        if (is_valid(pairs, val)) return true;
    }
    return false;
}


int main() {
    string line;
    ifstream stream("input.txt");

    while (getline(stream, line) && line.size() > 0) {
        stringstream ss(line);
        string name;
        getline(ss, name, ':');
        ss.ignore();
        while (true) {
            int from, to;
            ss >> from;
            ss.ignore();
            ss >> to;
            classes[name].push_back({ from,to });
            if (ss.eof()) break;
            ss.ignore(4);
        }
    }
    getline(stream, line);
    getline(stream, line);
    vector<int> my_ticket;
    {
        stringstream ss(line);
        int a;
        while (ss >> a) {
            my_ticket.push_back(a);
            if (ss.peek() == ',') ss.ignore();
        }
    }
    getline(stream, line);
    getline(stream, line);
    vector<vector<int>> tickets;
    while (getline(stream, line)) {
        stringstream ss(line);
        int a;
        tickets.emplace_back();
        while (ss >> a) {
            tickets.back().push_back(a);
            if (ss.peek() == ',') ss.ignore();
        }
    }

    for (auto& [name, pairs] : classes) {
        cout << name << endl;
        for (auto& [from, to] : pairs) {
            cout << from << '-' << to << endl;
        }
        cout << endl << endl;
    }
    int error = 0;
    for (auto& ticket : tickets) {
        for (auto& val : ticket) {
            if (!is_valid_for_any(val)) error += val;
        }
    }
    cout << error << endl;
}