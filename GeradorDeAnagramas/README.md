# Gerador de Anagramas

Dada uma certa palavra, gerar todos os anagramas possíveis para ela.

Esse é um problema de Fatorial. Uma string pode gerar N! anagramas dependendo do seu length.

## Exemplos
* 1 letra - 1 anagrama
* 2 letras - 2 anagramas
* 3 letras - 6 anagrams
* 4 letras - 24 anagramas
* 5 letras - 120 anagramas
* 6 letras - 720 anagramas
* n letras - n! anagramas

## Solução
Esse algoritmo pode ser recursivo. 

Primeiro solucionamos os casos mais fáceis: Se a palavra tem uma única letra retorna-se uma lista contendo apenas ela. Se ela tem 2, retornamos uma lista contendo ela mesma e sua inversão.

Para strings maiores que duas letras, geramos uma lista com os possíveis anagramas das duas últimas letras. Uma lista de dois elementos com dois caracteres cada.

Obtemos então a próxima letra da direita para a esquerda. Com essa letra, varremos a lista com os dois anagramas iniciais e colocamos a letra em cada uma das posições, em cada um deles. Então para cada palavra na lista, concatenamos a letra em questão no início, no meio e no final, gerando 3 novas palavras para cada item da lista. Criamos assim uma nova lista com 6 palavras de 3 elementos. 

Obtemos a próxima letra da direita para a esquerda e repetimos o processo: para cada um dos 6 itens da nova lista, geraremos mais 4 elementos com a letra nova em cada uma das posições 0-3 e armazenando em uma nova lista, com 24 palavras de 4 letras. 

Continuamos nesse processo até acabarem as letras. 

O exemplo aqui fará anagramas com a palavra "amor" ou qualquer outra que você colocar no código fonte, mas pode fazer anagramas com uma palavra passada via argumento da linha de comando também.
	