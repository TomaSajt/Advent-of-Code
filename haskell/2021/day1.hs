import Data.List (tails)

window :: Int -> [a] -> [[a]]
window n x = take (length(x) - n + 1) $ map (take n) $ tails x

solve :: [Int] -> Int
solve x = length . filter (<0) $ zipWith (-) x (tail x)

main :: IO()
main = do
    content <- readFile "input.txt"
    let inp = map read $ lines content
    print $ solve inp
    let inp2 = map sum $ window 3 inp
    print $ solve inp2