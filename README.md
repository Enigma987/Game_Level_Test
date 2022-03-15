Jest to prosty etap z gry platformowej (pierwotnie będący zadaniem rekrutacyjnym do firmy Blum Entertainment)

Etap jest podzielony na trzy części:
- w pierwszej znajdują się przeciwnicy typu goblin i grzyb, które albo stoją w miejscu albo się poruszają po wyznaczonym punktach. Mogą one zatakować gracza, ale gracz może też zaatakować ich. Znajdują się tu też elementy do zebrania jak serca i monety, które sa zapisywane w UI
- w drugiej części mamy prostą zagadkę polegającą na ustawieniu klocków czerwonego i zielonego na odpowiadające im zapadnie, jest tu też pułapka, która polega na wysuwanie się kolcy z podłogi jak się na nią nadepnie i przesuwające się platformy którymi trzeba te klocki przemieścić
- na trzecim etapie jest boss - Goblin Bomber, który rzuca w gracza bombami w zalezności od pozycji gracza, trzeba go pokonać w tradycyjny sposób inspirowany Mario :), czyli trzeba przeskoczyć nad nim i nacisnąć dźwignię, wtedy podłoga pod bossem się zapadnie i on zginie. Wyświetli się wtedy ekran informujący o skończonej grze, gdzie podliczone zostaną wszystkie monety i serca zdobyte podczas etapu

Oprócz tego wszystkiego jest też zaimplementowana kamera, która porusza się razem z graczem, ale nie wyjdzie ona poza obszar grida, który odpowiada za teren (Ground). Dużo elementów ma podłączone animacje, które zmieniają się w zależności od stanu. Zaimplementowany jest atak pod klawiszem - F, a dźwignie uaktywniają się za pomocą klawisza - E.
