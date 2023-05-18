import GHC.List (foldl')

process t [speed, t1, t2] =
  let ts = t1 + t2
      (k, r) = t `divMod` ts
   in speed * (t1 * k + min r t1)


main = do
  racers <- map ((\x -> (\y -> read $ x !! y :: Int) <$> [3, 6, 13]) . words) . lines <$> readFile "input.txt"
  print $ maximum $ map (process 2503) racers
  print . foldl' (zipWith (+)) (repeat 0) $ (\x -> map (\y -> if y == maximum x then 1 else 0) x) . (\x -> map (process x) racers) <$> [1 .. 2503]
