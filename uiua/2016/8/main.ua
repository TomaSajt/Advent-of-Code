Screen ← ↯6_50 0

SetRect ← ⍜↙(↥1)

RotRow ← ⊂⊂⊃⊃(↙)(↻¯∶⊡)(↘ +1) ⊙∶ ⊃(⊡0)(⊡1)
RotCol ← ⍉RotRow⊙⍉

Lines ← ⊜□ ≠@\n.&fras "input.txt"

ApplyLine ← ?(SetRect ⇌⊜(parse)≠@x.↘ 5)(?(RotRow)(RotCol)=@r⊡7∶ ⊜(parse) ∊∶+⇡10@0..) ≅"re"↙2.

FinalScreen ← ∧(ApplyLine ⊔∶) Screen Lines

/+/+FinalScreen

⊏ FinalScreen " #"
