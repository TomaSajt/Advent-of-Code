Ips ← ⊜□ ¬∊:"\n\r" . &fras "input.txt"

Any ← ∧↥⊙0
IsABA ← ↧⊃(≍ ⇌.|/≠↙2)
IsABBA ← IsABA
HasABBA ← Any ≡(IsABBA) ◫ 4

HyperMasks ← ⍚(\+-⊃(↘¯1⊂0=@]|=@[)) Ips

HyperSeqLists ← ⍚(⊜(□↘¯1↘1)) HyperMasks Ips
NonHyperSeqLists ← ⍚(⊜□¬) HyperMasks Ips

HyperSeqHasABBAList ← ≡(Any ≡(HasABBA °□)°□) HyperSeqLists
NonHyperSeqHasABBAList ← ≡(Any ≡(HasABBA °□)°□) NonHyperSeqLists

/+↧ NonHyperSeqHasABBAList ¬HyperSeqHasABBAList

ListABAs ← ▽ ≡(IsABA) .◫ 3

GetBABPair ← ⊂⊃(⊡1|∘)↙2

NonHyperSeqABALists ← ⍚(/◇⊂⍚ListABAs) NonHyperSeqLists
HyperSeqABALists ← ⍚(/◇⊂⍚ListABAs) HyperSeqLists
HyperSeqBABLists ← ⍚≡(GetBABPair)HyperSeqABALists

/+ ≡(Any ◇∊) NonHyperSeqABALists HyperSeqBABLists
