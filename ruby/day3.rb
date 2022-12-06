l=$<.readlines
x = [' ',*('a'..'z'),*('A'..'Z')]
p l.map{_1.chomp.chars.each_slice(_1.size/2).inject(&:intersection)[0]}.sum{x.find_index _1}
p l.each_slice(3).map{_1.map(&:chars).inject(&:intersection)[0]}.sum{x.find_index _1}
