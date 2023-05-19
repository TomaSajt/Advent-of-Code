import Data.List (minimumBy)

fitInto :: [Int] -> Int -> [[Int]]
fitInto _ 0 = [[]]
fitInto [] _ = []
fitInto (x : xs) cnt
  | cnt < 0 = []
  | otherwise = fitInto xs cnt ++ map (x :) (fitInto xs (cnt - x))

main = do
  sizes <- map read . lines <$> readFile "input.txt" :: IO [Int]
  let combos = fitInto sizes 150
  print $ length combos
  print $ length . (\x -> filter ((==) $ minimum x) x) $ map length combos
