import Data.List (unfoldr, sort, nub)
import Data.Char (isDigit)
import Data.Maybe (catMaybes)

taxicab ((sx,sy),(bx,by)) = abs(sx-bx) + abs(sy-by)

reservedIntervalForRow row info@((sx,sy),(bx,by)) 
                            | d<dy = Nothing
                            | otherwise = Just (sx-lhx, sx+lhx)
                            where d = taxicab info
                                  dy = abs(row-sy)
                                  lhx = d-dy


combineIntervals [] = []
combineIntervals [x] = [x]
combineIntervals (a@(la,ra):b@(lb,rb):xs)
                    | ra >= lb = combineIntervals ((la,max ra rb):xs)
                    | otherwise = a : combineIntervals (b:xs)
isValid x = x=='-' || isDigit x 

inInterval x (l,r) = l<=x && x<=r

main = do
    inp <- map((\[a,b,c,d]->((a,b),(c,d))) . map (read :: String -> Int) . takeWhile (not . null) . unfoldr (Just . span isValid . snd . break isValid)) . lines <$> readFile "input.txt"
    print $ inp
    let n = 2000000
    let asd = sort $ catMaybes $ map (reservedIntervalForRow n) inp
    print asd
    print $ combineIntervals asd
    let comb = combineIntervals asd
    let cLen = sum . map (\(l,r)->r-l+1) $ comb
    let overlappingObjs = filter (\(x,y) -> y==n && any (inInterval x) comb) $ [nub $ map snd inp, map fst inp]>>=id
    print $ cLen - length overlappingObjs