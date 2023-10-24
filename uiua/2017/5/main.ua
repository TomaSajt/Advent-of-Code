InitialState ← ⊜(parse)≠@\n .&fras "input.txt"

Next! ← ⊙(⍜⊡(^1)) +⊡,⊙., ⊙⊙(+1)

# currently repeat in a custom modifier is broken, wait for next version
;;⍥(⎋ ↥ ⊃(≤⊙⧻)(<0⊙;),,Next!(+1))∞ 0 InitialState 0
;;⍥(⎋ ↥ ⊃(≤⊙⧻)(<0⊙;),,Next!(?-+≥3,1))∞ 0 InitialState 0
