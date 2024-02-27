SplitLines ← ⊜(□⊜□ ¬∊:"[]-" .) ¬∊:"\n\r". &fras "input.txt"

Ids ← ≡(⋕°□⊡¯2°□) SplitLines
Checksums ← ≡(°□⊡ ¯1°□) SplitLines
SplitNames ← ⍚(↘¯2) SplitLines
Names ← ⍚/◇⊂ SplitNames

NameToAcceptedLetters ← ▽≥ ⊡⊡4⍖.. ≡(/+=)¤ ⊙. :◴.

LineAcceptedLetters ← ⍚NameToAcceptedLetters Names

RealMask ← ≡(/↧ ≡(∊:°□)¤) LineAcceptedLetters Checksums

RealIds ← ▽ RealMask Ids
RealSplitNames ← ▽ RealMask SplitNames

/+ RealIds

ShiftChar ← +@a◿ 26 +-@a:
ShiftWord ← ≡(ShiftChar)¤
ShiftWords ← ⍚(ShiftWord)¤

Join ← ↘1/◇⊂⍚⊂¤

DecipheredNames ← ⍚(Join @\s ShiftWords) RealIds RealSplitNames

⊢ ▽ ≡(/↥⌕ "northpole object storage" °□) DecipheredNames RealIds
