Next ← |2.2 ⊃∘+ +⊙(≡/+ ⊠(±-)..)

GCD ← ;⍢(⊃◿∘)(≠0)
LCM ← ÷⊃(GCD|×)

# 5 parameters: iter_cnt current_pos currect_vel orig_pos orig_vel 
GetRepeats ← |1 ⊙⋅⋅⋅; ⍢(+1 ⊙Next)(¬↧⋅⊃(≍⊙⋅∘|≍⋅⊙⋅∘)) 1 Next ,, ↯:0△ .

SolveA ← /+× ∩(≡/+⌵) ⍥Next 1000 ↯:0△.
SolveB ← /LCM ≡GetRepeats ⍉

↯¯1_3 ⊜⋕ ∊:⊂@-+@0⇡10. &fras "input.txt"
⊃(SolveB|SolveA)
