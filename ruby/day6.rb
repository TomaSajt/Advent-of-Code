a=gets.chars
p a.each_cons(4).map{_1==_1.uniq}.find_index{_1}+4
p a.each_cons(14).map{_1==_1.uniq}.find_index{_1}+14