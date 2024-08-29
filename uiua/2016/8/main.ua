SetRect ← ⍜↙(↥1)

RotRow ← ≡↻⊃(¯×⊙(=⇡⧻:)|⋅⋅∘) :°⊟
RotCol ← ⍉RotRow⊙⍉

ApplyLine ← ⨬(⨬(RotCol|RotRow)⊃(=@r⊡7|⊜⋕∈+⇡10@0.)|SetRect⇌⊜⋕≠@x.↘5)≍"re"↙2.

⊜□ ≠@\n.&fras "input.txt"
∧(ApplyLine °□) ⊙(↯6_50 0)
⊃(⊏:" #"|/+/+)

∩&p
