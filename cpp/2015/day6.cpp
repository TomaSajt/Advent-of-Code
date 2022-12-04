#include <bits/stdc++.h>
#define speed ios::sync_with_stdio(0);cin.tie(0)
using namespace std;

void get_new_value1(const string& op, int& val) {
    if (op == "toggle") val = 1 - val;
    else if (op == "on") val = 1;
    else val = 0;
}

void get_new_value2(const string& op, int& val) {
    if (op == "toggle") val += 2;
    else if (op == "on") val += 1;
    else val = max(0, val - 1);
}


int board1[1000][1000], board2[1000][1000];
int main() {
    speed;
    ifstream file("input.txt");
    string str, through;
    char comma;
    while (file >> str) {
        if (str == "turn") file >> str;
        int x1, x2, y1, y2;
        file >> x1 >> comma >> y1 >> through >> x2 >> comma >> y2;
        for (int i = x1; i <= x2; i++) {
            for (int j = y1; j <= y2; j++) {
                get_new_value1(str, board1[i][j]);
                get_new_value2(str, board2[i][j]);
            }
        }
    }
    cout << accumulate(board1[0], board1[0] + 1000000, 0) << '\n';
    cout << accumulate(board2[0], board2[0] + 1000000, 0);
}