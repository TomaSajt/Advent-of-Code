inp ← >(-⟜'0')¨¨ •file.Lines "input.txt"
SolveLeft1 ← {1∾<˝˘2↕⌈`𝕩}˘
SolveLeft2 ← {+´∨˝˘2↕1∾∧`(⊑>1⊸↓)⌽𝕩}¨1⊸↓∘↑˘
trs←⟨⊢,⌽˘,⍉,⍉⌽⟩
•Show +´⥊∨´{SolveLeft1⌾𝕏inp}¨trs
•Show ⌈´⥊×´{SolveLeft2⌾𝕏inp}¨trs
