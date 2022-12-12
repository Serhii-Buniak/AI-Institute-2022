(deffacts spivrobitnyku
    (spivrobitnyk name1 21 1 500)
    (spivrobitnyk name2 4 4 5000)
    (spivrobitnyk name3 2 2 2500)
    (spivrobitnyk name4 1 1 1000)
    (spivrobitnyk name5 1 6 700)
)

(defrule givepremia
(spivrobitnyk ?name ?staj ?child ?oklad)
(test (or (> ?child 2) (>= ?staj 5) )) =>
    (assert (premia ?name (* ?oklad 1.20)))
)

(defrule printall
(spivrobitnyk ?name ?staj ?child ?oklad)
(test (> ?staj 20) ) =>
    (printout t crlf "Більше 20" crlf)
)

;-----

(deffacts Tovaru
    (Tovar name1 100 1 2002 UA)
    (Tovar name2 200 4 2006 BG)
    (Tovar name3 300 6 2010 PL)
    (Tovar name4 400 2 2015 LV)
    (Tovar name5 500 6 2022 GB)
)

(defrule giveucinka
(Tovar ?name ?price ?count ?year ?country)
(test (or (< ?year 2010) (< ?count 4) )) =>
    (assert (ucinka ?name (* ?price 0.85)))
)

(defrule givenacinka
(Tovar ?name ?price ?count ?year ?country)
(test  (= ?year 2022)) =>
    (assert (nacinka ?name (* ?price 1.07)))
)

(defrule isua
(Tovar ?name ?price ?count ?year ?country)
(test (eq ?country UA)) =>
    (printout t crlf "UA UA UA" crlf)
)

;-----
(assert (Vasyl Stole))

(defrule MayIvan
(not(Vasyl Stole)) =>
    (printout t crlf "Petro Stole" crlf)
)

(defrule MayPetro
(not(Ivan Stole)) =>
 (printout t crlf "Vasyl Stole" crlf)
)

(defrule MayMykola
(not(Vasyl Stole)) =>
    (printout t crlf "Ivan Stole" crlf)
)

(defrule MayVasyl
(not(Petro Stole)) =>
    (printout t crlf "I Stole" crlf)
)

