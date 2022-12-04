import Data.Char (digitToInt)
import Data.List (foldl1')

toDec :: [Int] -> Int
toDec = foldl1' (\acc d -> 2 * acc + d)

readBinary :: String -> [Int]
readBinary x = map digitToInt x

main :: IO()
main = do
    binrows <- fmap (map readBinary . lines) $ readFile "input.txt"
    let cnts = foldl1' (zipWith (+)) binrows
    let len = div (length binrows) 2
    let gamma = map (fromEnum . (> len)) cnts
    let epsilon = map (1 -) gamma
    print $ (toDec gamma) * (toDec epsilon)

