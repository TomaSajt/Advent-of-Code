import Data.List (intercalate)

taxicab [sx,sy,bx,by] = abs(sx-bx) + abs(sy-by)
show1 a@[sx,sy,bx,by] = "\\left(" ++ show sx ++ "," ++ show sy ++ "\\right)"

-- generates Desmos code you have to paste into Desmos
-- there is an `a` slider, which, when decreased, expands the areas.
-- you have to look for square shaped uncovered areas
-- take a note of roughly where they are and shrink a to 0
-- take a look at the noted locations, and if you find a hole, that's 1x1, that position is your beacon
-- calculating the final result is left as an exercise for the reader
main = do
    inp <- map (map read . words) . lines <$> readFile "input2.txt" :: IO [[Int]]
    putStrLn "d\\left(P,Q\\right)=\\left|P.x-\\operatorname{round}\\left(Q.x\\right)\\right|+\\left|P.y-\\operatorname{round}\\left(Q.y\\right)\\right|+a"
    putStrLn "a=100000"
    putStr "X=\\left["
    putStr $ intercalate "," (map show1 inp) 
    putStrLn "\\right]"
    putStr "D=\\left["
    putStr $ intercalate "," (map (show .taxicab) inp) 
    putStrLn "\\right]"
    putStrLn "d\\left(X,\\left(x,y\\right)\\right)\\le D+0.001"