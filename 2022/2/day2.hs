import Data.Char (ord)

toIDs :: [Char] -> [Int]
toIDs [ca, cb] = [(ord ca) - (ord 'A'), (ord cb) - (ord 'X')]

score :: [Int] -> Int
score [a,b] = b + 1 + 3 * (mod (b - a + 1) 3)

score2 :: [Int] -> Int
score2 [a,o] = (mod (a + o - 1) 3) + 1 + 3 * o

main :: IO()
main = do
    content <- readFile "input.txt"
    let inp = map(toIDs . map head . words) . lines $ content
    solve score inp
    solve score2 inp
    where solve sc = print . sum . map sc