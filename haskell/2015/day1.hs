parenToDelta :: Char -> Int
parenToDelta '(' = 1
parenToDelta ')' = -1
parenToDelta _ = 0

solveTask1 :: Int -> String -> Int
solveTask1 floor "" = floor
solveTask1 floor (x : xs) =
  let floor' = floor + parenToDelta x
   in solveTask1 floor' xs

solveTask2 :: Int -> Int -> String -> Maybe Int
solveTask2 _ _ "" = Nothing
solveTask2 pos floor (x : xs)
  | floor < 0 = Just (pos - 1)
  | otherwise =
      let floor' = floor + parenToDelta x
          pos' = pos + 1
       in solveTask2 pos' floor' xs

main = do
  str <- head . lines <$> readFile "input.txt"
  print $ solveTask1 0 str
  print $ solveTask2 1 0 str
