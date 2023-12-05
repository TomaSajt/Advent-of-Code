NL ← ↯0_2[]
MkIntv ← -⇡2\+
Gaps ← ≡(⊂:0)▽≥0≡/-.⍉⇌+¯1_1⊟⊓(⊂:∞|⊂¯∞)⍘⊟↙2⍉
PL ← ⊜parse≠@\s.
IntersectShift ← ↙⊃(≥|+¤⊟)⊃(↥⊙⋅∘|↧⋅⊙⋅∘)∩⍘⊟⊃(↙2⊙∘|⊢⇌)
IntersectShiftMultiInner ← ∧(⊂IntersectShift)⊙¤⊙⊙NL
IntersectShiftMulti ← ∧(⊂IntersectShiftMultiInner)¤⊙⊙NL
Solve ← /↧♭∧(IntersectShiftMulti⊔)

▽≠@\r. &fras "input.txt"
⊃(↘1|PL↘7⊔⊢)⊜□¬⌕"\n\n".
≡(□⊂Gaps.⊏⍏.≡(⊂⊃(MkIntv↘1|/-⇌↙2)PL⊔)↘1⊜□≠@\n.⊔)
∩Solve,:⊙⊃(≡MkIntv↯¯1_2|≡[.])
