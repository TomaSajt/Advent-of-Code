import Data.List (intersect, foldl1')
import Data.Char (ord)

splitEvery :: Int -> [a] -> [[a]]
splitEvery _ [] = []
splitEvery n xs = as : splitEvery n bs 
  where (as,bs) = splitAt n xs

splitHalf :: String -> (String, String)
splitHalf s =  splitAt (div (length s) 2) s

score :: Char -> Int
score c = ord c - if elem c ['A'..'Z'] then 38 else 96

main :: IO()
main = do
    lns <- fmap lines $ readFile "input.txt"
    print $ sum . map (score . head . uncurry intersect . splitHalf) $ lns
    print $ sum . map (score . head . foldl1' intersect) $ splitEvery 3 lns