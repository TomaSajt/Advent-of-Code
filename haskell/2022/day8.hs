import Data.List (transpose, reverse, inits)

zipSelf op x = zipWith op x (tail x)

islvis :: [[Int]] -> [[Bool]]
islvis = map ((True:) . zipSelf (<) . scanl1 max)

lviews :: [[Int]] -> [[Int]]
lviews = map (map viewFromLast . tail . inits)

countUntilOrLen :: Int -> [Int] -> Int
countUntilOrLen _ [] = 0 
countUntilOrLen n (x:xs)
    | x >= n = 1
    | otherwise = 1 + countUntilOrLen n xs

viewFromLast :: [Int] -> Int
viewFromLast x = countUntilOrLen t rr 
        where (t:rr) = reverse x

main = do
    brd <- map (map $ read . (:[])) . lines <$> readFile "input.txt" :: IO [[Int]]
    let a1 = islvis brd
    let b1 = transpose $ islvis $ transpose $ brd
    let c1 = map reverse $ islvis $ map reverse $ brd
    let d1 = reverse . transpose $ islvis $ transpose . reverse $ brd
    print $ sum . map (length . filter id) $ foldr1 (zipWith $ zipWith (||)) [a1, b1, c1, d1]
    let a2 = lviews brd
    let b2 = transpose $ lviews $ transpose $ brd
    let c2 = map reverse $ lviews $ map reverse $ brd
    let d2 = reverse . transpose $ lviews $ transpose . reverse $ brd
    print $ maximum . map maximum $ foldr1 (zipWith $ zipWith (*)) [a2, b2, c2, d2]