GetPos! ← +1⊚≡(^2⇌⊃↙↘⊃(∘|↙×2))⊃(+1⇡⌊÷2⧻|¤)
GetPosFR! ← ⊂⊙-∩GetPos!^2⊃(∘|⇌|⧻)
Solve! ← +×100:∩/+ ∧(∩⊂⊙: ∩GetPosFR!^2⍉. °□) ⊙[]⊙[]

▽≠@\r. &fras "input.txt"
⊜(□⊜∘≠@\n.)¬⌕"\n\n".
⊃(Solve!(=1/+♭≠)|Solve!≍)
