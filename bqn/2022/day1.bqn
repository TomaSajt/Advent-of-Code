h ← •Import "bqn/helpers.bqn"
data ← •file.Lines "input.txt"
sums ← ∨(+´•BQN¨)¨h.SpEm data
•Show (+´∘↑⟜sums)¨(1‿3)