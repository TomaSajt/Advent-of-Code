h ← •Import "bqn/strings.bqn"
data ← •file.Lines "input.txt"
sums ← ∨(+´•BQN¨)¨h.SpEm data
•Show (+´∘↑⟜sums)¨1‿3