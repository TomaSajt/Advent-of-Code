nums ← ↯ ¯1_4 ∵(|1 parse!) ⊜□¬∊∶"-,\n" . &fras "input.txt"

checkA ← ↥⊃(↧⊃(/≤ ⊏[1 3])(/≥ ⊏[0 2]))(↧⊃(/≥ ⊏[1 3])(/≤ ⊏[0 2]))
checkB ← ↧⊃(/≥ ⊏[0 3])(/≤ ⊏[1 2])

/+≡[⊃checkA checkB] nums
