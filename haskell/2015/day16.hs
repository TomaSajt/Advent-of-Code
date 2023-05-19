import Data.List (findIndex)

listToPairs [] = []
listToPairs [_] = []
listToPairs (a : b : xs) = (a, read b :: Int) : listToPairs xs

matchSue sue (k, v, f) = case lookup k sue of
  Just v' -> f v' v
  Nothing -> True

matchSueAll sue = all (matchSue sue)

main = do
  sueList <- map (listToPairs . map init . drop 2 . words . (++ ",")) . lines <$> readFile "input.txt"
  let template1 = [("children", 3, (==)), ("cats", 7, (==)), ("samoyeds", 2, (==)), ("pomeranians", 3, (==)), ("akitas", 0, (==)), ("vizslas", 0, (==)), ("goldfish", 5, (==)), ("trees", 3, (==)), ("cars", 2, (==)), ("perfumes", 1, (==))]
  let template2 = [("children", 3, (==)), ("cats", 7, (>)), ("samoyeds", 2, (==)), ("pomeranians", 3, (<)), ("akitas", 0, (==)), ("vizslas", 0, (==)), ("goldfish", 5, (<)), ("trees", 3, (>)), ("cars", 2, (==)), ("perfumes", 1, (==))]
  print $ (+ 1) <$> findIndex (`matchSueAll` template1) sueList
  print $ (+ 1) <$> findIndex (`matchSueAll` template2) sueList
