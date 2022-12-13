h ← •Import "bqn/strings.bqn"
data ← •file.Lines "input.txt"
sums ← ∨(+´•BQN¨)¨h.SplitEmpty data
•Show (+´∘↑⟜sums)¨1‿3