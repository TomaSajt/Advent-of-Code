import Data.Char (ord)

toIDs :: String -> [Int]
toIDs [ca,_,cb] = [ord ca - ord 'A', ord cb - ord 'X']

score :: [Int] -> Int
score [a,b] = b + 1 + 3 * (mod (b - a + 1) 3)

score2 :: [Int] -> Int
score2 [a,o] = (mod (a + o - 1) 3) + 1 + 3 * o

main :: IO()
main = do
    inp <- fmap(map toIDs . lines) $ readFile "input.txt"
    print $ sum . map score $ inp
    print $ sum . map score2 $ inp