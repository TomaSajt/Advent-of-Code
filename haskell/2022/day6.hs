import Data.List (nub, findIndex)

sublists :: Int -> [a] -> [[a]]
sublists n x | (length x) < n = []
sublists n x = take n x : (sublists n $ tail x)

solve :: Int -> String -> Maybe Int
solve n x = fmap (+ n) . findIndex (\e -> e == nub e) $ sublists n x

main :: IO()
main = do
    inp <- fmap init $ readFile "input.txt"
    print $ solve 4 inp
    print $ solve 14 inp
