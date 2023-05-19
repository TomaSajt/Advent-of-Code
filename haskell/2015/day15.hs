import Data.List (foldl1')

listsOfLengthWithSum :: Int -> Int -> [[Int]]
listsOfLengthWithSum 0 0 = [[]]
listsOfLengthWithSum 0 _ = []
listsOfLengthWithSum len sum = [0 .. sum] >>= \e -> map (e :) $ listsOfLengthWithSum (len - 1) (sum - e)

main = do
  ingredients <- map ((\s -> read . (s !!) <$> [2, 4, 6, 8, 10] :: [Int]) . map init . words . (++ ",")) . lines <$> readFile "input.txt"
  let cookies = map (max 0) . foldl1' (zipWith (+)) . zipWith (\l w -> (w *) <$> l) ingredients <$> listsOfLengthWithSum (length ingredients) 100
  print $ maximum . map (product . init) <$> [cookies, filter ((500 ==) . last) cookies]
