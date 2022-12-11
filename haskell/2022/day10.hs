import Data.List (foldl')
readInst :: String -> Maybe Int
readInst s
        | h == "addx" = Just . read $ tail t 
        | h == "noop" = Nothing
        where (h,t) = splitAt 4 s

type State = (Int, Int, Int, [Char])

cycl :: State -> State
cycl (c,x,r,d) = (c',x,r',d'')
    where c' = c + 1
          r' = (if mod c' 40 == 20 then c'*x else 0) + r
          d' = (if abs(x - mod c 40) <= 1 then '#' else ' '):d
          d''= (if mod c' 40 == 0 then '\n':d' else d')

next :: State -> Maybe Int -> State
next st (Nothing) = cycl st
next st (Just dx) = (c',x'+dx,r',d)
        where (c',x',r',d) = cycl $ cycl st

main :: IO()
main = do
    insts <- map readInst . lines <$> readFile "input.txt"
    let (_,_,r,d) = foldl' next (0,1,0,[]) insts
    print r
    mapM_ putStrLn . lines $ reverse d