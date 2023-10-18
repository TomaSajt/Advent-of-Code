Inp ← ↯ ¯1_2 ⊜(parse) ¬∊∶"\n, " . &fras "input.txt"

Size ← 500
Offset ← 50_50

Inp ← ∺+Offset Inp

MakeArea ← +∩(⌵-) ⊙∶ ⍉.↯Size⇡Size

Areas ← ≡(MakeArea ⊃(⊢)(⊢ ⇌)) Inp
⍉≡⍉ Areas

⍚(1)(?(⊢)(¯1;)=1 ⧻.⊚ =/↧.)

.
⊝ ⊂¯1⊂⊂⊂⊃⊃⊃(⊢⇌⍉)(⊢⍉)(⊢⇌)(⊢)
/↥ ⍘⊚ ▽ ¬∊,⊙♭

/+/+<10000/+Areas
