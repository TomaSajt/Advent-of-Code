inp ← ⊑•file.Lines "input.txt"
Solve ← {𝕨+⊑/(⍷≡⊢)¨<˘𝕨↕𝕩}
•Show Solve⟜inp¨4‿14