Nums ← ⊜(parse) ¬∊∶" \n" . &fras "input.txt"
CheckTri ← >⊃(⊢⇌)(/+↙2)⊏⍏.

TrisA ← ↯ ¯1_3 Nums
TrisB ← /⊂⍚2⍉ ↯ ¯1_3_3 Nums

∩(/+≡(CheckTri)) TrisB TrisA
