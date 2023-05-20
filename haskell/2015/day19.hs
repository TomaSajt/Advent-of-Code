import Data.Char (isUpper)
import Data.List (findIndex, nub)

type Element = String

type Molecule = [Element]

type Replacement = (Element, Molecule)

processMoleculeStr :: String -> Molecule
processMoleculeStr "" = []
processMoleculeStr (x : xs) = (x : a) : processMoleculeStr b
  where
    (a, b) = break isUpper xs

replaceMoleculeElem :: Molecule -> Replacement -> [Molecule]
replaceMoleculeElem [] _ = []
replaceMoleculeElem s@(x : xs) r@(from, to) = res'
  where
    res = map (x :) $ replaceMoleculeElem xs r
    res' = if x == from then (to ++ xs) : res else res

replaceMultiple :: [Replacement] -> Molecule -> [Molecule]
replaceMultiple reps mol = replaceMoleculeElem mol =<< reps

main = do
  input <- lines <$> readFile "input.txt"
  let (repLines, moleculeStr) = (init $ init input, last input)
  let reps = (\x -> (head x, processMoleculeStr $ last x)) . words <$> repLines :: [Replacement]
  let molecule = processMoleculeStr moleculeStr :: Molecule
  print $ length . nub $ map (>>= id) $ replaceMultiple reps molecule
  -- this is too slow
  let infList = iterate (\x -> x >>= replaceMultiple reps) [["e"]]
  print $ findIndex (elem molecule) infList
