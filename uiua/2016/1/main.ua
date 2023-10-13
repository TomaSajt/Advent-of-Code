Input ← ⊜□¬∊∶", \n".&fras "input.txt"

Dirs ← ◿ 4\+∵(-1×2=@R⊢) Input
Dists ← ∵(parse ↘1⊔)Input

Deltas ← ⊏∶[0_1 1_0 0_¯1 ¯1_0]Dirs

Steps ← ▽ Dists Deltas

SolA ← /+Steps

AccSteps ← \+Steps

SolB ← ⊡ ∶AccSteps ⊗0 = ⇡⧻AccSteps ⊛ AccSteps

∩'/+⌵ SolB SolA
