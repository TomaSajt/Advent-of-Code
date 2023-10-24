Input ← -@0▽∊∶"01". &fras "input.txt"

GetNextA ← ⊂⊙(⊂ 0)⊙(¬⇌).

Len ← 272
DiskContent ← ↙ Len⍥(⎋≥Len⧻. GetNextA)∞ Input
GetNextB ← ≡(/=)↯ ¯1_2

+@0⍥(⎋=1 ◿ 2⧻. GetNextB)∞ DiskContent

# 2nd part takes too long
