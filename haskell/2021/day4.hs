import Data.List (transpose, find, (\\))

split :: Eq a => (a -> Bool) -> [a] -> [[a]]
split pred str
    | str == [] = []
    | start == [] = split pred rem
    | otherwise = start : split pred rem
     where (start, rest) = break pred str
           (_, rem) = span pred rest

check :: [Int] -> [[Int]] -> Bool
check nums board = or . map (and . map(flip elem $ nums)) $ board

score :: [Int] -> [[Int]] -> Int
score nums board = (sum $ (board >>= id) \\ nums) * (last nums)

solve :: [Int] -> [[[Int]]] -> Int -> Int
solve nums boards n =
    let currNums = take n nums
        mayitem = find (check currNums) boards
    in case mayitem of
        Just item -> score currNums item
        Nothing -> solve nums boards (n+1)

solve2 :: [Int] -> [[[Int]]] -> Int -> Int
solve2 nums boards n =
    let currNums = take n nums
        mayitem = find (not . check currNums) boards
    in case mayitem of
        Just item -> score currNums item
        Nothing -> solve2 nums boards (n-1)

main :: IO()
main = do
    inp <- fmap lines $ readFile "input.txt"
    let ([nums]: boards) = map (map (map read . split (flip elem $ ", "))) . split (=="") $ inp :: [[[Int]]]
    let boardst = boards >>= \x -> [x,transpose x]
    print $ solve nums boardst 1
    print $ solve2 nums boardst $ length nums