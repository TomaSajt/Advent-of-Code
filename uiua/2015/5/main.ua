CheckAA ← ≥3/+∊∶"aeiou"
CheckAB ← /↥≡(/=)◫2
CheckAC ← ¬/↥/↥≐⌕"ab"_"cd"_"pq"_"xy"
CheckBA ← /↥≐(/↥⌕↙¯2⊃↙↘) +2⇡-3⧻.
CheckBB ← /↥≡(/=↘1↻1)◫3

⊜∘ ≠@\n. &fras "input.txt"
⍘⊟/+≡[⊃(↧⊃(CheckBB)(CheckBA))(↧↧⊃⊃(CheckAC)(CheckAB)(CheckAA))]
