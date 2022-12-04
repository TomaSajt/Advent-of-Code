import Data.List (sortBy)
split :: Eq a => (a -> Bool) -> [a] -> [[a]]
split _ [] = []
split pred str = 
    let (start, rest) = break pred str
        (_, remain) = span pred rest
     in start : split pred remain

main :: IO() = do
    content <- readFile "input.txt"
    let res = sortBy (flip compare) . map(sum . map read) . split (=="") . lines $ content :: [Int]
    print $ head res
    print $ sum . take 3 $ res
