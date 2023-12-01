Words ← {"zero" "one" "two" "three" "four"
         "five" "six" "seven" "eight" "nine"}

DigitsA ← ▽∊:⇡10.-@0
DigitsB ← ▽≠¯1./↥-1×+1 ◿10⇡20 ⊐≡⌕ ⊂+@0⇡10 Words ¤
# Could be `▽≠0./↥×` instead of `▽≠¯1./↥-1×+1` but I want to support "zero"

⊜□ ¬∊:"\r\n". &fras "input.txt"
∩/+ ⊐≡(∩(+×10⊃(⊢|⊢⇌)) ⊃(DigitsB|DigitsA))
