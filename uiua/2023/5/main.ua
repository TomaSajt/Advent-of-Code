PL ← |1 ⊜⋕≠@\s.
# makes missing intervals in sorted interval list
Gaps ← |1 ≡(⊂:0) ▽≡/>. ⍉⊟⊓(⊂¯∞|⊂:∞) :⍘⊟↙2⍉
# returns "optional" intersection (singleton or empty list) 
TryIntersectShift ← |2 ↯/>. +⊟⊃(↥⊙⋅∘|↧⋅⊙⋅∘) ∩⍘⊟⊃(↙2⊙∘|⊢⇌)
# almost ☇1⊠(TryIntersectShift) but we need to use list joining to handle optionals
IntersectShiftCombine ← |2 ∧(∧(⊂TryIntersectShift)⊙¤)¤ ⊙⊙(↯0_2[])
Solve ← |2 /↧⊢⍉∧(IntersectShiftCombine⊔)

▽≠@\r. &fras "input.txt"
⊃(↘1|PL↘7⊔⊢) ⊜□¬⌕"\n\n".
≡(□ ⊂Gaps. ⊏⍏. ≡(⊂⊃(\+↘1|/-⇌↙2)PL⊔) ↘1⊜□≠@\n. ⊔)
∩Solve ,: ⊙⊃(≡\+↯¯1_2|≡[⊃(∘|+1)])
