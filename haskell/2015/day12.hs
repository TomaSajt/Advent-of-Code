import Data.Char (isNumber)

extractNums :: String -> ([String], Bool)
extractNums "" = ([], False)
extractNums (x : xs) = (res'', isNum)
  where
    (res, wasNum) = extractNums xs
    isNum = isNumber x
    res' = if isNum && not wasNum then "" : res else res
    res'' = if isNum || x == '-' then (x : head res') : tail res' else res'

main = do
  print . sum . map (read :: String -> Int) . fst . extractNums =<< readFile "input.txt"
