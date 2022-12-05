import Data.List (transpose, foldl')
import Data.Sequence (Seq, fromList, index, update)

split :: Eq a => (a -> Bool) -> [a] -> [[a]]
split _ [] = []
split pred str = 
    let (start, rest) = break pred str
        (_, remain) = span pred rest
     in start : split pred remain

trimFirst :: String -> String
trimFirst (' ' : rest) = trimFirst rest
trimFirst str = str

next :: ([a] -> [a]) -> Seq [a] -> (Int, Int, Int) -> Seq [a]
next tr stacks (n,i,j) = let [st1,st2] = map (index stacks) [i,j]
                             st1m = drop n st1
                             st2m = (tr $ take n st1) ++ st2
                        in update i st1m $ update j st2m stacks

readOp :: String -> (Int, Int, Int)
readOp str = let [_,sn,_,si,_,sj] = split (==' ') str
             in (read sn, read si-1, read sj-1)

main :: IO()
main = do
    (ist, (_:iops)) <- fmap (break null . lines) $ readFile "input.txt"
    let stsq = fromList . map (trimFirst . ((transpose ist) !!)) $ [1,5..33]
    let ops = map readOp $ iops
    let sol = \tr -> fmap head $ foldl' (next tr) stsq ops
    print $ sol reverse
    print $ sol id