# CMD-GAME

## Representações

 - P = Poção, restaura 6 de vida.
 - M = Monstro, cada um tem 5 de vida, cauda 1 de dano de ataque e vale 5 pontos.
 - B = Chefe, tem 10 de vida, cauda 2 de dano de ataque e vale 15 pontos.
 - H = Herói, começa com 25 pontos de vida, cauda 1 de dano inicial.
 - W = Arma, tem apenas 1, o herói passa a causar 2 de dano por ataque.
 - D = Destino, posição que representa a saída do grid.
  
![tab](https://user-images.githubusercontent.com/69995854/147893653-62145a67-e6b0-4144-a554-38dac8d22be7.png)

  
## Regras 

 - A cada turno o jogador pode escolher uma direção para andar (cima, direita, baixo e esquerda)
  ou atacar (se próximo de um monstro/chefe), cada ação do jogador lhe custa 1 ponto de vida
  (seja andar ou atacar), a cada ação do jogador os monstros também se movimentam para uma
  posição aleatória ou ataca o herói (caso próximo a ele).

 - Monstros e Herói não podem ocupar a mesma posição no grid.

 - Itens e Arma só podem ser pegos uma vez. (Ao passar na coordenada ela vira um O)

 - Monstros que estejam próximos ao jogador, lhe atacam. O ataque dos monstros causa 1 de
  dano (ou 2 se for um Chefe).

 - O ataque do jogador causa 1 de dano (2 se ele pegou a Arma).
  
 - O Chefe se derrotado vale 15 pontos.
  
 - Cada Monstro derrotado vale 5 pontos.
  
 - Cada ponto de vida restante vale 1 ponto
  
## Objetivo
  
 - O jogo termina quando o jogador chega na posição D (20,20).
  

