import Data.List (unfoldr, intercalate, sort, elemIndex)
import Control.Monad (sequence)

data Packet = Arr [Packet] | Val Int

instance Show Packet where
  show (Arr x) = "["++ (intercalate "," $ map show x)  ++ "]"
  show (Val x) = show x

instance Eq Packet where
   a == b = compare a b == EQ

instance Ord Packet where
  compare (Val a) (Val b) = compare a b
  compare (Val a) (Arr b) = compare (Arr [Val a]) (Arr b)
  compare (Arr a) (Val b) = compare (Arr a) (Arr [Val b])
  compare (Arr []) (Arr []) = EQ
  compare (Arr _) (Arr []) = GT
  compare (Arr []) (Arr _) = LT
  compare (Arr (a:sa)) (Arr (b:sb))
    | r == LT = LT
    | r == GT = GT
    | otherwise = compare (Arr sa) (Arr sb)
    where r = compare a b

splitWhen pred = takeWhile (not . null) . unfoldr (Just . fmap (drop 1) . break pred)

readP "[]" = Arr []
readP x@('[':_) = Arr $ map readP split 
        where x' = drop 1 $ init x
              cntr = scanl1 (+) $ map (\a -> if a==']' then -1 else if a=='[' then 1 else 0) x'
              split = map (map fst) . splitWhen (\(a,b) -> a==',' && b==0) $ zip x' cntr

readP x = Val $ read x

main :: IO()
main = do
    packets <- map(map readP) . takeWhile (not . null) . unfoldr (Just . fmap (drop 1) . splitAt 2) . lines <$> readFile "input.txt"
    print $ sum . map fst . filter ((==LT) . snd) . zip [1..] $ map (\[a,b] -> compare a b) packets
    let [u,v] = (\x -> Arr [(Arr [Val x])]) <$> [2,6]
    let sortedFlat = sort $ u:v:(id =<< packets)
    print $ fmap product $ sequence $ fmap (+1) . (flip elemIndex) sortedFlat <$> [u,v]
