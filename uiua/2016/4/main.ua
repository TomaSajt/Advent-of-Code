Lines ← ⊜□ ≠@\n. &fras "input.txt"

SplitLines ← ≡(□⊜□ ¬ ∊∶ "[]-" .⊔) Lines

Ids ← ≡(parse ⊔⊡¯2⊔) SplitLines
Checksums ← ≡(⊔⊡ ¯1⊔) SplitLines
Names ← ≡(□/(⊂⊙⊔⊔)↘¯2⊔) SplitLines

Name ← ⊔⊢ Names
Checksum ← ⊢ Checksums
Letters ← ⊝ Name
LetterCounts ← ∺(/+=) Name Letters

MinLetterCount ← ⊡⊡4⍖.LetterCounts

AcceptedLetters ← ▽≥ MinLetterCount LetterCounts Letters

/↧ ∺(∊∶) AcceptedLetters Checksum
