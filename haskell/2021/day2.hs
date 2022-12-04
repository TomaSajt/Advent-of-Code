solve1 :: (Int, Int) -> [(String, Int)] -> (Int, Int)
solve1 p [] = p
solve1 (x, y) (("forward", n) : rest) = solve1 (x + n, y) rest
solve1 (x, y) (("down", n) : rest) = solve1 (x, y + n) rest
solve1 (x, y) (("up", n) : rest) = solve1 (x, y - n) rest

solve2 :: (Int, Int, Int) -> [(String, Int)] -> (Int, Int)
solve2 (_, x, y) [] = (x, y)
solve2 (a, x, y) (("forward", n) : rest) = solve2 (a, x + n, y + a * n) rest
solve2 (a, x, y) (("down", n) : rest) = solve2 (a + n, x, y) rest
solve2 (a, x, y) (("up", n) : rest) = solve2 (a - n, x, y) rest


readTuple :: String -> (String, Int)
readTuple str = (dir, read ns)
    where [dir, ns] = words str

main :: IO()
main = do
    content <- readFile "input.txt"
    let insts = map readTuple $ lines content
    let (x1, y1) = solve1 (0, 0) insts
    let (x2, y2) = solve2 (0, 0, 0) insts
    print $ x1 * y1
    print $ x2 * y2


