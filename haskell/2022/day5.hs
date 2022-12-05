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

next :: (String -> String) -> Seq String -> (Int, Int, Int) -> Seq String
next tr stacks (n,a,b) = let st1 = index stacks a
                             st2 = index stacks b
                             st1m = drop n st1
                             st2m = (tr $ take n st1) ++ st2
                        in update b st2m $ update a st1m stacks

readOp :: String -> (Int, Int, Int)
readOp str = let [_,sn,_,sa,_,sb] = split (==' ') str
             in (read sn, read sa-1, read sb-1)

main :: IO()
main = do
    res <- fmap lines $ readFile "input.txt"
    let (ist, (_:iops)) = break null res
    let stsq = fromList . map (trimFirst . ((transpose ist) !!)) $ [1,5..33]
    let ops = map readOp $ iops
    let sol = \tr -> fmap head $ foldl' (next tr) stsq ops
    print $ sol reverse
    print $ sol id