&fras "input.txt"
⋕ ▽¬∈"\n\r".
Num ←

Ring ← ⌈÷2-1√Num

CornerVal ← ×.+1×2 Ring

Delta ← -Num CornerVal

MakeOffset ← ↥0↧×2 Ring -×2× :Ring:Delta

Pos ← +/-↯2_2 ≡MakeOffset⇡4 ⊂.Ring

/+⌵Pos
