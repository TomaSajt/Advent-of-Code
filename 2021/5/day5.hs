import Data.List (group, sort)
split :: Eq a => a -> [a] -> [[a]]
split _ [] = []
split del str = 
    let (start, rest) = break (==del) str
        (_, remain) = span (==del) rest
     in start : split del remain

sign :: Int -> Int
sign x = if x>0 then 1 else if x<0 then -1 else 0

readCoords :: String -> (Int, Int)
readCoords x = (read a, read b)
    where [a,b] = split ',' x

readSegment :: String -> ((Int, Int),(Int, Int))
readSegment x = (readCoords a, readCoords b) 
    where [a,_,b] = split ' ' x

isAxisAligned :: ((Int, Int),(Int, Int)) -> Bool
isAxisAligned ((x1,y1),(x2,y2)) = x1==x2||y1==y2


segmentElements :: ((Int, Int),(Int, Int)) -> [(Int, Int)]
segmentElements ((x1,y1),(x2,y2)) = do
    let dx = x2-x1
    let dy = y2-y1
    let sx = sign dx
    let sy = sign dy
    let l = max (abs dx) (abs dy)
    [ (x1+d*sx, y1+d*sy) | d <- [0..l] ]

solve :: [((Int,Int),(Int,Int))] -> Int
solve segs = length . filter ((>1) . length) . group . sort $ segs >>= segmentElements

main :: IO()
main = do
    content <- readFile "input.txt"
    let segs = map readSegment $ lines content
    let fsegs = filter isAxisAligned segs
    print $ solve fsegs
    print $ solve segs