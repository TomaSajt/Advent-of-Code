ParseRules ← ≡({⊙⊙⊙∘}⊃(⊗:"xmas"⊢|=@>⊡1|⋕↘2)°{⊙∘})
ParseChunk ← ⊙(□ParseRules ⊂)⊃(⊢|↯¯1_2↘1↘¯1|⊟□"a<∞"⊢⇌)⊜□¬∈"{}:,".
ApplyRule ← ⊡⊢⊚≡(⊙□(>|<):⊃(⊡⊙⋅⋅⋅∘|⋅⊙⊙∘)°{⊙⊙⊙∘})
GetNext ← ApplyRule⊓°□¤⊡⊢⊚=
IsAccepted ← =@A⊢⊙⋅⋅;⍢⊃(GetNext|⋅⊙⊙∘)(¬∈{"A""R"})□"in"

▽≠@\r.&fras"input.txt"
⊓(⊜ParseChunk≠@\n.|.⊜(⊜⋕∈+@0⇡10.)≠@\n.)⊃↙↘⊢⊚⌕"\n\n".
/+♭▽≡IsAccepted ∩¤
