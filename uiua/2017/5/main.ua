InitialState ← ⊜(parse)≠@\n .&fras "input.txt"

AddSub ← ?-+≥3,1

NextA ← ⊂⊙(□+1)⊂∩□⊙(⍜⊡(+1))+⊡,⊙.,∩⊔⊃⊃(⊢)(⊡1)(⊡2)
NextB ← ⊂⊙(□+1)⊂∩□⊙(⍜⊡(AddSub))+⊡,⊙.,∩⊔⊃⊃(⊢)(⊡1)(⊡2)

Length ← ⧻ InitialState

⊔⊢⇌⍥(⎋ ↥ ⊃(≥Length)(<0)⊢.NextA)∞ {0 InitialState 0}
⊔⊢⇌⍥(⎋ ↥ ⊃(≥Length)(<0)⊢.NextB)∞ {0 InitialState 0}
