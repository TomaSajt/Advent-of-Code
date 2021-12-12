#include <bits/stdc++.h>
using namespace std;
#define N 10
#define K 10
int board[N][N];
int flashed[N][N];
int flashedMarker = 1;
int bsum = 0;
void boop(int i, int j) {
    if (i < 0 || j < 0 || i >= N || j >= N || flashed[i][j] == flashedMarker) return;
    board[i][j]++;
    bsum++;
    if (board[i][j] < K) return;
    flashed[i][j] = flashedMarker;
    board[i][j] = 0;
    bsum -= K;
    for (int di = -1; di <= 1; di++) {
        for (int dj = -1; dj <= 1; dj++) {
            boop(i + di, j + dj);
        }
    }

}
int main() {
    ifstream f(".input.txt");
    string l;
    for (int i = 0; i < N; i++) {
        f >> l;
        for (int j = 0; j < N; j++) {
            board[i][j] = l[j] - '0';
            bsum += board[i][j];
        }
    }
    f.close();
    while (bsum) {
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                boop(i, j);
            }
        }
        flashedMarker++;
    }
    cout << flashedMarker - 1;
}