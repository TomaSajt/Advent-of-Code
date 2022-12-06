a=$<.read.split("\n\n").map{_1.split.sum &:to_i}
p a.max
p a.max(3).sum