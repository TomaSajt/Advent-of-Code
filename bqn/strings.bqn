_splitWhen⇐{(⊢-˜¬×+`)∘(𝔽¨)⊔⊢}
SplitEmpty⇐(""⊸≡)_splitWhen

# usage: "HY" Replace "Hello World"
# result: "Yellow World"
Replace←{((⊑⌽𝕨)⥊˜≢𝕩)(⊣⌾(((⊑𝕨)=𝕩)⊸/))𝕩}