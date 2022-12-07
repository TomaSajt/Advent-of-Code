import Data.List (foldl', tails)
import qualified Data.Map as M

type State = ([String], M.Map [String] Int)
data Op = Dir String | Size Int 

split _ []  = []
split pred xxs@(x:xs) 
  | pred x = split pred xs
  | otherwise = ys : split pred rest
      where (ys, rest) = break pred xxs

next :: State -> Op ->  State
next (path, szm) (Dir "/") = ([], szm)
next (_:th, szm) (Dir "..") = (th, szm)
next (path, szm) (Dir dir) = (dir : path, szm)
next (path, szm) (Size num) = (path, foldl' (\a x -> M.insertWith (+) x num a) szm $ tails path)

readOp :: [String] -> Op
readOp (('c':_:_:dir):_) = Dir dir
readOp (_:l) = Size $ sum . map (read . head . words) . filter (('d'/=) . head) $ l

main :: IO()
main = do
    inp <- readFile "input.txt"
    let cmds = map (readOp . lines . tail) . split (=='$') $ inp
    let (r:res) = M.elems . snd $ foldl' next ([], M.empty) $ cmds
    print . sum . filter (<=100000) $ res
    print . minimum $ filter (r-40000000<=) res