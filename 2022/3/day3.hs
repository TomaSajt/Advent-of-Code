import Data.List (intersect, nub, foldl1')
import Data.Char (ord)

splitEvery :: Int -> [a] -> [[a]]
splitEvery _ [] = []
splitEvery n xs = as : splitEvery n bs 
  where (as,bs) = splitAt n xs

getBad :: String -> [Char]
getBad ln = nub $ intersect a b
    where (a,b) = splitAt (div (length ln) 2) ln

score :: Char -> Int
score c = if elem c ['A'..'Z'] then 27 + ord c - ord 'A' else 1 + ord c - ord 'a'

main :: IO()
main = do
    lns <- fmap lines $ readFile "input.txt"
    print $ sum . map score $ lns >>= getBad
    print $ sum . map(score . head . foldl1' intersect) $ splitEvery 3 lns