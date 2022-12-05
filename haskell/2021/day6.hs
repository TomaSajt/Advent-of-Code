import Data.Char (digitToInt)
oddEls (x:y:xs) = x : oddEls xs;
oddEls [x] = [x]
oddEls [] = []

count :: Eq a => a -> [a] -> Int
count x = length . filter (x==)

next :: [Int] -> [Int]
next [a,b,c,d,e,f,g,h,i] = [b,c,d,e,f,g,h+a,i,a]

main :: IO()
main = do
    content <- readFile "input.txt"
    let list = map digitToInt . oddEls . head . lines $ content
    let sols = iterate next $ map (flip count $ list) $ [0..8]
    print $ sum $ sols !! 80
    print $ sum $ sols !! 256