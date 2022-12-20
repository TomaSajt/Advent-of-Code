#include <bits/stdc++.h>
using namespace std;
typedef long long ll;

struct Node {
    ll val;
    Node* next{}, * prev{};
    Node(ll val): val{ val } {}
};

Node* rep_next_node(Node* node, ll c) {
    Node* res = node;
    while (c--) res = res->next;
    return res;
}

Node* remove_node(Node* node) {
    Node* prev = node->prev;
    node->next->prev = node->prev;
    node->prev->next = node->next;
    node->prev = 0;
    node->next = 0;
    return prev;
}

void insert_node_after(Node* after, Node* node) {
    node->prev = after;
    node->next = after->next;
    after->next->prev = node;
    after->next = node;
}

ll solve(vector<Node> nodes, ll mult, int its) {
    int n = nodes.size();
    for (int i = 0; i < n - 1; i++) nodes[i].next = &nodes[i + 1];
    for (int i = 1; i < n; i++) nodes[i].prev = &nodes[i - 1];
    nodes[n - 1].next = &nodes[0];
    nodes[0].prev = &nodes[n - 1];
    for (int i = 0; i < its; i++) {
        for (auto& node : nodes) {
            Node* prev = remove_node(&node);
            n--;
            int c = ((node.val * mult) % n + n) % n;
            Node* after = rep_next_node(prev, c);
            insert_node_after(after, &node);
            n++;
        }
    }
    Node* curr = &*find_if(nodes.begin(), nodes.end(), [](auto& a) { return a.val == 0; });
    ll res = 0;
    for (int i = 0; i < 3; i++) {
        curr = rep_next_node(curr, 1000);
        res += curr->val * mult;
    }
    return res;
}

int main() {
    ifstream f("input.txt");
    vector<Node> nodes;
    for (ll a; f >> a;) nodes.emplace_back(a);
    cout << solve(nodes, 1, 1) << ' ' << solve(nodes, 811589153, 10);
}