let inp = require("fs")
    .readFileSync("input.txt")
    .toString()
    .replace(/\r\n/g, "\n")
    .split("\n\n")
    .map((x) => x.split("\n").map(eval));

let cnt = 0;
for (let i = 1; i <= inp.length; i++) {
    const [a, b] = inp[i - 1];
    if (compare(a, b) == -1) cnt += i;
}
console.log(cnt);
let flat = inp.flat(1);
flat.push([[2]]);
flat.push([[6]]);
flat.sort(compare);
let u = flat.findIndex((x) => compare(x, [[2]]) == 0);
let v = flat.findIndex((x) => compare(x, [[6]]) == 0);
console.log((u + 1) * (v + 1));

function compare(a, b) {
    let aar = Array.isArray(a);
    let bar = Array.isArray(b);
    if (!aar && !bar) return a < b ? -1 : a > b ? 1 : 0;
    if (aar && !bar) return compare(a, [b]);
    if (!aar && bar) return compare([a], b);
    for (let i = 0; i < a.length && i < b.length; i++) {
        let cr = compare(a[i], b[i]);
        if (cr == -1) return -1;
        if (cr == 1) return 1;
    }
    return compare(a.length, b.length);
}
