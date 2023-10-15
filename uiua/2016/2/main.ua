Lines ← ⊜□ ≠@\n.&fras "input.txt"
LineEndPositions ← \+∵⧻ Lines
InstToDelta ← ⊏∶[1_0 ¯1_0 0_1 0_¯1] ⊗∶"DURL"
AllInsts ← /(⊂∩⊔)Lines
Deltas ← ∵(InstToDelta) AllInsts

KeypadA ← ["123" "456" "789"]
StartPosA ← 1_1
AddClamped ← ↧2↥0+
⊡∶KeypadA ⊏ LineEndPositions \(AddClamped) ⊂ StartPosA Deltas

KeypadB ← ["  1  " " 234 " "56789" " ABC " "  D  "]
StartPosB ← 2_0
IsValidPos ← ≤2/+⌵-2_2
AddChecked ← ;?(∶)(∶∶)IsValidPos.+,∶
⊡∶KeypadB ⊏ LineEndPositions \(AddChecked) ⊂ StartPosB Deltas
