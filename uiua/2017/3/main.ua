Num ← parse ▽≠@\n.&fras "input.txt"

Ring ← ⌈÷2-1√Num

CornerVal ← ×.+1×2 Ring

Delta ← -Num CornerVal

MakeOffset ← ↥0↧×2 Ring -×2× ∶Ring∶Delta

Pos ← +[-∩(MakeOffset)1 3 -∩(MakeOffset)0 2] ⊂.Ring

/+⌵Pos
