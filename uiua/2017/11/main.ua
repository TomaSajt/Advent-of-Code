Dirs ← ⊜(□) ∊∶"nesw". &fras "input.txt"

Positions ← \+⊏∶[1_0 1_1 0_1 ¯1_0 ¯1_¯1 0_¯1]⊗∶{"n" "ne" "se" "s" "sw" "nw"} Dirs

Dist ← ?(/↥)(/+)⊙⌵/=±.

Dists ← ≡(Dist) Positions

⊃(/↥)(⊢⇌)Dists
