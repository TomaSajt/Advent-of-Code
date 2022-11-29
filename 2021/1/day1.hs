solve1 :: [Int] -> Int
solve1 x = length . filter (<0) $ zipWith (-) x (tail x)

runSolve1 :: String -> IO Int
runSolve1 = fmap solve1 . getInput

getInput :: String -> IO [Int]
getInput = fmap(map read . lines) . readFile

part1 = runSolve1 "input.txt"