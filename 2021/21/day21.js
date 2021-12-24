let sp = require("fs")
    .readFileSync("input.txt")
    .toString()
    .trim()
    .split(/\r?\s/g);
let x1 = +sp[4],
    x2 = +sp[9],
    a = 0,
    p1 = 0,
    p2 = 0;
const roll = () => 3 * ((a += 3) - 1);
const wrap = (x) => ((x - 1) % 10) + 1;
while (true) {
    x1 = wrap(x1 + roll());
    p1 += x1;
    if (p1 >= 1000) {
        console.log(p2 * a);
        break;
    }
    x2 = wrap(x2 + roll());
    p2 += x2;
    if (p2 >= 1000) {
        console.log(p1 * a);
        break;
    }
}
