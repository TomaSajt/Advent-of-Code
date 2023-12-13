Chk ← ≍ # For part 1
# Chk ← =1/+♭≠ # For part 2

GetPos ← +1⊚≡(Chk⇌⊃↙↘⊃(∘|↙×2))⊃(+1⇡⌊÷2⧻|¤)
GetPosFR ← ⊂⊙-∩GetPos⊃(∘|⇌|⧻)

▽≠@\r. &fras "input.txt"
⊜(□⊜∘≠@\n.)¬⌕"\n\n".
+×100:∩/+ ∧(∩⊂⊙: ∩GetPosFR⍉. °□) ⊙[]⊙[]
