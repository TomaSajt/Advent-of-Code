# inputs: len, col, row, table
# output: a window of the table
MkWin ← ↙⊂3-2¯⊙(↙⊂3+2)⊙⊙(⊏+-1⇡3)

# inputs: len, col, row
# output: BB of form: [[t l] [b r]]
MkWinBB ← ⊟∩⊟⊃(-1;;|-|+1;;|+1;)

# inputs: BB, pos
# output: does BB contain pos
IsInBB ← /↧⊂⊃(≥⊙⋅∘)(≤⋅⊙∘)°⊟

# input: window
# output: is part number's
ChkWin ← /↥♭¬∵(∊:⊂@.+@0⇡10)

# input: window
# output: number
WinVal ← ⋕↘1↘¯1⊡1

# Read input file
&fras "input.txt"

# Split lines
⊜∘ ¬∊:"\r\n".

# Pad input with `.`
⍥(⍉⇌≡⊂¤@.)4

# From padded input make 2 matrices
# mask of digits, copy of the padded input
∊:⇡10-@0.

# From last list make 2 matrices:
# mask of number ends, number of digits of current number to the left (including itself)
≡⊃(=¯1≡/-◫2⊂:0|\(×+1))

# From last 2 lists make 3 lists:
# number lengths, number end positions, number rows
⊃(▽∩♭|:≡°⊟⊚)

# From last 4 lists make 4 lists: 
# bounding boxes, positions of `*`, mask of part number-ness, numbers
⊃(≡MkWinBB|⋅⋅⋅(⊚=@*)|≡(⊃(ChkWin|WinVal) MkWin)⊙⊙⊙¤)

# From last 2 lists make 1 list:
# list of masks for pairs of neighbours
▽=2≡(/+).⍉⊠IsInBB

# From last 3 lists make final 2 solutions 
⊃(/+≡/×≡▽⊙⋅¤|/+⋅▽)
