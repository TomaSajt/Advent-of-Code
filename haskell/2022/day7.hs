import Data.List (foldl', tails)
import qualified Data.Map as Map

split _ []  = []
split pred xxs@(x:xs) 
  | pred x = split pred xs
  | otherwise = ys : split pred rest
      where (ys, rest) = break pred xxs

data Cmd = Cd String | Sz Int 

next :: ([String], Map.Map [String] Int) -> Cmd ->  ([String], Map.Map [String] Int)
next (path, sizes) (Cd "/") = ([], sizes)
next (_:xpth, sizes) (Cd "..") = (xpth, sizes)
next (path, sizes) (Cd dir) = (dir : path, sizes)
next (path, sizes) (Sz num) = (path, foldl' (\a x -> Map.insertWith (+) x num a) sizes $ tails path)

readCmd :: [String] -> Cmd
readCmd (('c':_:_:x):_) = Cd x
readCmd (_:xs) = Sz $ sum . map (read . head . words) . filter (('d'/=) . head) $ xs

main :: IO()
main = do
    inp <- readFile "input.txt"
    let cmds = map (readCmd . lines . tail) . split (=='$') $ inp
    let (_,fs) = foldl' next ([], Map.empty) $ cmds
    let res = Map.elems fs
    let used = fs Map.! []
    print $ sum . filter (<=100000) $ res
    print $ minimum $ filter (>=used-40000000) res