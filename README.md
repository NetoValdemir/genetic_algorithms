# [ESTUDO] Algoritmos Genéticos - Combinação de cores e escala
Estudo sobre algoritmos genéticos na Unity. Análise evolutiva dos indivíduos baseada na combinação das suas cores e tamanhos diferentes. Baseado nos exemplos da ***Dra Penny de Byl***.

## Genetic Algorithm

<div align="center">
  <img src="https://github.com/user-attachments/assets/22e50fb6-f69b-45be-bce0-429974ebc0d0" width="70%" />
</div>
<br>

***Descrição:*** O simulador consiste em um cenário em que é gerada uma população de 10 indivíduos e que possuem um ciclo de vida máximo de 10s. É possível determinar se algum indivíduo encerra seu ciclo antes do período máximo se o usuário clicar com o botão esquerdo do mouse sobre ele. Ao clicar, o ciclo de vida daquele indivíduo é encerrado automaticamente.

A cada nova geração, surgem agentes com cores e tamanhos diferentes. E sob esta ótica a metodologia dos agentes genéticos opera. No código é realizado o ranqueamento de cada indivíduo da geração atual baseando-se no seu tempo de vida. Aqueles que tiverem um tempo de vida maior serão os maiores pontuadores. Dentro do processo é feita a mesclagem do DNA dos mais pontuados com uma amostra dos menos pontuados, para diversificar a nova geração. E para aumentar a variabilidade do processo é inserida a mutação, que pode ser controlada diretamente no código.

É notória a padronização do processo, a cada nova geração, caso o usuário tenda a uma cor e/ou tamanho específico. Resultando em uma homogeneização da população. Observando-se assim o fenômeno da seleção natural, através do qual o operador exerce o papel do universo, como sistema auto regulável. Podendo optar pela variabilidade ou homogeneização dos indivíduos do mundo simulado.
