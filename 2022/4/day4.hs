
split :: Eq a => (a -> Bool) -> [a] -> [[a]]
split _ [] = []
split pred str = 
    let (start, rest) = break pred str
        (_, rem) = span pred rest
     in start : split pred rem

parseLine :: String -> [Int]
parseLine = map read . split (flip elem $ ",-")

isFullOverlap :: [Int] -> Bool
isFullOverlap [a,b,c,d] = (a <= c && d <= b) || (c <= a && b <= d)

isAnyOverlap :: [Int] -> Bool
isAnyOverlap [a,b,c,d] = a <= d && c <= b

main :: IO()
main = do
    inp <- fmap (map parseLine . lines) $ readFile "input.txt"
    print $ length . filter isFullOverlap $ inp
    print $ length . filter isAnyOverlap $ inp