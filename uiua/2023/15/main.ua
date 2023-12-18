EmptyMap ← ↯0_2□0
Insert ← (⍜↙(⊂↘¯1)+1|⋅⊂)=⊃(⋅⋅⧻|.⊗⊙⋅≡⊢|⋅⋅∘|⊟)∩□
Erase ← (⍜↻(↘1)|⋅∘)=⊃(⋅⧻|.⊗⊙≡⊢|⋅∘)□
HASH ← ∧(◿256×17+)⊙0-@\0
ProcessU ← (Erase;|Insert:⋕↘1)=2⧻.⊃(⋅⊙∘|∘)
Process ← ⍜(°□⊡)ProcessU ⊃(HASH↙|⋅⋅∘|↘|↙)⊢⊚∊⊙"=-".
SMI ← /+×+1⇡⧻.

▽¬∊⊙"\r\n".&fras "input.txt"
⊜(⊃□HASH)≠@,.
⊙/+
:↯256□EmptyMap
∧(Process°□)
SMI≡(SMI♭≡°□⊢⇌⍉°□)
