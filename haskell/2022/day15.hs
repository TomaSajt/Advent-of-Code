import Data.List (unfoldr, sort, nub, intercalate)
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



--  generates Desmos code you have to paste into Desmos
--  after pasting, you have to zoom out, until you see the area edges
--  there is an `a` slider, which, when decreased, expands the areas.
--  you have to look for square shaped uncovered areas
--  take a note of roughly where they are and shrink a to 0
--  take a look at the noted locations, and if you find a hole, that's 1x1, that position is your beacon
--  calculating the final result is left as an exercise for the reader

    putStrLn ""
    putStrLn "d\\left(P,Q\\right)=\\left|P.x-\\operatorname{round}\\left(Q.x\\right)\\right|+\\left|P.y-\\operatorname{round}\\left(Q.y\\right)\\right|+a"
    putStrLn "a=100000"
    putStr "X=\\left["
    putStr $ intercalate "," (map ( \((sx,sy),(bx,by)) -> "\\left(" ++ show sx ++ "," ++ show sy ++ "\\right)" ) inp) 
    putStrLn "\\right]"
    putStr "D=\\left["
    putStr $ intercalate "," (map (show . taxicab) inp) 
    putStrLn "\\right]"
    putStrLn "d\\left(X,\\left(x,y\\right)\\right)\\le D+0.001"