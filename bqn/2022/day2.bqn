inp ← >•file.Lines "input.txt"
P1 ← {𝕩+1+3×3|1+𝕩-𝕨}
P2 ← {(3|𝕨+𝕩-1)+1+3×𝕩}
•Show +˝{(P1∾P2)´-⟜"AX"0‿2⊏𝕩}˘inp